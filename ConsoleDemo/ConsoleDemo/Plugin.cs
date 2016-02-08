
namespace PluginLib
{
    abstract public class Plugin<T>
    {
        public abstract T Modify(T source);
    }
}
