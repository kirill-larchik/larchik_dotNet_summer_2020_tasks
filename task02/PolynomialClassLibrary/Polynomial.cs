using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace PolynomialClassLibrary
{
    /// <summary>
    /// Класс, описывающий многочлен от одной переменной.
    /// </summary>
    public class Polynomial
    {
        int[] coefficients;

        /// <summary>
        /// Инициализирует новый экземпляр класса Polynomal, который задается коэффициентами (an...a0)
        /// в стандартном виде.
        /// </summary>
        /// <param name="coefficients">Коэффициенты (an...a0).</param>
        public Polynomial(params int[] coefficients)
        {
            // Если коэффициент старшей степени = 0.
            if (coefficients[0] == 0)
                throw new Exception("Коэффициент старшей степени не может равняться нулю.");

            this.coefficients = coefficients;
        }

        /// <summary>
        /// Индексатор многочлена. Возвращает значение коэффициента по индексу.
        /// </summary>
        /// <param name="index">Индекс коэффициента.</param>
        /// <returns>Значение коэффициента</returns>
        public int this[int index]
        {
            get
            {
                return coefficients[index];
            }
            set
            {
                coefficients[index] = value;
            }
        }

        /// <summary>
        /// Длина массива коэффициентов.
        /// </summary>
        public int Length { get { return coefficients.Length; } }

        /// <summary>
        /// Возвращает многочлен - результат суммы двух заданных многочленов.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns>Многочлен - результат суммы двух заданных многочленов</returns>
        public static Polynomial operator +(Polynomial left, Polynomial right)
        {
            int[] tempCoefficients;

            if (left.Length > right.Length)
                tempCoefficients = GetTempCofficients(left, right, "+");
            else
                tempCoefficients = GetTempCofficients(right, left, "+");

            return new Polynomial(tempCoefficients);
        }

        /// <summary>
        /// Возвращает многочлен - результат разности двух заданных многочленов.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns>Многочлен - результат разности двух заданных многочленов.</returns>
        public static Polynomial operator -(Polynomial left, Polynomial right)
        {
            int[] tempCoefficients;

            if (left.Length > right.Length)
                tempCoefficients = GetTempCofficients(left, right, "-");
            else
                tempCoefficients = GetTempCofficients(right, left, "-");

            return new Polynomial(tempCoefficients);
        }

        /// <summary>
        /// Возвращает массив коэффициентов, необходимых для операций "+" и "-".
        /// </summary>
        /// <param name="left">Многочлен с большей степенью.</param>
        /// <param name="right">Многочлен с меньшей степенью.</param>
        /// <param name="operatorString">Строка-параметр. Принимает "+" или "-".</param>
        /// <returns>Массив коэффициентов</returns>
        private static int[] GetTempCofficients(Polynomial left, Polynomial right, string operatorString)
        {
            if (operatorString != "+" && operatorString != "-")
                throw new Exception("Введен неверный параметр.");

            // Создается массив с наибольшим количеством коэффициентов.
            int[] tempCoefficients = new int[left.Length];

            // Если строка-параметр принимает "+", то коэффциценты с одинаковой степенью суммируются, иначе - вычитаются.
            if(operatorString == "+")
            {
                for (int i = 0; i < right.Length; i++)
                    tempCoefficients[left.Length - 1 - i] = left[left.Length - 1 - i] + right[i];
            }
            else
            {
                for (int i = 0; i < right.Length; i++)
                    tempCoefficients[left.Length - 1 - i] = left[left.Length - 1 - i] + right[i];
            }

            // Заполнение массива уникальными коэффициентами.
            for (int i = 0; i < left.Length - right.Length; i++)
                tempCoefficients[i] = left[i];

            return tempCoefficients;
        }

        /// <summary>
        /// Возвращает многочлен - результат произведения двух заданных многочленов.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns>Результат произведения двух заданных многочленов</returns>
        public static Polynomial operator *(Polynomial left, Polynomial right)
        {
            int[] tempCoefficients = new int[left.Length + right.Length - 1];

            for (int i = 0; i < tempCoefficients.Length; i++)
                tempCoefficients[i] = 0;

            for(int i = 0; i < left.Length; i++)
            {
                for (int j = 0; j < right.Length; j++)
                    tempCoefficients[i + j] = left[i] * right[j];
            }

            return new Polynomial(tempCoefficients);
        }

        /// <summary>
        /// Сравнивает два многочлена. Возвращает true, если заданные многочлены равны, иначе - false.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns>Возвращает true, если заданные многочлены равны, иначе - false.</returns>
        public static bool operator ==(Polynomial left, Polynomial right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Сравнивает два многочлена. Возвращает true, если заданные многочлены не равны, иначе - false.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns>Возвращает true, если заданные многочлены не равны, иначе - false.</returns>
        public static bool operator !=(Polynomial left, Polynomial right)
        {
            return !left.Equals(right);
        }

        public override bool Equals(object obj)
        {
            return obj is Polynomial && GetHashCode() == obj.GetHashCode();
        }

        public override int GetHashCode()
        {
            int hashCode = 0;
            for (int i = 0; i < Length; i++)
                hashCode += i.GetHashCode();
            return hashCode;
        }
    }
}
