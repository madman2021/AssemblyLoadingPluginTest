using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {

            var test = PluginLoader.GetPlugins("C:\\XFR\\plugin");
            foreach (var plugin in test)
            {
                plugin.Work();
            }
            Console.Read();
        }
    }
}
