using System.Reflection;

namespace Multi_Tabular_MVVM.Tools
{
    public static class Clonator
    {
        public static T Clone<T>(T item) where T : class, new()
        {
            var properties = item.GetType().GetProperties();

            var newItem = new T();
            foreach (var property in properties)
            {
                if (property.GetCustomAttribute(typeof(CloneIgnore)) != null) continue;
                property.SetValue(newItem, property.GetValue(item));
            }
            return newItem;
        }

        public static void CopyProperties<T>(T from, T to) where T : class, new()
        {
            var properties = from.GetType().GetProperties();

            foreach (var property in properties)
            {
                if (property.GetCustomAttribute(typeof(CloneIgnore)) != null) continue;
                property.SetValue(to, property.GetValue(from));
            }
        }
    }

    [System.AttributeUsage(System.AttributeTargets.Property)]
    public class CloneIgnore : System.Attribute
    {
    }
}