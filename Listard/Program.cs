using System;

namespace ListardTest
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // Create a Listard instance
            Listard list = new Listard();

            // Add elements
            list.Add(1337);
            list.Add(1338);
            list.Add(1339);

            // Get the element at index 0
            list.ElementAt(0);

            // Remove element at index 1
            list.RemoveAt(1);

            // Get the count of elements
            int count = list.Count;

            // Get the list in a human-readable format
            string str = list.ToString();
        }
    }
}
