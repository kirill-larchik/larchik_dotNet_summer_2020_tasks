using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FigureClassLibrary.Objects
{
    /// <summary>
    /// Фигура "Прямоугольник".
    /// </summary>
    public class Rectangle : Figure
    {
        // Левая сторона.
        private uint leftSide;
        // Правая сторона.
        private uint rightSide;
        // Верхняя сторона.
        private uint topSide;
        // Нижняя сторона.
        private uint bottomSide;

        /// <summary>
        /// Конструктор прямоугольника с длинами сторон.
        /// </summary>
        /// <param name="leftSide"></param>
        /// <param name="rightSide"></param>
        /// <param name="topSide"></param>
        /// <param name="bottomSide"></param>
        public Rectangle(uint leftSide, uint rightSide, uint topSide, uint bottomSide)
        {
            Name = "Прямоугольник";

            this.leftSide = leftSide;
            this.rightSide = rightSide;
            this.topSide = topSide;
            this.bottomSide = bottomSide;

            CheckFigure();
        }

        /// <summary>
        /// Конструктор прямоугольника с координатами вершин.
        /// </summary>
        /// <param name="lowerLeftPoint"></param>
        /// <param name="lowerRightpoint"></param>
        /// <param name="upperLeftPoint"></param>
        /// <param name="upperRightPoint"></param>
        public Rectangle(int[] lowerLeftPoint, int[] lowerRightpoint, int[] upperLeftPoint, int[] upperRightPoint) 
        {
            Name = "Прямоугольник";

            // Высчитываю стороны.
            leftSide = (uint)Math.Abs(upperLeftPoint[1] - lowerLeftPoint[1]);
            rightSide = (uint)Math.Abs(upperRightPoint[1] - lowerRightpoint[1]);
            topSide = (uint)Math.Abs(upperRightPoint[0] - upperLeftPoint[0]);
            bottomSide = (uint)Math.Abs(lowerRightpoint[0] - lowerLeftPoint[0]);

            CheckFigure();
        }

        /// <summary>
        /// Проверка фигуры на целостность данных.
        /// </summary>
        /// <returns></returns>
        private void CheckFigure()
        {
            if (topSide != bottomSide || leftSide != rightSide)
                throw new Exception("Неккоректные исходные данные.");
        }

        /// <summary>
        /// Высчитывание периметра прямоугольника;
        /// </summary>
        /// <returns></returns>
        public override double GetP()
        {
            return leftSide + rightSide + topSide + bottomSide;
        }

        /// <summary>
        /// Высчитывание площади прямоугольника;
        /// </summary>
        /// <returns></returns>
        public override double GetS()
        {
            return leftSide * topSide;
        }

        /// <summary>
        /// Вывод информации о фигуре;
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Фигура: {Name}; длины сторон {leftSide}, {topSide}, {rightSide}, {bottomSide}; периметр: {GetP()}; площадь: {GetS()};\n";
        }

        /// <summary>
        /// Сравнение двух прямоугольников на равенство.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return obj is Rectangle rectangle &&
                   leftSide == rectangle.leftSide &&
                   rightSide == rectangle.rightSide &&
                   topSide == rectangle.topSide &&
                   bottomSide == rectangle.bottomSide;
        }

        /// <summary>
        /// Возвращает хэш-код для текущего прямоугольника
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            int hashCode = 611975097;
            hashCode = hashCode * -1521134295 + leftSide.GetHashCode();
            hashCode = hashCode * -1521134295 + rightSide.GetHashCode();
            hashCode = hashCode * -1521134295 + topSide.GetHashCode();
            hashCode = hashCode * -1521134295 + bottomSide.GetHashCode();
            return hashCode;
        }
    }
}
