using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyApp.Shared.Modules;

namespace MyApp.Shared.Features;

public static class AppInitializer
{
    private const string ModulePrefix = "MyApp.Modules.";
    public static AppContext Initialize(WebApplicationBuilder builder)
    {
        var disabledModules = new HashSet<string>();
        var assemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();
        var locations = assemblies.Where(x => !x.IsDynamic).Select(x => x.Location).ToArray();
        var files = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll")
            .Where(x => !locations.Contains(x, StringComparer.InvariantCultureIgnoreCase))
            .ToList();

        foreach (var file in files)
        {
            if (!file.Contains(ModulePrefix))
            {
                continue;
            }

            var moduleName = file.Split(ModulePrefix)[1].Split(".")[0].ToLowerInvariant();
            var enabled = builder.Configuration.GetValue<bool>($"{moduleName}:module:enabled");
            
            if (enabled)
            {
                assemblies.Add(AppDomain.CurrentDomain.Load(AssemblyName.GetAssemblyName(file)));
            }
            else
            {
                disabledModules.Add(moduleName);
            }
        }

        builder.Services.AddControllers().ConfigureApplicationPartManager(manager =>
        {
            var appParts = disabledModules.SelectMany(x => manager.ApplicationParts
                .Where(part => part.Name.Contains(x, StringComparison.InvariantCultureIgnoreCase))).ToList();

            foreach (var part in appParts)
            {
                manager.ApplicationParts.Remove(part);
            }
                    
            manager.FeatureProviders.Add(new CustomControllerFeatureProvider());
        });

        #region Modules

        var modules = assemblies
            .SelectMany(x => x.GetTypes())
            .Where(x => typeof(IModule).IsAssignableFrom(x) && x.IsClass)
            .OrderBy(x => x.Name)
            .Select(Activator.CreateInstance)
            .Cast<IModule>()
            .ToList();

        #endregion
       

        return new (assemblies.ToList(), modules.ToHashSet());
    }
}