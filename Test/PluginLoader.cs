using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using PluginInterface;

namespace Plugins
{
   public static class PluginLoader
    {
        public static List<IPlugin> GetPlugins(string pluginSearchDir)
        {
            var loadedPlugins = new List<IPlugin>();
            //Go through each .dll file in the directory
            foreach (var file in Directory.GetFiles(pluginSearchDir,"*.dll"))
            {
                var assemblyName = AssemblyName.GetAssemblyName(file);
                var assembly = Assembly.Load(assemblyName);
                //Get classes that are not Abstract or Interfaces
                var types = assembly.GetTypes().Where(a => !a.IsInterface && !a.IsAbstract);
                foreach (var type in types)
                {
                    //Does this class implement IPlugin
                    if (type.GetInterface(typeof(IPlugin).FullName) != null)
                    {
                        //Create an instance of the type
                        loadedPlugins.Add((IPlugin)Activator.CreateInstance(type));
                    }
                }
            }
            return loadedPlugins;
        }  
    }
}
