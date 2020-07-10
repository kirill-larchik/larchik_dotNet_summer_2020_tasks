using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FigureClassLibrary.Objects;

namespace FigureUnitTestProject
{
    /// <summary>
    /// Класс для тестирования функционала прямоугольника
    /// </summary>
    [TestClass]
    public class RectangleUnitTest
    {
        /// <summary>
        /// Тестирование вычисления площади по сторонам;
        /// </summary>
        [TestMethod]
        public void GetS_Sides()
        {
            uint leftSide = 10;
            uint rightSide = 10;
            uint topSide = 12;
            uint bottomSide = 12;
            double expected = 120;

            Rectangle rectangle = new Rectangle(leftSide, rightSide, topSide, bottomSide);
            double actual = rectangle.GetS();

            Assert.IsTrue(expected == actual);
        }

        /// <summary>
        /// Тестирование вычисления периметра по сторонам;
        /// </summary>
        [TestMethod]
        public void GetP_Sides()
        {
            uint leftSide = 10;
            uint rightSide = 10;
            uint topSide = 12;
            uint bottomSide = 12;
            double expected = 44;

            Rectangle rectangle = new Rectangle(leftSide, rightSide, topSide, bottomSide);
            double actual = rectangle.GetP();

            Assert.IsTrue(expected == actual);
        }

        /// <summary>
        /// Тестирование вычисления площади по вершинам фигуры;
        /// </summary>
        [TestMethod]
        public void GetS_Points()
        {
            int[] lowerLeftPoint = new int[] { 0, 0 };
            int[] lowerRightPoint = new int[] { 10, 0};
            int[] upperLeftPoint = new int[] { 0, 6 };
            int[] upperRightPoint = new int[] { 10, 6 };
            double expected = 60;

            Rectangle rectangle = new Rectangle(lowerLeftPoint, lowerRightPoint, upperLeftPoint, upperRightPoint);
            double actual = rectangle.GetS();

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
            int[] upperLeftPoint = new int[] { 0, 6 };
            int[] upperRightPoint = new int[] { 10, 6 };
            double expected = 32;

            Rectangle rectangle = new Rectangle(lowerLeftPoint, lowerRightPoint, upperLeftPoint, upperRightPoint);
            double actual = rectangle.GetP();

            Assert.IsTrue(expected == actual);
        }

        /// <summary>
        /// Проверка на целостность фигуры;
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CheckFigure()
        {
            uint leftSide = 10;
            uint rightSide = 10;
            uint topSide = 12;
            uint bottomSide = 100;

            Rectangle rectangle = new Rectangle(leftSide, rightSide, topSide, bottomSide);
        }

        /// <summary>
        /// Метод сравнения фигур;
        /// </summary>
        [TestMethod]
        public void CompareFigure_TrueReturned()
        {
            uint leftSide = 10;
            uint rightSide = 10;
            uint topSide = 12;
            uint bottomSide = 12;

            Rectangle firstRectangle = new Rectangle(leftSide, rightSide, topSide, bottomSide);
            Rectangle secondRectangle = new Rectangle(leftSide, rightSide, topSide, bottomSide);

            Assert.IsTrue(firstRectangle.Equals(secondRectangle));
        }

        /// <summary>
        /// Метод сравнения фигур;
        /// </summary>
        [TestMethod]
        public void CompareFigure_FalseReturned()
        {
            uint leftSide = 10;
            uint rightSide = 10;
            uint topSide = 12;
            uint bottomSide = 12;

            Rectangle firstRectangle = new Rectangle(leftSide, rightSide, topSide, bottomSide);
            Rectangle secondRectangle = new Rectangle(leftSide, rightSide, 28, 28);

            Assert.IsFalse(firstRectangle.Equals(secondRectangle));
        }
    }
}
