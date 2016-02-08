using System;

namespace PluginLib
{
    public class DoublePlugin : Plugin<double>
    {
        public override double Modify(double source)
        {
            return Math.Abs(source);
        }
    }
}
