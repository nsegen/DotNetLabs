using Lab7;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        Student student;

        [SetUp]
        public void Setup()
        {
            student = new ExtramuralStudent("Vasya Pupkin", "MMF", 2);
        }

        [Test]
        public void Test1()
        {
            string expectedStr = "Extramural Student: { Name = Vasya Pupkin, Faculty = MMF, Course = 2 }";
            Assert.AreEqual(expectedStr, student.GetInformation());
        }
    }
}