using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FiguresLibrary.Interfaces;
using FiguresBoxLibrary.Xml;
using System.IO;
using System.Xml;
using System.Net.Http.Headers;
using SheetsLibrary;

namespace FiguresBoxLibrary
{
    /// <summary>
    /// Класс, описывающий коробку фигур (размерность: 20 элементов).
    /// </summary>
    public class FiguresBox
    {
        IFigure[] figuresBox;

        /// <summary>
        /// Экземпляр класса для чтения xml-файла.
        /// </summary>
        private XmlReadOperation xmlRead;
        /// <summary>
        /// Экземпляр класса для записи xml-файла.
        /// </summary>
        private XmlWriteOperation xmlWrite;

        /// <summary>
        /// Размерность коробки.
        /// </summary>
        public int Length { get { return figuresBox.Length; } }

        /// <summary>
        /// Инициализирует коробку фигур.
        /// </summary>
        public FiguresBox()
        {
            figuresBox = new IFigure[20];

            // Так как коробка изначально пустая, заплняем значение null.
            for (int i = 0; i < Length; i++)
                figuresBox[i] = null;

            xmlRead = new XmlReadOperation();
            xmlWrite = new XmlWriteOperation();
        }

        /// <summary>
        /// Чтение XML-файла и сохранение фигур в коробку.
        /// </summary>
        /// <param name="filePath">Путь к файлу.</param>
        /// <param name="type">Тип метода.</param>
        public void ReadXmlFile(string filePath, XmlReadType type)
        {
            switch (type)
            {
                case XmlReadType.StreamReader:
                    figuresBox = xmlRead.ReadXmlWithStreamReader(filePath);
                    break;
                case XmlReadType.XmlReader:
                    figuresBox = xmlRead.ReadXmlWithXmlReader(filePath);
                    break;
            }
        }

        /// <summary>
        /// Сохранение фигур коробки в XML-файл.
        /// </summary>
        /// <param name="filePath">Путь к файлу.</param>
        /// <param name="figureWriteType">Режим сохранения фигур.</param>
        /// <param name="xmlWriteType">Тип метода.</param>
        public void WriteXmlFile(string filePath, XmlWriteType xmlWriteType, FigureWriteType figureWriteType)
        {
            switch (xmlWriteType)
            {
                case XmlWriteType.StreamWriter:
                    xmlWrite.WriteXmlFileWithStreamReader(filePath, figuresBox, figureWriteType);
                    break;
                case XmlWriteType.XmlWriter:
                    xmlWrite.WriteXmlFileWithXmlReader(filePath, figuresBox, figureWriteType);
                    break;
            }
        } 
        
        /// <summary>
        /// Добавляет заданную фигуру в коробку.
        /// </summary>
        /// <param name="figure">Заданная фигура.</param>
        public void AddFigure(IFigure figure)
        {
            bool flag = true;
            int position = -1;

            for (int i = 0; i < Length; i++)
            {
                if (figuresBox[i] != null && figuresBox[i].Equals(figure))
                    throw new Exception("Нельзя добавлять одинаковые фигуры.");

                if (figuresBox[i] == null && flag == true)
                {
                    position = i;
                    flag = false;
                }
            }

            figuresBox[position] = figure;
        }

        /// <summary>
        /// Показывает фигуру в коробке по номеру.
        /// </summary>
        /// <param name="index">Номер фигуры.</param>
        /// <returns></returns>
        public string ShowFigure(int index)
        {
            return figuresBox[index].ToString();
        }

        /// <summary>
        /// Извлекает или заменяет фигуру коробки по номеру.
        /// </summary>
        /// <param name="index">Индекс элемента массива.</param>
        /// <returns></returns>
        public IFigure this[int index]
        {
            get
            {
                IFigure figure = figuresBox[index];
                figuresBox[index] = null;
                return figure;
            }
            set
            {
                if (figuresBox[index] != null)
                    figuresBox[index] = value;
            }
        }

        /// <summary>
        /// Находит фигуру по заданному образцу.
        /// </summary>
        /// <param name="figure">Заданная фигура.</param>
        /// <returns></returns>
        public IFigure GetEqualFigure(IFigure figure)
        {
            for (int i = 0; i < Length; i++)
            {
                if (figuresBox[i].Equals(figure))
                    return figuresBox[i];
            }

            return null;
        }

        /// <summary>
        /// Возвращает наличное количество фигур.
        /// </summary>
        /// <returns></returns>
        public int GetAvailableFiguresCount()
        {
            int count = 0;

            for (int i = 0; i < Length; i++)
            {
                if (figuresBox[i] != null)
                    count++;
            }

            return count;
        }

        /// <summary>
        /// Возвращает суммарную площадь фигур.
        /// </summary>
        /// <returns></returns>
        public double GetTotalS()
        {
            double s = 0;

            for (int i = 0; i < Length; i++)
            {
                if (figuresBox[i] != null)
                    s += figuresBox[i].GetS();
            }

            return s;
        }

        /// <summary>
        /// Возвращает суммарнный периметр фигур.
        /// </summary>
        /// <returns></returns>
        public double GetTotalP()
        {
            double p = 0;

            for (int i = 0; i < Length; i++)
            {
                if (figuresBox[i] != null)
                    p += figuresBox[i].GetP();
            }

            return p;
        }

        /// <summary>
        /// Достает все круги.
        /// </summary>
        /// <returns>Массив кругов.</returns>
        public ICircle[] GetAllCircles()
        {
            int length = 0;
            for (int i = 0; i < Length; i++)
            {
                if (figuresBox[i] != null && figuresBox[i].GetType().GetInterfaces()[0] == typeof(ICircle))
                    length++;
            }

            ICircle[] circles = new ICircle[length];
            
            int index = 0;
            for (int i = 0; i < Length; i++)
            {
                if (figuresBox[i] != null && figuresBox[i].GetType().GetInterfaces()[0] == typeof(ICircle))
                {
                    circles[index] = (ICircle)this[i];
                    index++;
                }
            }

            return circles;
        }

        /// <summary>
        /// Достает все пленочные фигуры.
        /// </summary>
        /// <returns>Массив пленочных фигур.</returns>
        public IFigure[] GetAllFilmFigures()
        {
            int length = 0;
            for (int i = 0; i < Length; i++)
            {
                if (figuresBox[i] != null && figuresBox[i].GetType().BaseType == typeof(FilmSheet))
                    length++;
            }

            IFigure[] filmFigures = new IFigure[length];

            int index = 0;
            for (int i = 0; i < Length; i++)
            {
                if (figuresBox[i] != null && figuresBox[i].GetType().BaseType == typeof(FilmSheet))
                {
                    filmFigures[index] = this[i];
                    index++;
                }
            }

            return filmFigures;
        }

        public override bool Equals(object obj)
        {

            return obj is FiguresBox box &&
                   GetHashCode() == box.GetHashCode();
        }

        public override int GetHashCode()
        {
            int hashCode = 0;
            for (int i = 0; i < Length; i++)
            {
                if (figuresBox[i] != null)
                    hashCode += figuresBox[i].GetHashCode();
            }
            return hashCode;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Фигуры, содержащиеся в коробке:\n");
            for (int i = 0; i < Length; i++)
            {
                if (figuresBox[i] != null)
                {
                    stringBuilder.Append(figuresBox[i].ToString());
                }
            }

            return stringBuilder.ToString();
        }
    }
}
