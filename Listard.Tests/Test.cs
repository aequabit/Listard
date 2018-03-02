using NUnit.Framework;

namespace Listard.Tests
{
    [TestFixture()]
    public class Test
    {
        private Listard<int> _listard = new Listard<int>();

        [Test()]
        public void LenghtCheck()
        {
            Listard<int> test = new Listard<int>();
            int lenght1 = test.Count;
            int[] arr = {1, 2, 3, 4, 5, 6, 7, 8, 9, 0};
            test.Add(arr);
            int lenght2 = test.Count;

            Assert.AreNotEqual(lenght1, lenght2);
        }

        [Test()]
        public void CheckInitializedListard()
        {
            Assert.AreEqual(_listard.Count, 0);
        }

        [Test()]
        public void TestAddInt()
        {
            _listard.Add(1);
            Assert.AreNotEqual(_listard.Count, 0);
        }

        [Test()]
        public void TestRemoveAt()
        {
            var test = new Listard<int> {{1, 2, 3, 4, 5}};
            test.RemoveAt(0);
            Assert.AreEqual(test.Count, 4);
        }

        [Test()]
        public void TestContains()
        {
            _listard.Add(100);
            Assert.True(_listard.Contains(100));
        }

        [Test()]
        public void TestFindElement()
        {
            Assert.AreNotEqual(_listard.FindElement(100), null);
        }
    }
}
