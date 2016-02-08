using System;
using System.Collections.Generic;

namespace PluginLib
{

    public class PluginCollection<T> : Plugin<T>
    {
        private List<Plugin<T>> pluginList;

        public PluginCollection()
        {
            pluginList = new List<Plugin<T>>();
        }
        //To do: Add() exeption handler
        public void Add(Plugin<T> plugin)
        {
            pluginList.Add(plugin);
        }
        public override T Modify(T source)
        {
            foreach (Plugin<T> p in pluginList)
            {
                source = p.Modify(source);
            }
            return source;
        }
    }
}
