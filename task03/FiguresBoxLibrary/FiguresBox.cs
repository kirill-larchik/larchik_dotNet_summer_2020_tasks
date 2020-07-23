using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FiguresLibrary.Interfaces;
using FiguresBoxLibrary.Xml;
using System.IO;
using System.Xml;

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
        /// Возвращает фигуру коробки.
        /// </summary>
        /// <param name="index">Индекс элемента массива.</param>
        /// <returns></returns>
        public IFigure this[int index]
        {
            get
            {
                return figuresBox[index]; 
            }
            set
            {
                figuresBox[index] = value;
            }
        }

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
    }
}
