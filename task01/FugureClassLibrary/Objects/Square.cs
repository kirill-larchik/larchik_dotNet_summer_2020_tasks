using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureClassLibrary.Objects
{
    /// <summary>
    /// Фигура "Квадрат"
    /// </summary>
    public class Square : Figure
    {
        // Длина стороны квадрата
        private uint side;

        /// <summary>
        /// Конструктор квадрата с длиной стороны
        /// </summary>
        /// <param name="side"></param>
        public Square(uint side)
        {
            Name = "Квадрат";

            this.side = side;
        }

        /// <summary>
        /// Конструктор квадрата с координатами вершин
        /// </summary>
        /// <param name="lowerLeftPoint"></param>
        /// <param name="lowerRightpoint"></param>
        /// <param name="upperLeftPoint"></param>
        /// <param name="upperRightPoint"></param>
        public Square(int[] lowerLeftPoint, int[] lowerRightpoint, int[] upperLeftPoint, int[] upperRightPoint)
        {
            Name = "Квадрат";

            // Высчитываю стороны.
            uint leftSide = (uint)Math.Abs(upperLeftPoint[1] - lowerLeftPoint[1]);
            uint rightSide = (uint)Math.Abs(upperRightPoint[1] - lowerRightpoint[1]);
            uint topSide = (uint)Math.Abs(upperRightPoint[0] - upperLeftPoint[0]);
            uint bottomSide = (uint)Math.Abs(lowerRightpoint[0] - lowerLeftPoint[0]);

            // Проверка на целостность фигуры.
            if (!(leftSide == rightSide && rightSide == topSide && topSide == bottomSide && bottomSide == leftSide))
                throw new Exception();

            side = leftSide;
        }

        /// <summary>
        /// Высчитывание периметра квадрата;
        /// </summary>
        /// <returns></returns>
        public override double GetP()
        {
            return 4 * side;
        }

        /// <summary>
        /// Высчитывание площади квадрата;
        /// </summary>
        /// <returns></returns>
        public override double GetS()
        {
            return side * side;
        }

        /// <summary>
        /// Вывод информации о фигуре;
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Фигура: {Name}; длины сторон {side}; периметр: {GetP()}; площадь: {GetS()};\n";
        }

        /// <summary>
        /// Сравнение двух квадратов на равенство.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return obj is Square square &&
                   side == square.side;
        }

        /// <summary>
        /// Возвращает хэш-код для текущего прямоугольника
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return -1721478386 + side.GetHashCode();
        }
    }
}
