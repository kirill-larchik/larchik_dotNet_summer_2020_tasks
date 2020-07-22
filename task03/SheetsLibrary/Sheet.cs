using ColorsLibrary;

namespace SheetsLibrary
{
    /// <summary>
    /// Абстрактный класс, описывающий лист.
    /// </summary>
    public abstract class Sheet
    {
        /// <summary>
        /// Содержит цвет листа.
        /// </summary>
        protected Color color;

        /// <summary>
        /// Возвращает цвет листа.
        /// </summary>
        public Color GetColor { get { return color; } }

        /// <summary>
        /// Содержит статус рисовки листа.
        /// </summary>
        public bool IsDrawn { get; protected set; }

        /// <summary>
        /// Инициализирует экземпляр класса Sheet.
        /// </summary>
        public Sheet()
        {
            IsDrawn = false;
        }

        /// <summary>
        /// Меняет текущий цвет листа на новый.
        /// </summary>
        /// <param name="color">Новый цвет.</param>
        public abstract void ChangeColor(Color color);
    }
}
