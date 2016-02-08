
namespace PluginLib
{
    public class StringToLower : Plugin<string>
    {
        public override string Modify(string source)
        {
            return source == null ? null : source.ToLower();
        }
    }
}
