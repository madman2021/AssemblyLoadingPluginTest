using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Plugins;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {


            var test = PluginLoader.GetPlugins(Directory.GetParent(Directory.GetParent(Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName).FullName).FullName + @"\plugins");
            foreach (var plugin in test)
            {
                plugin.Work();
            }
            Console.Read();
        }
    }
}
