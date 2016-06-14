using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PluginInterface;

namespace PluginB
{
    public class PluginB : IPlugin
    {
        public string name => "PluginB";

        public void Work()
        {
            Console.WriteLine($"Work done by {name}");
        }
    }
}
