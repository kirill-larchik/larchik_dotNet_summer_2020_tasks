using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShopProductsClassLibrary
{
    /// <summary>
    /// Абстрактный класс, описывающий товар. 
    /// </summary>
    public abstract class Product
    {
        /// <summary>
        /// Наименование товара.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Цена товара (руб).
        /// </summary>
        public double Cost { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса Product, который задается наименованием и ценой товара.
        /// </summary>
        /// <param name="name">Наименование товара.</param>
        /// <param name="cost">Цена товара.</param>
        public Product(string name, double cost)
        {
            Name = name;
            Cost = cost;
        }

        /// <summary>
        /// Преобразование типа Product в int (возвращается цена в копейках).
        /// </summary>
        /// <param name="product">Товар</param>
        public static explicit operator int(Product product)
        {
            return (int)(product.Cost * 100);
        }

        /// <summary>
        /// Преобразование типа Product в float (возвращается цена в копейках).
        /// </summary>
        /// <param name="product">Товар</param>
        public static explicit operator double(Product product)
        {
            return product.Cost;
        }

        public override bool Equals(object obj)
        {
            if (this.GetType() != obj.GetType())
                return false;

            return obj is Product product &&
                   Name == product.Name &&
                   Cost == product.Cost;
        }

        public override int GetHashCode()
        {
            int hashCode = -2002130610;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + Cost.GetHashCode();
            return hashCode;
        }
    }
}
