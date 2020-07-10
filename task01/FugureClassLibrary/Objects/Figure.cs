using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureClassLibrary.Objects
{
    /// <summary>
    /// Абстрактный класс фигуры.
    /// </summary>
    public abstract class Figure
    {
        /// <summary>
        /// Название фигуры.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Метод вычисления площади фигуры.
        /// </summary>
        /// <returns></returns>
        public abstract double GetS();

        /// <summary>
        /// Метод вычисления периметра фигуры.
        /// </summary>
        /// <returns></returns>
        public abstract double GetP();
    }
}
