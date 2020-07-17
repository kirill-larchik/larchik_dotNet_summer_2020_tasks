using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolynomialClassLibrary;

namespace PolynomialUnitTestProject
{
    [TestClass]
    public class PolynomialUnitTest
    {
        [TestMethod]
        [ExpectedException(typeof(Exception), "Коэффициент старшей степени не может равняться нулю.")]
        public void InitExeption()
        {
            Polynomial polynomial = new Polynomial(0, 1, 2, 3);
        }

        [TestMethod]
        public void Plus_EqualDegres()
        {
            Polynomial firstPolynomial = new Polynomial(2, 4, 5, 7);
            Polynomial secondPolynomial = new Polynomial(6, 9, 2, 7);
            Polynomial expected = new Polynomial(8, 13, 7, 14);

            Polynomial actual = firstPolynomial + secondPolynomial;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Plus_NotEqualDegres()
        {
            Polynomial firstPolynomial = new Polynomial(2, 4, 5, 7);
            Polynomial secondPolynomial = new Polynomial(6, 9, 2, 7, 12);
            Polynomial expected = new Polynomial(6, 11, 6, 12, 19);

            Polynomial actual = firstPolynomial + secondPolynomial;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Minus_EqualDegres()
        {
            Polynomial firstPolynomial = new Polynomial(2, -4, -12, 123, -67);
            Polynomial secondPolynomial = new Polynomial(61, -93, 22, 75, -11);
            Polynomial expected = new Polynomial(-59, 89, -34, 48, -56);

            Polynomial actual = firstPolynomial - secondPolynomial;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Minus_NotEqualDegres()
        {
            Polynomial firstPolynomial = new Polynomial(2, -4, -12, 123, -67);
            Polynomial secondPolynomial = new Polynomial(12, 61, -93, 22, 75, -11);
            Polynomial expected = new Polynomial(12, -59, 89, -34, 48, -56);

            Polynomial actual = firstPolynomial - secondPolynomial;

            Assert.AreEqual(expected, actual);
        }
    }
}
