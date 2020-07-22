using FiguresLibrary.Interfaces;
using SheetsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiguresLibrary.FilmFigures
{
    /// <summary>
    /// Класс, описывающий пленочный круг.
    /// </summary>
    public class FilmCircle : FilmSheet, ICircle
    {
        /// <summary>
        /// Диаметр.
        /// </summary>
        public int Diameter { get; set; }
        /// <summary>
        /// Радиус.
        /// </summary>
        public int Radius { get; set; }

        /// <summary>
        /// Инициализирует экземпляр класса PaperCircle, который задается радиусом.
        /// </summary>
        /// <param name="radius">Радиус фигуры.</param>
        public FilmCircle(int radius)
        {
            Radius = radius;
            Diameter = 2 * radius;
        }

        /// <summary>
        /// Возвращает периметр круга.
        /// </summary>
        /// <returns></returns>
        public double GetP()
        {
            return 2 * Math.PI * Radius;
        }

        /// <summary>
        /// Возвращает площадь круга.
        /// </summary>
        /// <returns></returns>
        public double GetS()
        {
            return Math.PI * Radius * Radius;
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса PaperCircle путем вырезания из другой фигуры
        /// (фигуру можно  перевернуть).
        /// </summary>
        /// <param name="radius">Радиус фигуры</param>
        /// <param name="figure">Фигура, из которой необходимо вырезать.</param>
        public FilmCircle(int radius, IFigure figure)
        {
            if (GetType() != figure.GetType())
                throw new Exception("Нельзя вырезать из фигуры другого материала.");

            Radius = radius;
            Diameter = 2 * Radius;

            if (figure.GetS() < GetS())
                throw new Exception("Заданная фигура больше предыдущей.");
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("Фигура: круг, материал: пленка, ");
            stringBuilder.Append("площадь: ");
            stringBuilder.Append(GetS());
            stringBuilder.Append("периметр: ");
            stringBuilder.Append(GetP());
            stringBuilder.Append(";\n");

            return stringBuilder.ToString();
        }

        public override bool Equals(object obj)
        {
            return obj is FilmCircle circle &&
                   Diameter == circle.Diameter &&
                   Radius == circle.Radius;
        }

        public override int GetHashCode()
        {
            int hashCode = 2056850621;
            hashCode = hashCode * -1521134295 + Diameter.GetHashCode();
            hashCode = hashCode * -1521134295 + Radius.GetHashCode();
            return hashCode;
        }
    }
}
