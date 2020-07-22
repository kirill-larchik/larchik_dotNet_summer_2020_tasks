using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiguresLibrary.Interfaces
{
    /// <summary>
    /// Интерфейс описывает прямоугольник.
    /// </summary>
    public interface ICircle : IFigure
    {
        /// <summary>
        /// Диаметр фигуры.
        /// </summary>
        int Diameter { get; set; }
        /// <summary>
        /// Радиус фигуры.
        /// </summary>
        int Radius { get; set; }
    }
}
