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
            if (firstNumber < 0 || secondNumber < 0)
            {
                firstNumber = Math.Abs(firstNumber);
                secondNumber = Math.Abs(secondNumber);
            }
            
            while (firstNumber != secondNumber)
            {
                if (firstNumber > secondNumber)
                    firstNumber -= secondNumber;
                else
                    secondNumber -= firstNumber;
            }

            return firstNumber;
        }

        /// <summary>
        /// Перегруженный метод для нахождения НОД трёх целых чисел.
        /// </summary>
        /// <param name="firstNumber"></param>
        /// <param name="secondNumber"></param>
        /// <param name="thirdNumber"></param>
        /// <returns></returns>
        public int GetGDC(int firstNumber, int secondNumber, int thirdNumber)
        {
            int tempNumber = GetGDC(firstNumber, secondNumber);
            return GetGDC(tempNumber, thirdNumber);
        }

        /// <summary>
        /// Перегруженный метод для нахождения НОД четырёх целых чисел.
        /// </summary>
        /// <param name="firstNumber"></param>
        /// <param name="secondNumber"></param>
        /// <param name="thirdNumber"></param>
        /// <param name="fourthNumber"></param>
        /// <returns></returns>
        public int GetGDC(int firstNumber, int secondNumber, int thirdNumber, int fourthNumber)
        {
            int tempNumber = GetGDC(firstNumber, secondNumber, thirdNumber);
            return GetGDC(tempNumber, fourthNumber);
        }

        /// <summary>
        /// Перегруженный метод для нахождения НОД четырёх целых чисел.
        /// </summary>
        /// <param name="firstNumber"></param>
        /// <param name="secondNumber"></param>
        /// <param name="thirdNumber"></param>
        /// <param name="fourthNumber"></param>
        /// <param name="fifthNumber"></param>
        /// <returns></returns>
        public int GetGDC(int firstNumber, int secondNumber, int thirdNumber, int fourthNumber, int fifthNumber)
        {
            int tempNumber = GetGDC(firstNumber, secondNumber, thirdNumber, fourthNumber);
            return GetGDC(tempNumber, fifthNumber);
        }
    }
}
