﻿using System.IO;
using System.Management.Automation;
using System.Reflection;
using System.Runtime.Loader;

namespace MagicTooltips.Services.DependencyService
{
  public class ModuleInitializer : IModuleAssemblyInitializer
  {
    private static string s_binBasePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    //private static string s_binBasePath = Path.GetFullPath(
    //    Path.Combine(
    //        Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
    //        ".."));

    //private static string s_binCommonPath = Path.Combine(s_binBasePath, "Common");

    //private static string s_binCorePath = Path.Join(s_binBasePath, "Core");


    public void OnImport()
    {
      AssemblyLoadContext.Default.Resolving += ResolveAssembly_NetCore;
    }

    private static Assembly ResolveAssembly_NetCore(
        AssemblyLoadContext assemblyLoadContext,
        AssemblyName assemblyName)
    {
      // In .NET Core, PowerShell deals with assembly probing so our logic is much simpler
      // We only care about certain assemblies
      if (!assemblyName.Name.Equals("Microsoft.ApplicationInsights"))
      {
        return null;
      }

      // Now load the Engine assembly through the dependency ALC, and let it resolve further dependencies automatically
      return DependencyAssemblyLoadContext.GetForDirectory(s_binBasePath).LoadFromAssemblyName(assemblyName);
    }


  }
}