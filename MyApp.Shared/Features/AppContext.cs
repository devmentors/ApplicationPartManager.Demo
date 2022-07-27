using System.Reflection;
using MyApp.Shared.Modules;

namespace MyApp.Shared.Features;

public sealed record AppContext(IEnumerable<Assembly> LoadedAssemblies, IEnumerable<IModule> LoadedModules);
