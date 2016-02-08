using System;

namespace PluginLib
{

    public class PluginablePlugin : Plugin<double>
    {
        public Plugin<double> plugin;
        public PluginablePlugin(Plugin<double> inpPlugin)
        {
            if (inpPlugin == null)
            {
                throw new NotImplementedException();
            }
            else
            {
                plugin = inpPlugin;
            }
        }
        public override double Modify(double source)
        {
            source = source * 2;
            return plugin.Modify(source);
        }
    }
}
