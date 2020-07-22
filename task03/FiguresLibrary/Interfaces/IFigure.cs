using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiguresLibrary.Interfaces
{
    /// <summary>
    /// Интерфейс описывает фигуру.
    /// </summary>
    public interface IFigure
    {
        /// <summary>
        /// Возвращает периметр фигуры.
        /// </summary>
        /// <returns></returns>
        double GetP();
        /// <summary>
        /// Возвращает площадь фигуры.
        /// </summary>
        /// <returns></returns>
        double GetS();
    }
}
