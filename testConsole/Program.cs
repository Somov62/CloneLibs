using System;

namespace testConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var aboba = new ABOBA();
            aboba.MyProperty = 20;
            var aboba1 = Clonator.Clone<ABOBA>(aboba);
            Console.WriteLine();
        }
    }

    public class ABOBA
    {
        
        private int myVar = 10;

        public int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }

        public int MyProperty1 { get; set; }

    }

    public static class Clonator
    {
        public static T Clone<T>(T item) where T : class, new()
        {
            var properties = item.GetType().GetProperties();
            
            var newItem =  new T();
            foreach (var property in properties)
            {
                property.SetValue(newItem, property.GetValue(item));
            }
            return newItem; 
        }
    }
}
