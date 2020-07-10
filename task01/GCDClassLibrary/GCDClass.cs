using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        // Необходимо для работы перегруженных методов после изменения метода вычисления НОД двух целых чисел.
        TimeSpan time;

        /// <summary>
        /// Метод, реализующий алгоритм Евклида для нахождения НОД двух целых чисел.
        /// </summary>
        /// <param name="firstNumber"></param>
        /// <param name="secondNumber"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public int GetGDC(int firstNumber, int secondNumber, out TimeSpan time)
        {
            // Запуск таймера
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

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

            // Остановка таймера
            stopwatch.Stop();
            time = stopwatch.Elapsed;

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
            int tempNumber = GetGDC(firstNumber, secondNumber, out time);
            return GetGDC(tempNumber, thirdNumber, out time);
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
            return GetGDC(tempNumber, fourthNumber, out time);
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
            return GetGDC(tempNumber, fifthNumber, out time);
        }

        /// <summary>
        /// Метод, реализующий  алгоритм Стейна для нахождения НОД двух целых чисел с таймером.
        /// </summary>
        /// <param name="firstNumber"></param>
        /// <param name="secondNumber"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public uint GetBinaryGDC(uint firstNumber, uint secondNumber, out TimeSpan time)
        {
            // Запуск таймера
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            int shift = 0;

            if (firstNumber == 0 || secondNumber == 0)
            {
                stopwatch.Stop();
                time = stopwatch.Elapsed;
                if (firstNumber == 0)
                    return secondNumber;
                else
                    return firstNumber;
            }

            while (((firstNumber | secondNumber) & 1u) == 0)
            {
                shift++;
                firstNumber >>= 1;
                secondNumber >>= 1;
            }

            while ((firstNumber & 1u) == 0)
                firstNumber >>= 1;

            do
            {
                while ((secondNumber & 1u) == 0)
                    secondNumber >>= 1;
                if (firstNumber > secondNumber)
                {
                    uint temp = firstNumber;
                    firstNumber = secondNumber;
                    secondNumber = temp;
                }

                secondNumber -= firstNumber;
            }
            while (secondNumber != 0);
            firstNumber <<= shift;

            // Остановка таймера
            stopwatch.Stop();
            time = stopwatch.Elapsed;

            return firstNumber;
        }

        /// <summary>
        /// Метод вовзращает данные, данные для построения гистограммы, сравнивающей время нахождения решения каждым из методов. Первый элемент массива - время алгоритма Евклида, второй - время алгоритма Стейна.
        /// </summary>
        /// <returns></returns>
        public TimeSpan[] GetTimesData(int firstNumber, int secondNumber)
        {
            TimeSpan[] times = new TimeSpan[2];
            GetGDC(firstNumber, secondNumber, out times[0]);
            GetBinaryGDC((uint)firstNumber, (uint)secondNumber, out times[1]);
            return times;
        }
    }
}
