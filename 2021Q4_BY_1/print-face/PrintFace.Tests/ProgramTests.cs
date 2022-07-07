using System;
using System.IO;
using NUnit.Framework;

namespace PrintFace.Tests
{
    [TestFixture]
    public sealed class ProgramTests : IDisposable
    {
        private StringWriter writer;
        
        [SetUp]
        public void SetUp()
        {
            this.writer = new StringWriter();
            Console.SetOut(this.writer);
        }
        
        [TearDown]
        public void Dispose()
        {
            this.writer.Close();
        }
        
        [Test]
        public void MainTests()
        {
            Program.Main();

            string actual = this.writer.GetStringBuilder().ToString().Trim();

            string expected = "Hello, world!";

            Assert.AreEqual(expected, actual);
        }

        [TestCase("Joseph")]
        [TestCase("Eric")]
        [TestCase("Jon")]
        public void SayHelloUserTests(string userName)
        {
            Program.SayHelloUser(userName);

            string actual = this.writer.GetStringBuilder().ToString().Trim();

            string expected = $"Hello, {userName}!";

            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void PrintFaceTests()
        {
            Program.PrintFace();

            string actual = this.writer.GetStringBuilder().ToString();

            string expected = $" +\"\"\"\"\"+{Environment.NewLine}" +
                              $"(| o o |){Environment.NewLine}" +
                              $" |  ^  |{Environment.NewLine}" +
                              $" | '-' |{Environment.NewLine}" +
                              $" +-----+{Environment.NewLine}";

            Assert.AreEqual(expected, actual);
        }
    }
}
