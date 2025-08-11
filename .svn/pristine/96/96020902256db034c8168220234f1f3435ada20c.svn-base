using System;
using System.IO;
using System.Reflection;
using System.Linq;
using Emr.Pluggable.Interface;
using System.Collections.Generic;

namespace Emr.Pluggable.Plugin
{
    public static class Plugin
    {
        private static Dictionary<string, object> _cachePlugins = new Dictionary<string, object>();
        public static bool UseCache { get; set; }

        public static T CreatePlugin<T>(string dir, string name)
        {
            var path = name + ".dll";
            if (_cachePlugins.ContainsKey(name)) return (T)_cachePlugins[name];
            T plugin = default(T);

            if (!File.Exists(path))
            {
                if (name.EndsWith(".dll"))
                    path = Path.Combine(dir, name);
                else
                    path = Path.Combine(dir, name + ".dll");
            }

            Assembly asm = null;
            if (UseCache)
                asm = Assembly.LoadFile(path);
            else
                asm = Assembly.Load(File.ReadAllBytes(path));

            if (asm != null)
            {
                for (int i = 0; i < asm.GetTypes().Length; i++)
                {
                    Type type = (Type)asm.GetTypes().GetValue(i);
                    if (IsImplementationOf(type, typeof(IPluginBase)))
                    {
                        plugin = (T)Activator.CreateInstance(type);
                        if (UseCache)
                            _cachePlugins.Add(name, plugin);
                    }
                }
            }
            return plugin;
        }

        private static bool IsImplementationOf(Type type, Type @interface)
        {
            Type[] interfaces = type.GetInterfaces();

            return interfaces.Any(current => IsSubtypeOf(ref current, @interface));
        }

        private static bool IsSubtypeOf(ref Type a, Type b)
        {
            if (a == b)
            {
                return true;
            }

            if (a.IsGenericType)
            {
                a = a.GetGenericTypeDefinition();

                if (a == b)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
