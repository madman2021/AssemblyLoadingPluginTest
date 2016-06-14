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
        public static List<IPlugin> GetPlugins(string pluginSearchPath)
        {
            var loadedAssemblys = new List<Assembly>();

            foreach (var file in Directory.GetFiles(pluginSearchPath))
            {

                var name = AssemblyName.GetAssemblyName(file);
                var a = Assembly.Load(name);
                loadedAssemblys.Add(a); // This could possibly leave the reference open to the assembly and keep a file lock.
            }

            var pluginNames = new List<Type>();
            foreach (Assembly loadedAssembly in loadedAssemblys)
            {
                foreach (var t in loadedAssembly.GetTypes().Where(la=>!la.IsInterface && !la.IsAbstract))      
                {
                    if (t.GetInterface(typeof (IPlugin).FullName) != null)
                    {
                        pluginNames.Add(t);
                    }
                }
            }
            var rtnLst = new List<IPlugin>();
            foreach (var pluginName in pluginNames)
            {
                var p = (IPlugin)Activator.CreateInstance(pluginName);
                rtnLst.Add(p);

            }

            return rtnLst;
        }  
    }
}
