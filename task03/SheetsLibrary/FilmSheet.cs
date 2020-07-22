using ColorsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SheetsLibrary
{
    /// <summary>
    /// Абстрактный класс, описывающий лист пленки.
    /// </summary>
    public abstract class FilmSheet : Sheet
    {
        /// <summary>
        /// Инициализирует экземпляр класса FilmSheet без цвета по умолчанию.
        /// </summary>
        public FilmSheet()
        {
            color = Color.Colorless;
        }

        /// <summary>
        /// Меняет текущий цвет листа на новый.
        /// </summary>
        /// <param name="color"></param>
        public override void ChangeColor(Color color)
        {
            throw new Exception("Цвет листа пленки нельзя менять.");
        }
    }
}
