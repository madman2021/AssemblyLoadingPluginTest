using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using PluginInterface;

namespace Test
{
   public static class PluginLoader
    {
        public static List<IPlugin> GetPlugins(string pluginSearchDir)
        {
            var loadedPlugins = new List<IPlugin>();

            foreach (var file in Directory.GetFiles(pluginSearchDir))
            {

                var assemblyName = AssemblyName.GetAssemblyName(file);
                var assembly = Assembly.Load(assemblyName);
                var types = assembly.GetTypes().Where(a => !a.IsInterface && !a.IsAbstract);
                foreach (var type in types)
                {
                    if (type.GetInterface(typeof(IPlugin).FullName) != null)
                    {
                        loadedPlugins.Add((IPlugin)Activator.CreateInstance(type));
                    }
                }

            }
            return loadedPlugins;
        }  
    }
}
