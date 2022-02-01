using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWEditorCLI
{
    public static class References
    {
        public static List<string> references = new List<string>();
        public static Dictionary<System.Type, object> objects = new Dictionary<System.Type, object>();
        public static Dictionary<string, object> instances = new Dictionary<string, object>();
        public static void AddReference<T>(string reference, T obj)
        {
            references.Add(reference);
            instances.Add(reference, obj);
            objects.Add(typeof(T), obj);
        }
        public static T GetReference<T>() where T : class
        {
            if (objects.ContainsKey(typeof(T)))
            {
                return (T)objects[typeof(T)];
            }
            return null;
        }

        public static T GetReference<T>(string name) where T : class
        {
            if (instances.ContainsKey(name))
            {
                return (T)instances[name];
            }
            return null;
        }

        public static bool IsInitialised(string reference)
        {
            return references.Contains(reference);
        }

        public static bool IsInitialised<T>()
        {
            return references.Contains(typeof(T).FullName);
        }
    }
}
