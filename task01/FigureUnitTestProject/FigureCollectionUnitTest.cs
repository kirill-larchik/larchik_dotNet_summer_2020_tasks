using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FigureClassLibrary;
using System.IO;
using FigureClassLibrary.Objects;

namespace FigureUnitTestProject
{
    /// <summary>
    /// Класс для тестирования класса FigureCollection
    /// </summary>
    [TestClass]
    public class FigureCollectionUnitTest
    {
        /// <summary>
        /// Метод тестирования чтения из файла.
        /// </summary>
        [TestMethod]
        public void ReadFile()
        {
            string stringPath = Directory.GetCurrentDirectory() + @"\Files\firstFile.txt";
            Figure[] figures = new Figure[]
            {
                new Rectangle(1, 1, 3, 3),
                new Square(4),
                new Rectangle(3, 3, 4, 4),
                new Square(4),
                new Rectangle(3, 3, 4, 4)
            };

            FigureCollection figureCollection = new FigureCollection();
            figureCollection.ReadFile(stringPath);

            CollectionAssert.AreEqual(figures, figureCollection.GetFigures);
        }

        /// <summary>
        /// Метод тестирования чтения из файла с исключением на неккоректность исходных данных.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception), "Неккоректные исходные данные.")]
        public void ReadFile_FirstExeption()
        {
            string stringPath = Directory.GetCurrentDirectory() + @"\Files\secondFile.txt";
            Figure[] figures = new Figure[]
            {
                new Rectangle(1, 1, 3, 3),
                new Square(4),
                new Rectangle(3, 3, 4, 4),
                new Square(4)
            };

            FigureCollection figureCollection = new FigureCollection();
            figureCollection.ReadFile(stringPath);

            CollectionAssert.AreEqual(figures, figureCollection.GetFigures);
        }

        /// <summary>
        /// Метод тестирования чтения из файла с исключением на целостность исходных данных.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception), "Ошибка при считывании данных. Проверьте корректность ввода исходных данных.")]
        public void ReadFile_SecondExeption()
        {
            string stringPath = Directory.GetCurrentDirectory() + @"\Files\thirdFile.txt";
            Figure[] figures = new Figure[]
            {
                new Rectangle(1, 1, 3, 3),
                new Square(4),
                new Rectangle(3, 3, 4, 4),
                new Square(4)
            };

            FigureCollection figureCollection = new FigureCollection();
            figureCollection.ReadFile(stringPath);

            CollectionAssert.AreEqual(figures, figureCollection.GetFigures);
        }

        /// <summary>
        /// Метод тестирования формирования массива массива фигур, равных заданной.
        /// </summary>
        [TestMethod]
        public void GetEqualFigures()
        {
            Rectangle rectangle = new Rectangle(3, 3, 4, 4);
            Figure[] expected = new Figure[]
            {
                rectangle,
                rectangle,
            };


            string stringPath = Directory.GetCurrentDirectory() + @"\Files\firstFile.txt";
            Figure[] figures = new Figure[]
            {
                new Rectangle(1, 1, 3, 3),
                new Square(4),
                new Rectangle(3, 3, 4, 4),
                new Square(4),
                new Rectangle(3, 3, 4, 4)
            };

            FigureCollection figureCollection = new FigureCollection();
            figureCollection.ReadFile(stringPath);
            Figure[] actual = figureCollection.GetEqualFigures(figures[2]);


            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
