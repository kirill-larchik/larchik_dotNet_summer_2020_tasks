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
    }
}
