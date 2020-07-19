using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShopProductsClassLibrary
{
    /// <summary>
    /// Класс, описывающий процессор как вид товара.
    /// </summary>
    public class Processor : Product
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса Processor, который задается наименованием и ценой товара.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="cost"></param>
        public Processor(string name, double cost)
            : base(name, cost)
        { }

        /// <summary>
        /// Возвращает новый товар, путем слияния двух товаров категории Processor.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns>Новый товар категории Processor</returns>
        public static Processor operator +(Processor left, Processor right)
        {
            string name = left.Name + " - " + right.Name;
            double cost = (left.Cost + right.Cost) / 2;

            return new Processor(name, cost);
        }

        /// <summary>
        /// Приведение типа VideoCard к Processors.  
        /// </summary>
        /// <param name="videoCard">Экземпляр класса VideoCard.</param>
        public static explicit operator Processor(VideoСard videoCard)
        {
            return new Processor(videoCard.Name, videoCard.Cost);
        }
    }
}
