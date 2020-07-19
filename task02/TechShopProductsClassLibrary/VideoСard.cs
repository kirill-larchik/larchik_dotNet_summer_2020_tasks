using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShopProductsClassLibrary
{
    /// <summary>
    /// Класс, описывающий видеокарту как вид товара.
    /// </summary>
    public class VideoСard : Product
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса VideoСard, который задается наименованием и ценой товара.
        /// </summary>
        /// <param name="name">Наименование товара</param>
        /// <param name="cost">Цена товара</param>
        public VideoСard(string name, double cost) 
            : base(name, cost)
        { }

        /// <summary>
        /// Возвращает новый товар, путем слияния двух товаров категории VideoCard.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns>Новый товар категории VideoCard</returns>
        public static VideoСard operator +(VideoСard left, VideoСard right)
        {
            string name = left.Name + " - " + right.Name;
            double cost = (left.Cost + right.Cost) / 2;

            return new VideoСard(name, cost);
        }

        /// <summary>
        /// Приведение типа Processor к VideoCard.  
        /// </summary>
        /// <param name="processor">Экземпляр класса Processor.</param>
        public static explicit operator VideoСard(Processor processor)
        {
            return new VideoСard(processor.Name, processor.Cost);
        }
    }
}
