using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GCDClassLibrary;

namespace GCDUnitTestProject
{
    /// <summary>
    /// Класс, описывающий методы для тестирвования функционала класса GCDClass.
    /// </summary>
    [TestClass]
    public class GCDUnitTest
    {
        /// <summary>
        /// Метод нахождения НОД двух целых чисел.
        /// </summary>
        [TestMethod]
        public void GetGCD_81and243_81returned()
        {
            int firstNumber = 81;
            int secondNumber = 243;
            int expected = 81;

            GCDClass gCD = new GCDClass();
            int actual = gCD.GetGDC(firstNumber, secondNumber);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Метод нахождения НОД двух целых чисел.
        /// </summary>
        [TestMethod]
        public void GetGCD_108and72_36returned()
        {
            int firstNumber = 108;
            int secondNumber = 72;
            int expected = 36;

            GCDClass gCD = new GCDClass();
            int actual = gCD.GetGDC(firstNumber, secondNumber);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Метод нахождения НОД двух целых чисел.
        /// </summary>
        [TestMethod]
        public void GetGDC_44and44_44returned()
        {
            int firstNumber = 44;
            int secondNumber = 44;
            int expected = 44;

            GCDClass gCD = new GCDClass();
            int actual = gCD.GetGDC(firstNumber, secondNumber);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Метод нахождения НОД трёх целых чисел.
        /// </summary>
        [TestMethod]
        public void GetGDC_10080and2646and56_14returned()
        {
            int firstNumber = 10080;
            int secondNumber = 2646;
            int thirdNumber = 56;
            int expected = 14;

            GCDClass gCD = new GCDClass();
            int actual = gCD.GetGDC(firstNumber, secondNumber, thirdNumber);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Метод нахождения НОД трёх целых чисел.
        /// </summary>
        [TestMethod]
        public void GetGDC_78and294and570_6returned()
        {
            int firstNumber = 78;
            int secondNumber = 294;
            int thirdNumber = 570;
            int expected = 6;

            GCDClass gCD = new GCDClass();
            int actual = gCD.GetGDC(firstNumber, secondNumber, thirdNumber);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Метод нахождения НОД трёх целых чисел.
        /// </summary>
        [TestMethod]
        public void GetGDC_10080andMinus2646and56_14returned()
        {
            int firstNumber = 10080;
            int secondNumber = -2646;
            int thirdNumber = 56;
            int expected = 14;

            GCDClass gCD = new GCDClass();
            int actual = gCD.GetGDC(firstNumber, secondNumber, thirdNumber);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Метод нахождения НОД четырёх целых чисел.
        /// </summary>
        [TestMethod]
        public void GetGDC_78and294and570and36_6returned()
        {
            int firstNumber = 78;
            int secondNumber = 294;
            int thirdNumber = 570;
            int fourthNumber = 36;
            int expected = 6;

            GCDClass gCD = new GCDClass();
            int actual = gCD.GetGDC(firstNumber, secondNumber, thirdNumber, fourthNumber);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Метод нахождения НОД четырёх целых чисел.
        /// </summary>
        [TestMethod]
        public void GetGDC_10080and2646and56and28_14returned()
        {
            int firstNumber = 10080;
            int secondNumber = 2646;
            int thirdNumber = 56;
            int fourthNumber = 28;
            int expected = 14;

            GCDClass gCD = new GCDClass();
            int actual = gCD.GetGDC(firstNumber, secondNumber, thirdNumber, fourthNumber);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Метод нахождения НОД пяти целых чисел.
        /// </summary>
        [TestMethod]
        public void GetGDC_10080and2646and56and28and144_2returned()
        {
            int firstNumber = 10080;
            int secondNumber = 2646;
            int thirdNumber = 56;
            int fourthNumber = 28;
            int fifthNumber = 144;
            int expected = 2;

            GCDClass gCD = new GCDClass();
            int actual = gCD.GetGDC(firstNumber, secondNumber, thirdNumber, fourthNumber, fifthNumber);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Метод нахождения НОД пяти целых чисел.
        /// </summary>
        [TestMethod]
        public void GetGDC_78and294and570and36and144_6returned()
        {
            int firstNumber = 78;
            int secondNumber = 294;
            int thirdNumber = 570;
            int fourthNumber = 36;
            int fifthNumber = 144;
            int expected = 6;

            GCDClass gCD = new GCDClass();
            int actual = gCD.GetGDC(firstNumber, secondNumber, thirdNumber, fourthNumber, fifthNumber);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Метод бинароного нахождения НОД двух целых чисел.
        /// </summary>
        [TestMethod]
        public void GetBinaryGDC_81and243_81returned()
        {
            uint firstNumber = 81;
            uint secondNumber = 243;
            uint expected = 81;

            TimeSpan time;
            GCDClass gCD = new GCDClass();
            uint actual = gCD.GetBinaryGDC(firstNumber, secondNumber, out time);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Метод бинароного нахождения НОД двух целых чисел.
        /// </summary>
        [TestMethod]
        public void GetBinaryGDC_CheckTime()
        {
            uint firstNumber = 81;
            uint secondNumber = 243;

            TimeSpan time;
            GCDClass gCD = new GCDClass();
            uint actual = gCD.GetBinaryGDC(firstNumber, secondNumber, out time);

            Assert.IsTrue(time.TotalSeconds > 0);
        }
    }
}
