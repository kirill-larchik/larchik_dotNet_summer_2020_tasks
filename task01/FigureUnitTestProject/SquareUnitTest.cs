using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FigureClassLibrary.Objects;

namespace FigureUnitTestProject
{
    /// <summary>
    /// Класс для тестирования функционала квадрата
    /// </summary>
    [TestClass]
    public class SquareUnitTest
    {
        /// <summary>
        /// Тестирование вычисления площади по сторонам;
        /// </summary>
        [TestMethod]
        public void GetS_Sides()
        {
            uint side = 10;
            double expected = 100;

            Square square = new Square(side);
            double actual = square.GetS();

            Assert.IsTrue(expected == actual);
        }

        /// <summary>
        /// Тестирование вычисления периметра по сторонам;
        /// </summary>
        [TestMethod]
        public void GetP_Sides()
        {
            uint side = 10;
            double expected = 40;

            Square square = new Square(side);
            double actual = square.GetP();

            Assert.IsTrue(expected == actual);
        }

        /// <summary>
        /// Тестирование вычисления площади по вершинам фигуры;
        /// </summary>
        [TestMethod]
        public void GetS_Points()
        {
            int[] lowerLeftPoint = new int[] { 0, 0 };
            int[] lowerRightPoint = new int[] { 10, 0 };
            int[] upperLeftPoint = new int[] { 0, 10 };
            int[] upperRightPoint = new int[] { 10, 10 };
            double expected = 100;

            Square square = new Square(lowerLeftPoint, lowerRightPoint, upperLeftPoint, upperRightPoint);
            double actual = square.GetS();

            Assert.IsTrue(expected == actual);
        }

        /// <summary>
        /// Тестирование вычисления периметра по вершинам фигуры;
        /// </summary>
        [TestMethod]
        public void GetP_Points()
        {
            int[] lowerLeftPoint = new int[] { 0, 0 };
            int[] lowerRightPoint = new int[] { 10, 0 };
            int[] upperLeftPoint = new int[] { 0, 10 };
            int[] upperRightPoint = new int[] { 10, 10 };
            double expected = 40;

            Square square = new Square(lowerLeftPoint, lowerRightPoint, upperLeftPoint, upperRightPoint);
            double actual = square.GetP();

            Assert.IsTrue(expected == actual);
        }

        /// <summary>
        /// Проверка на целостность фигуры;
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CheckFigure()
        {
            int[] lowerLeftPoint = new int[] { 0, 0 };
            int[] lowerRightPoint = new int[] { 10, 0 };
            int[] upperLeftPoint = new int[] { 0, 11 };
            int[] upperRightPoint = new int[] { 10, 10 };

            Square square = new Square(lowerLeftPoint, lowerRightPoint, upperLeftPoint, upperRightPoint);
        }

        /// <summary>
        /// Метод сравнения фигур;
        /// </summary>
        [TestMethod]
        public void CompareFigure_TrueReturned()
        {
            uint side = 10;

            Square firstSquare = new Square(side);
            Square secondSquare = new Square(side);

            Assert.IsTrue(firstSquare.Equals(secondSquare));
        }

        /// <summary>
        /// Метод сравнения фигур;
        /// </summary>
        [TestMethod]
        public void CompareFigure_FalseReturned()
        {
            uint side = 10;

            Square firstSquare = new Square(side);
            Square secondSquare = new Square(11);

            Assert.IsFalse(firstSquare.Equals(secondSquare));
        }
    }
}
