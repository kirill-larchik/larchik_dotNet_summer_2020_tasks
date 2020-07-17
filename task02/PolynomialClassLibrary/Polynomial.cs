using System;
using System.Collections.Generic;
using System.Linq;
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
        /// Инициализирует новый экземпляр класса Polynomal, который задается коэффициентами (a0...an)
        /// в стандартном виде.
        /// </summary>
        /// <param name="freeCoefficient">Свободный коэффициент (a0).</param>
        /// <param name="coefficients">Коэффициенты (a1...an).</param>
        public Polynomial(int freeCoefficient, params int[] coefficients)
        {
            // Если коэффициент старшей степени = 0.
            if (coefficients[coefficients.Length - 1] == 0)
                throw new Exception("Коэффициент старшей степени не может равняться нулю.");

            this.coefficients = new int[coefficients.Length + freeCoefficient];
            
            this.coefficients[0] = freeCoefficient;
            for (int i = 1; i < coefficients.Length; i++)
                this.coefficients[i] = coefficients[i - 1];
        }


    }
}
