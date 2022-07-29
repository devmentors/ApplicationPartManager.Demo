using MyApp.Shared.Features;


var builder = WebApplication.CreateBuilder(args);
builder.Host.ConfigureModules();

var (assemblies, modules) = AppInitializer.Initialize(builder);

foreach (var module in modules)
{
    module.Register(builder.Services, builder.Configuration);
}

var app = builder.Build();
var logger = app.Services.GetRequiredService<ILogger<Program>>();

logger.LogInformation($"Initialized modules: {string.Join(',', modules.Select(x => x.Name))}");

foreach (var module in modules)
{
    module.Use(app);
}

app.MapGet("/", () => "Hello World!");
app.UseRouting().UseEndpoints(x => x.MapControllers());

foreach (var module in modules)
{
    module.Expose(app);
}

app.Run();

