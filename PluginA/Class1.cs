using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PluginInterface;

namespace PluginA
{
    public class PluginA : IPlugin
    {
        public string name => "PluginA";

        public void Work()
        {
            Console.WriteLine($"Work done by {name}");
        }
    }
}
