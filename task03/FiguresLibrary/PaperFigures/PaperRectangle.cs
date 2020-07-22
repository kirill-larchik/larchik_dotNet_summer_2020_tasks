using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FiguresLibrary.Interfaces;
using SheetsLibrary;

namespace FiguresLibrary.PaperFigures
{
    /// <summary>
    /// Класс, описывающий бумажный прямоугольник.
    /// </summary>
    public class PaperRectangle : PaperSheet, IRectangle
    {
        /// <summary>
        /// Длина прямоугольника.
        /// </summary>
        public int Length { get; set; }
        /// <summary>
        /// Ширина прямоугольника.
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Инициализирует экземпляр класса PaperRectangle, который задается длиной и шириной фигуры.
        /// </summary>
        /// <param name="length">Длина фигуры.</param>
        /// <param name="width">Ширина фигуры.</param>
        public PaperRectangle(int length, int width)
        {
            Length = length;
            Width = width;
        }

        /// <summary>
        /// Возвращает периметр прямоугольника.
        /// </summary>
        /// <returns></returns>
        public double GetP()
        {
            return (Length + Width) * 2;
        }

        /// <summary>
        /// Возвращает площадь прямоугольника.
        /// </summary>
        /// <returns></returns>
        public double GetS()
        {
            return Length * Width;
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса PaperRectangle путем вырезания из другой фигуры
        /// (фигуру можно  перевернуть).
        /// </summary>
        /// <param name="length">Длина фигуры.</param>
        /// <param name="width">Ширина фигуры.</param>
        /// <param name="figure">Фигура, из которой необходимо вырезать.</param>
        public PaperRectangle(int length, int width, IFigure figure)
        {
            if (GetType() != figure.GetType())
                throw new Exception("Нельзя вырезать из фигуры другого материала.");

            Length = length;
            Width = width;

            if (figure.GetS() < GetS())
                throw new Exception("Заданная фигура больше предыдущей.");
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("Фигура: прямоугольник, материал: бумага, ");
            stringBuilder.Append("площадь: ");
            stringBuilder.Append(GetS());
            stringBuilder.Append("периметр: ");
            stringBuilder.Append(GetP());
            stringBuilder.Append(";\n");

            return stringBuilder.ToString();
        }

        public override bool Equals(object obj)
        {
            return obj is PaperRectangle rectangle &&
                   Length == rectangle.Length &&
                   Width == rectangle.Width;
        }

        public override int GetHashCode()
        {
            int hashCode = -1135836612;
            hashCode = hashCode * -1521134295 + Length.GetHashCode();
            hashCode = hashCode * -1521134295 + Width.GetHashCode();
            return hashCode;
        }
    }
}
