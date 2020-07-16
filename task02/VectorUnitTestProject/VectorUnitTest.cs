using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VectorClassLibrary;

namespace VectorUnitTestProject
{
    [TestClass]
    public class VectorUnitTest
    {
        [TestMethod]
        public void Plus_AllPositiveCoordinates()
        {
            TridimensionalVector firstVector = new TridimensionalVector(1, 2, 5);
            TridimensionalVector secondVector = new TridimensionalVector(4, 8, 1);
            TridimensionalVector expected = new TridimensionalVector(5, 10, 6);

            TridimensionalVector actual = firstVector + secondVector;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Plus_PositiveAndNegativeCoordinates()
        {
            TridimensionalVector firstVector = new TridimensionalVector(5, 9, -10);
            TridimensionalVector secondVector = new TridimensionalVector(17, -3, -2);
            TridimensionalVector expected = new TridimensionalVector(22, 6, -12);

            TridimensionalVector actual = firstVector + secondVector;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Minus_AllPositiveCoordinates()
        {
            TridimensionalVector firstVector = new TridimensionalVector(1, 2, 5);
            TridimensionalVector secondVector = new TridimensionalVector(4, 8, 1);
            TridimensionalVector expected = new TridimensionalVector(-3, -6, 4);

            TridimensionalVector actual = firstVector - secondVector;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Minus_PositiveAndNegativeCoordinates()
        {
            TridimensionalVector firstVector = new TridimensionalVector(5, 9, -10);
            TridimensionalVector secondVector = new TridimensionalVector(17, -3, -2);
            TridimensionalVector expected = new TridimensionalVector(-12, 12, -8);

            TridimensionalVector actual = firstVector - secondVector;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Multiplication_ByScalar_PositiveScalar()
        {
            TridimensionalVector firstVector = new TridimensionalVector(1, 2, -5);
            float scalar = 3;
            TridimensionalVector expected = new TridimensionalVector(3, 6, -15);

            TridimensionalVector actual = firstVector * scalar;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Multiplication_ByScalar_NegativeScalar()
        {
            TridimensionalVector firstVector = new TridimensionalVector(1, 2, -5);
            float scalar = -2;
            TridimensionalVector expected = new TridimensionalVector(-2, -4, 10);

            TridimensionalVector actual = firstVector * scalar;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Multiplication_Vectors()
        {
            TridimensionalVector firstVector = new TridimensionalVector(1, 2, -5);
            TridimensionalVector secondVector = new TridimensionalVector(4, 8, 1);
            float expected = 15;

            float actual = firstVector * secondVector;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Equal_TrueReturned()
        {
            TridimensionalVector firstVector = new TridimensionalVector(5, 9, -10);
            TridimensionalVector secondVector = new TridimensionalVector(5, 9, -10);
            bool expected = true;

            bool actual = firstVector == secondVector;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Equal_FalseReturned()
        {
            TridimensionalVector firstVector = new TridimensionalVector(5, 9, -10);
            TridimensionalVector secondVector = new TridimensionalVector(5, 10, -10);
            bool expected = false;

            bool actual = firstVector == secondVector;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NotEqual_TrueReturned()
        {
            TridimensionalVector firstVector = new TridimensionalVector(5, 9, -10);
            TridimensionalVector secondVector = new TridimensionalVector(5, 10, -10);
            bool expected = true;

            bool actual = firstVector != secondVector;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NotEqual_FalseReturned()
        {
            TridimensionalVector firstVector = new TridimensionalVector(5, 9, -10);
            TridimensionalVector secondVector = new TridimensionalVector(5, 9, -10);
            bool expected = false;

            bool actual = firstVector != secondVector;

            Assert.AreEqual(expected, actual);
        }


    }
}
