using Lab6;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        private Computer computer;

        [SetUp]
        public void Setup()
        {
            computer = new Computer("ENVY 13-d010nw", "HP", new Computer.ComputerInfo(Computer.ComputerInfo.OperationSystem.MS, "Intel Core i5", 16));
        }

        [Test]
        public void Test1()
        {
            string expectedStr = "Computer: { HP ENVY 13-d010nw, Operation System = MS, Processor = Intel Core i5, RAM = 16GB }";
            Assert.AreEqual(expectedStr, computer.ToString());
        }
    }
}