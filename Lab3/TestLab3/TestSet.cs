using NUnit.Framework;
using Lab3;

namespace TestLab3
{
    public class Tests
    {
        private Set<int> set1;
        private Set<int> set2;

        [SetUp]
        public void Setup()
        {
            set1 = new Set<int>();
            set2 = new Set<int>();
        }

        [Test]
         public void Test_Add()
        {
            set1.Add(1);
            set1.Add(2);
            Assert.IsTrue(set1.Contains(1));
            Assert.IsTrue(set1.Contains(2));
            Assert.AreEqual(2,set1.Count());
        }

        [Test]
        public void Test_Union()
        {
            set1.Add(1);
            set2.Add(2);
            set1.UnionWith(set2);
            Assert.IsTrue(set1.Contains(1));
            Assert.IsTrue(set1.Contains(2));
            Assert.AreEqual(2,set1.Count());
        }
    }
}