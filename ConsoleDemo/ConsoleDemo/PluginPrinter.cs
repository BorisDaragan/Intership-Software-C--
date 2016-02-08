using System;

namespace PluginLib
{

    public class PluginPrinter<T>
    {
        public Type pluginType; 
        private Plugin<T> plugin;
        private T source;
        public PluginPrinter(Plugin<T> inpPlugin, T inpSource)
        {
            plugin = inpPlugin;
            source = inpSource;
            pluginType = typeof(T);
        }
        public void Print()
        {
            Console.WriteLine(plugin.Modify(source));
        }
    }
}
