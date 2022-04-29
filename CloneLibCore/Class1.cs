﻿using System;

namespace CloneLibCore
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
    }
}
