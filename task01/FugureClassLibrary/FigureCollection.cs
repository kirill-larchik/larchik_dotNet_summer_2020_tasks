using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FigureClassLibrary.Objects;

namespace FigureClassLibrary
{
    /// <summary>
    /// Класс, хранящий массив фигур и методы для взаимодействия с массивов.
    /// </summary>
    public class FigureCollection
    {
        Figure[] figures;
        
        /// <summary>
        /// Длина массива.
        /// </summary>
        public int GetLength { get { return figures.Length; } }

        /// <summary>
        /// Индексатор.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Figure this[int index]
        {
            get
            {
                return figures[index];
            }
            set
            {
                figures[index] = value;
            }
        }

        /// <summary>
        /// Получение массива.
        /// </summary>
        public Figure[] GetFigures { get { return figures; } }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        public FigureCollection()
        {
            figures = Array.Empty<Figure>();
        }

        /// <summary>
        /// Метод считывания данных из файла и сохранения их в массив.
        /// </summary>
        public void ReadFile(string filePath)
        {
            InitArray(filePath);

            using (StreamReader reader = new StreamReader(filePath))
            {
                int index = 0;
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] data = line.Split(' ');
                    
                    // Формирование данных.
                    // Имя фигуры.
                    string figureName = data[0];
                    // Длины сторон или координаты.
                    int[] parameters = new int[data.Length - 1];
                    for(int i = 0; i < parameters.Length; i++)
                    {
                        if (!int.TryParse(data[i + 1], out parameters[i]))
                            throw new Exception("Ошибка при считывании данных. Проверьте корректность ввода исходных данных.");
                    }

                    GetFigure(index++, figureName, parameters);
                }
            }
        }

        /// <summary>
        /// Метод инициализации массива.
        /// </summary>
        /// <param name="filePath"></param>
        private void InitArray(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                int count = 0;
                while (reader.ReadLine() != null)
                    count++;
                figures = new Figure[count];
            }
        }

        /// <summary>
        /// Метод создания фигуры и добавления её в массив;
        /// </summary>
        /// <param name="index"></param>
        /// <param name="figureName"></param>
        /// <param name="parameters"></param>
        private void GetFigure(int index, string figureName, params int[] parameters)
        {
            switch (figureName)
            {
                case "Rectangle":
                    figures[index] = GetRectangle(parameters);
                    break;
                case "Square":
                    figures[index] = GetSquare(parameters);
                    break;
                default:
                    throw new Exception("Ошибка при считывании данных. Проверьте корректность ввода исходных данных.");
            }
        }

        /// <summary>
        /// Метод создания прямоугольника.
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private Rectangle GetRectangle(params int[] parameters)
        {
            // Если длины сторон
            if (parameters.Length == 4)
                return new Rectangle((uint)parameters[0], (uint)parameters[1], (uint)parameters[2], (uint)parameters[3]);
            // Иначе координаты вершин
            else
            {
                int[] lowerLeftPoint = new int[] { parameters[0], parameters[1] };
                int[] lowerRightPoint = new int[] { parameters[2], parameters[3] };
                int[] upperLeftPoint = new int[] { parameters[4], parameters[5] };
                int[] upperRightPoint = new int[] { parameters[6], parameters[7] };
                return new Rectangle(lowerLeftPoint, lowerRightPoint, upperLeftPoint, upperRightPoint);
            }
        }

        private Square GetSquare(params int[] parameters)
        {
            // Если длины сторон
            if (parameters.Length == 1)
                return new Square((uint)parameters[0]);
            // Иначе координаты вершин
            else
            {
                int[] lowerLeftPoint = new int[] { parameters[0], parameters[1] };
                int[] lowerRightPoint = new int[] { parameters[2], parameters[3] };
                int[] upperLeftPoint = new int[] { parameters[4], parameters[5] };
                int[] upperRightPoint = new int[] { parameters[6], parameters[7] };
                return new Square(lowerLeftPoint, lowerRightPoint, upperLeftPoint, upperRightPoint);
            }
        }

        /// <summary>
        /// Метод формирования массива фигур, равных заданной.
        /// </summary>
        /// <param name="figure"></param>
        /// <returns></returns>
        public Figure[] GetEqualFigures(Figure figure)
        {
            int count = 0;
            for (int i = 0; i < GetLength; i++)
            {
                if (figure.Equals(figures[i]))
                    count++;
            }

            Figure[] equalFigures = new Figure[count];
            int index = 0;
            for (int i = 0; i < GetLength; i++)
            {
                if (figure.Equals(figures[i]))
                    equalFigures[index++] = figures[i];
            }

            return equalFigures;
        }
    }
}
