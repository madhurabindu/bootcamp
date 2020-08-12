using NUnit.Framework;
using System;
using System.Drawing;
using System.IO;
using TelecomColorCoder;

namespace TestsTelecomColorCoder
{
    public class TestPairNumbers
    {
        private int maxPairCount = 25;

        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void TestPairColorMapCorrectness1()
        {
            ColorCoder cd = new ColorCoder();
            var colors = cd.GetColorFromPairNumber(1);
            Assert.AreEqual(colors[0], Color.White);
            Assert.AreEqual(colors[1], Color.Blue);
        }

        [Test]
        public void TestPairColorMapCorrectness2()
        {
            ColorCoder cd = new ColorCoder();
            var colors = cd.GetColorFromPairNumber(14);
            Assert.AreEqual(colors[0], Color.Black);
            Assert.AreEqual(colors[1], Color.Brown);
        }

        [Test]
        public void TestPairColorMapCorrectness3()
        {
            ColorCoder cd = new ColorCoder();
            var colors = cd.GetColorFromPairNumber(23);
            Assert.AreEqual(colors[0], Color.Violet);
            Assert.AreEqual(colors[1], Color.Green);
        }

        [Test]
        public void TestPairInputOutOfRange1()
        {
            bool pass = false;
            ColorCoder cd = new ColorCoder();
            try
            {
                var colors = cd.GetColorFromPairNumber(maxPairCount + 1);
            }
            catch(ArgumentOutOfRangeException)
            {
                pass = true;
            }
            
            Assert.IsTrue(pass);
        }

        [Test]
        public void TestPairInputOutOfRange2()
        {
            bool pass = false;
            ColorCoder cd = new ColorCoder();
            try
            {
                var colors = cd.GetColorFromPairNumber(maxPairCount + 100);
            }
            catch (ArgumentOutOfRangeException)
            {
                pass = true;
            }
            Assert.IsTrue(pass);
        }

        [Test]
        public void TestPairInput1BasedIndex1()
        {
            bool pass = false;
            ColorCoder cd = new ColorCoder();
            try
            {
                var colors = cd.GetColorFromPairNumber(0);
            }
            catch (ArgumentOutOfRangeException)
            {
                pass = true;
            }
            Assert.IsTrue(pass);
        }
    }
}
