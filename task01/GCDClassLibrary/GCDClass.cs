using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCDClassLibrary
{
    /// <summary>
    /// Класс, опысывающий методы для нахождения НОД.
    /// </summary>
    public class GCDClass
    {
        /// <summary>
        /// Метод, реализующий алгоритм Евклида для нахождения НОД двух целых чисел.
        /// </summary>
        /// <param name="firstNumber"></param>
        /// <param name="secondNumber"></param>
        /// <returns></returns>
        public int GetGDC(int firstNumber, int secondNumber)
        {
            while (firstNumber != secondNumber)
            {
                if (firstNumber > secondNumber)
                    firstNumber -= secondNumber;
                else
                    secondNumber -= firstNumber;
            }

            return firstNumber;
        }
    }
}
