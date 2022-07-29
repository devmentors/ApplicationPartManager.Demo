using System.Reflection;
using MyApp.Shared.Modules;

namespace MyApp.Shared.Features;

public sealed record AppContext(List<Assembly> LoadedAssemblies, HashSet<IModule> LoadedModules);
