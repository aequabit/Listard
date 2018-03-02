using System;
using System.Reflection;
using Listard;

namespace StupidUnitTest
{
    class Program
    {
        private static Listard<int> _listard = new Listard<int>();
        private static bool _error = false;

        static void Main(string[] args)
        {
            Console.WriteLine("StupidUnitTest");
            Console.WriteLine("=======================================");
            Console.WriteLine();

            // tests
            foreach (var test in typeof(Program).GetMethods(BindingFlags.Public | BindingFlags.Static))
            {
                if (test.Name.StartsWith("Test"))
                {
                    try
                    {
                        test.Invoke(null, null);
                        Console.WriteLine($"{test.Name} succeeded");
                    }
                    catch (TargetInvocationException ex)
                    {
                        Console.WriteLine($"{test.Name} failed: {ex.InnerException?.Message}");
                    }
                }
            }

            if (!_error)
            {
                Console.WriteLine();
                Console.WriteLine("=======================================");
                Console.WriteLine("All tests were successful. Keep going!");
            }

            Console.ReadKey(); // wait here
        }
        
        public static void TestLenght()
        {
            Listard<int> test = new Listard<int>();
            var lenght1 = test.Count;
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
            test.Add(arr);
            var lenght2 = test.Count;

            if (lenght2.Equals(lenght1))
            {
                _error = true;
                throw new Exception("Unit Test #1 failed.");
            }
        }

        public static void TestInitialization()
        {
            if (_listard.Count != 0)
                throw new Exception("Unit Test #2 failed.");
        }

        public static void TestAddInt()
        {
            _listard.Add(1);
            if (_listard.Count == 0)
                throw new Exception("Unit Test #3 failed.");
        }

        public static void TestRemoveAt()
        {
            var test = new Listard<int> { { 1, 2, 3, 4, 5 } };
            test.RemoveAt(0);

            if (test.Count != 4)
                throw new Exception("Unit Test #4 failed.");
        }

        public static void TestContains()
        {
            _listard.Add(100);
            if (!_listard.Contains(100))
            {
                throw new Exception("Unit Test #5 failed.");
            }
        }

        public static void TestFindElement()
        {
            if(_listard.FindElement(100) == default(int))
            {
                throw new Exception("Unit Test #6 failed.");
            }
        }
    }
}

