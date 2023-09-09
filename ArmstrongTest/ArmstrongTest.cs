using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Armstrong;

namespace ArmstrongTest
{
    [TestFixture]
    public class ArmstrongTest
    {
        [Test]
        public void TestFormNumber()
        {
            Assert.AreEqual(24, 12345.OddDigits().FormNumber());
            Assert.AreEqual(135, 12345.EvenDigits().FormNumber());
        }
        [Test]
        public void TestDigitsAt()
        {
            Assert.IsTrue(12345.DigitsAt(1, 3).SequenceEqual(new int[] { 2, 4 }));
        }
        [Test]
        public void TestEvenDigits()
        {
            Assert.IsTrue(12345.EvenDigits().SequenceEqual(new int[] { 1, 3, 5 }));
        }
        [Test]
        public void TestOddDigits()
        {
            Assert.IsTrue(12345.OddDigits().SequenceEqual(new int[] { 2, 4 }));
        }
        [Test]
        public void TestFactorial()
        {
            Assert.AreEqual(145, 145.Digits().Factorial().Sum());
        }
        [Test]
        public void TestRaiseToSelf()
        {
            Assert.AreEqual(32, 123.Digits().RaiseSelfToSelf().Sum());
        }
        [Test]
        public void TestIncrementalPower()
        {
            Assert.AreEqual(12, 123.Digits().IncrementalPower().Sum());
        }
        [Test]
        public void TestProducts()
        {
            Assert.AreEqual(6, 123.Digits().Product());
        }
        [Test]
        public void TestDigits()
        {
            Assert.IsTrue(1234.Digits().SequenceEqual(new int[] { 1, 2, 3, 4 }));
        }
        [Test]
        public void TestArmstrongNumber()
        {
            Assert.IsTrue(153.Digits().Cube().Sum() == 153);
        }
        [Test]
        public void TestDudeney()
        {
            Assert.IsTrue(512.Digits().Sum().Cube() == 512);
        }
    }
}