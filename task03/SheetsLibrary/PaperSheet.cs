using ColorsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SheetsLibrary
{
    /// <summary>
    /// Абстрактный класс, описывающий лист бумаги.
    /// </summary>
    public abstract class PaperSheet : Sheet
    {
        /// <summary>
        /// Инициализирует экземпляр класса PaperSheet с белым цветом по умолчанию.
        /// </summary>
        public PaperSheet()
        {
            color = Color.White;
        }

        /// <summary>
        /// Меняет текущий цвет листа бумаги на новый.
        /// </summary>
        /// <param name="color">Новый цвет.</param>
        public override void ChangeColor(Color color)
        {
            if (IsDrawn == false)
            {
                this.color = color;
                IsDrawn = true;
            }
            else
                throw new Exception("Лист бумаги можно красить только один раз.");
        }
    }
}
