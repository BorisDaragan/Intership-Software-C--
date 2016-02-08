
namespace PluginLib
{
    public class StringToUpper : Plugin<string>
    {
        public override string Modify(string source)
        {
            return source == null ? null : source.ToUpper();
        }
    }
}
