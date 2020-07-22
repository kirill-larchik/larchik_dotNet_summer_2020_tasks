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
    public interface IRectangle : IFigure
    {
        /// <summary>
        /// Длина прямоугольника.
        /// </summary>
        int Length { get; set; }
        /// <summary>
        /// Ширина прямоугольника.
        /// </summary>
        int Width { get; set; }
    }
}
