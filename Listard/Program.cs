using System;
using ListardTest;

namespace Listard
{
    internal class MainClass
    {
        public static void Main(string[] args)
        {

            Console.WriteLine("Listard<int>: {0}", IntList());
            Console.WriteLine("Listard<Person>: {0}", PersonList());
        }

        private static Listard<int> IntList()
        {
            // Create a Listard instance of type int
            var list = new Listard<int>();

            // Add elements
            list.Add(1, 2, 3);
            list.Add(4, 5, 6);
            list.Add(7, 8, 9);

            return list;
        }

        private static Listard<Person> PersonList()
        {
            // Create a Listard instance of type int
            var list = new Listard<Person>();

            // Create persons
            Person manfred;
            manfred.Name = "Manfred";
            manfred.Gender = Gender.Male;
            manfred.DateOfBirth = new DateTime(1988, 04, 21);

            Person guenter;
            guenter.Name = "Guenter";
            guenter.Gender = Gender.Male;
            guenter.DateOfBirth = new DateTime(1972, 07, 02);

            // Add persons to the list
            list.Add(manfred);
            list.Add(guenter);

            return list;
        }
    }
}
