using FiguresLibrary.Interfaces;
using FiguresBoxLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using FiguresLibrary.PaperFigures;
using FiguresLibrary.FilmFigures;

namespace FiguresBoxLibrary.Xml
{
    /// <summary>
    /// Перечисление методов для чтения xml-файла.
    /// </summary>
    public enum XmlReadType
    {
        /// <summary>
        /// StreamReader.
        /// </summary>
        StreamReader,
        /// <summary>
        /// XmlReader.
        /// </summary>
        XmlReader
    }

    /// <summary>
    /// Класс, описывающий операции чтения xml-файла.
    /// </summary>
    internal class XmlReadOperation
    {
        /// <summary>
        /// Считывание фигур из xml-файла с использвание StreamReader.
        /// </summary>
        /// <param name="filePath">Путь к файлу.</param>
        /// <returns></returns>
        public IFigure[] ReadXmlWithStreamReader(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string xmlString = reader.ReadToEnd();

                XmlDocument document = new XmlDocument();
                document.LoadXml(xmlString);

                XmlNodeList list = document.GetElementsByTagName("figure");

                IFigure[] figures = InitFiguresArray();

                // Заполняю массив фигурами.
                int index = 0;
                foreach (XmlNode node in list)
                {
                    if (index != figures.Length)
                    {
                        figures[index] = GetFigure(node);
                        index++;
                    }
                    else
                    {
                        return figures;
                    }
                }

                return figures;
            }
        }

        /// <summary>
        /// Считывание фигур из xml-файла с использвание XmlReader.
        /// </summary>
        /// <param name="filePath">Путь к файлу.</param>
        /// <returns></returns>
        public IFigure[] ReadXmlWithXmlReader(string filePath)
        {
            using (XmlReader reader = XmlReader.Create(filePath))
            {
                IFigure[] figures = InitFiguresArray();
                int index = 0;

                string element = "";

                string material = "";
                string form = "";

                int length = 0;
                int width = 0;
                int radius = 0;

                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        element = reader.Name;
                        if (element == "figure")
                        {
                            material = reader.GetAttribute("material");
                            form = reader.GetAttribute("form");
                        }
                    }
                    else if (reader.NodeType == XmlNodeType.Text)
                    {
                        switch (element)
                        {
                            case "length":
                                length = int.Parse(reader.Value);
                                break;
                            case "width":
                                width = int.Parse(reader.Value);
                                break;
                            case "radius":
                                radius = int.Parse(reader.Value);
                                break;
                        }
                    }
                    else if ((reader.NodeType == XmlNodeType.EndElement) && (reader.Name == "figure"))
                    {
                        if (index != figures.Length)
                        {
                            figures[index] = GetConcreteSheetFigure(material, form, length, width, radius);
                            index++;
                        }
                        else
                        {
                            return figures;
                        }
                    }
                }

                return figures;
            }
        }
        
        /// <summary>
        /// Инициализирует массив фигур.
        /// </summary>
        private IFigure[] InitFiguresArray()
        {
            
            IFigure[] figures = new IFigure[20];
           
            for (int i = 0; i < figures.Length; i++)
                figures[i] = null;
            
            return figures;
        }

        /// <summary>
        /// Вовзращает фигуру из xml-файла.
        /// </summary>
        /// <param name="figure">Фигура в xml.</param>
        /// <returns></returns>
        private IFigure GetFigure(XmlNode figure)
        {
            GetFigureSideValues(figure, out int length, out int width, out int radius);
            GetFigureMaterialAndForm(figure, out string material, out string form);
            return GetConcreteSheetFigure(material, form, length, width, radius);
        }

        /// <summary>
        /// Возвращает стороны фигуры.
        /// </summary>
        /// <param name="figure">Фигура.</param>
        /// <param name="length">Длина.</param>
        /// <param name="width">Ширина.</param>
        /// <param name="radius">Радиус.</param>
        private void GetFigureSideValues(XmlNode figure, out int length, out int width, out int radius)
        {
            length = 0;
            width = 0;
            radius = 0;

            XmlNodeList sides = figure.ChildNodes;
            foreach (XmlNode side in sides)
            {
                switch (side.Name)
                {
                    case "length":
                        length = int.Parse(side.InnerText);
                        break;
                    case "width":
                        width = int.Parse(side.InnerText);
                        break;
                    case "radius":
                        radius = int.Parse(side.InnerText);
                        break;
                }
            }

            if (length == 0 && width == 0 && radius == 0)
                throw new Exception("Неккоретно заданы длины сторон.");
        }

        /// <summary>
        /// Вовзращает материал и форму фигуры.
        /// </summary>
        /// <param name="figure">Фигура.</param>
        /// <param name="material">Материал.</param>
        /// <param name="form">Форма.</param>
        private void GetFigureMaterialAndForm(XmlNode figure, out string material, out string form)
        {
            material = "";
            form = "";

            foreach(XmlAttribute attribute in figure.Attributes)
            {
                switch (attribute.Name)
                {
                    case "material":
                        material = attribute.InnerText;
                        break;
                    case "form":
                        form = attribute.InnerText;
                        break;
                }
            }
            
            if(material == "" || form == "")
                throw new Exception("Неккоретно заданы материал и форма сторон.");
        }

        /// <summary>
        /// Вовзращает фигуру конкретного материала и формы.
        /// </summary>
        /// <param name="material">Материал фигуры.</param>
        /// <param name="form">Форма фигуры.</param>
        /// <param name="length">Длина фигуры.</param>
        /// <param name="width">Ширина фигуры.</param>
        /// <param name="radius">Радиус фигуры.</param>
        /// <returns></returns>
        private IFigure GetConcreteSheetFigure(string material, string form, int length, int width, int radius)
        {
            IFigure figure = null;

            if (material == "Paper")
            {
                if (form == "Rectangle")
                    figure = new PaperRectangle(length, width);
                if (form == "Circle")
                    figure = new PaperCircle(radius);
            }
            
            if (material == "Film")
            {
                if (form == "Rectangle")
                    figure = new FilmRectangle(length, width);
                if (form == "Circle")
                    figure = new FilmCircle(radius);
            }

            if (figure == null)
                throw new Exception("Вы ввели неккоректные данные фигур(ы).");
            else
                return figure;
        }
    }
}
