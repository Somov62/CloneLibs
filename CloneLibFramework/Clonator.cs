using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloneLibFramework
{
    public static class Clonator
    {
        public static T Clone<T>(T item) where T : class, new()
        {
            var properties = item.GetType().GetProperties();

            var newItem = new T();
            foreach (var property in properties)
            {
                property.SetValue(newItem, property.GetValue(item));
            }
            return newItem;
        }

        public static void CopyProperties<T>(T target, T source) where T : class, new()
        {
            var properties = target.GetType().GetProperties();

            foreach (var property in properties)
            {
                property.SetValue(source, property.GetValue(target));
            }
        }
    }
}
