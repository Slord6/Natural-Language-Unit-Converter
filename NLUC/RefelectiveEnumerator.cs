using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NLUC.Utils
{
    internal static class ReflectiveEnumerator
    {
        static ReflectiveEnumerator() { }

        public static IEnumerable<T> GetEnumerableOfType<T>(params object[] constructorArgs) where T : class
        {
            List<T> objects = new List<T>();
            Assembly? assembly = Assembly.GetAssembly(typeof(T));
            if (assembly == null) throw new ArgumentException($"Cannot get assembly for type");
            foreach (Type type in
                assembly.GetTypes()
                .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(T))))
            {
                T instance = (T)Activator.CreateInstance(type, constructorArgs);
                if (instance == null) continue;
                objects.Add(instance);
            }
            return objects;
        }
    }
}
