using FiguresLibrary.Interfaces;
using SheetsLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FiguresBoxLibrary.Xml
{
    /// <summary>
    /// Перечисление методов для записи xml-файла.
    /// </summary>
    public enum XmlWriteType
    {
        /// <summary>
        /// StreamWriter.
        /// </summary>
        StreamWriter,
        /// <summary>
        /// XmlWriter.
        /// </summary>
        XmlWriter
    }

    /// <summary>
    /// Перечисление вариантов записи фигур в xml-файл.
    /// </summary>
    public enum FigureWriteType
    {
        /// <summary>
        /// Все фигуры.
        /// </summary>
        All,
        /// <summary>
        /// Только бумажные.
        /// </summary>
        Paper,
        /// <summary>
        /// Только пленочные.
        /// </summary>
        Film
    }

    /// <summary>
    /// Перечисление методов для записи xml-файла.
    /// </summary>
    internal class XmlWriteOperation
    {

        /// <summary>
        /// Запись фигур в xml-файл с использвание StreamWriter.
        /// </summary>
        /// <param name="filePath">Путь к файлу.</param>
        /// <param name="figures">Массив фигур.</param>
        /// <param name="figureWriteType">Режим сохранения фигур.</param>
        /// <returns></returns>
        public void WriteXmlFileWithStreamReader(string filePath, IFigure[] figures, FigureWriteType figureWriteType)
        {
            XmlDocument document = new XmlDocument();
            document.AppendChild(document.CreateXmlDeclaration("1.0", "UTF-8", null));
            XmlElement root = document.CreateElement("figures");
            
            for (int i = 0; i < figures.Length; i++)
            {
                if (CheckFigure(figures[i], figureWriteType))
                {
                    DetermineFigureType(document, root, figures[i]);
                }
            }

            document.AppendChild(root);

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                document.Save(writer);
            }
        }

        /// <summary>
        /// Запись фигур в xml-файл с использвание XmlWriter.
        /// </summary>
        /// <param name="filePath">Путь к файлу.</param>
        /// <param name="figures">Массив фигур.</param>
        /// <param name="figureWriteType">Режим сохранения фигур.</param>
        /// <returns></returns>
        public void WriteXmlFileWithXmlReader(string filePath, IFigure[] figures, FigureWriteType figureWriteType)
        {
            using (XmlWriter writer = XmlWriter.Create(filePath))
            {
                string material = "";

                writer.WriteStartDocument();
                writer.WriteStartElement("figures");

                foreach (IFigure figure in figures)
                {
                    if (CheckFigure(figure, figureWriteType))
                    {
                        writer.WriteStartElement("figure");

                        switch (figure.GetType().GetInterfaces()[0].Name)
                        {
                            case "IRectangle":
                                IRectangle rectangle = (IRectangle)figure;

                                material = rectangle.GetType().BaseType.Name.Replace("Sheet", "");
                                writer.WriteAttributeString("material", material);
                                writer.WriteAttributeString("form", "Rectangle");

                                writer.WriteStartElement("length");
                                writer.WriteString(rectangle.Length.ToString());
                                writer.WriteEndElement();

                                writer.WriteStartElement("width");
                                writer.WriteString(rectangle.Width.ToString());
                                writer.WriteEndElement();

                                break;

                            case "ICircle":
                                ICircle circle = (ICircle)figure;

                                material = circle.GetType().BaseType.Name.Replace("Sheet", "");
                                writer.WriteAttributeString("material", material);
                                writer.WriteAttributeString("form", "Circle");

                                writer.WriteStartElement("radius");
                                writer.WriteString(circle.Radius.ToString());
                                writer.WriteEndElement();

                                break;
                        }

                        writer.WriteEndElement();
                    }
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }

        /// <summary>
        /// Проверка фиугры на удовлетворение условиям.
        /// </summary>
        private bool CheckFigure(IFigure figure, FigureWriteType figureWriteType)
        {
            switch (figureWriteType)
            {
                case FigureWriteType.All:
                    if (figure != null)
                        return true;
                    else
                        return false;
                case FigureWriteType.Film:
                    if (figure != null && figure.GetType().BaseType.Name == "FilmSheet")
                        return true;
                    else
                        return false;
                case FigureWriteType.Paper:
                    if (figure != null && figure.GetType().BaseType.Name == "PaperSheet")
                        return true;
                    else
                        return false;
            }

            return false;
        }

        /// <summary>
        /// Определяет вид фигуры.
        /// </summary>
        /// <param name="document">XmlDocument.</param>
        /// <param name="root">Корневой элемент.</param>
        /// <param name="figure">Фигура.</param>
        private void DetermineFigureType(XmlDocument document, XmlElement root, IFigure figure)
        {
            string figureType = figure.GetType().GetInterfaces()[0].Name;
            
            switch (figureType)
            {
                case "IRectangle":
                    GetRectangleNode(document, root, (IRectangle)figure);
                    break;
                case "ICircle":
                    GetCircleNode(document, root, (ICircle)figure);
                    break;
            }
        }

        /// <summary>
        /// Формирует XmlElement прямоугольника.
        /// </summary>
        /// <param name="document">XmlDocument.</param>
        /// <param name="root">Корневой элемент.</param>
        /// <param name="rectangle">Прямоугольник.</param>
        private void GetRectangleNode(XmlDocument document, XmlElement root, IRectangle rectangle)
        {
            XmlElement rectangleElement = document.CreateElement("figure");

            string material = rectangle.GetType().BaseType.Name.Replace("Sheet", "");
            rectangleElement.SetAttribute("material", material);
            rectangleElement.SetAttribute("form", "Rectangle");

            XmlElement lengthElement = document.CreateElement("length");
            lengthElement.InnerText = rectangle.Length.ToString();
            rectangleElement.AppendChild(lengthElement);

            XmlElement widthElement = document.CreateElement("width");
            widthElement.InnerText = rectangle.Width.ToString();
            rectangleElement.AppendChild(widthElement);

            root.AppendChild(rectangleElement);
        }

        /// <summary>
        /// Формирует XmlElement круга.
        /// </summary>
        /// <param name="document">XmlDocument.</param>
        /// <param name="root">Корневой элемент.</param>
        /// <param name="circle">Круг.</param>
        private void GetCircleNode(XmlDocument document, XmlElement root, ICircle circle)
        {
            XmlElement circleElement = document.CreateElement("figure");

            string material = circle.GetType().BaseType.Name.Replace("Sheet", "");
            circleElement.SetAttribute("material", material);
            circleElement.SetAttribute("form", "Circle");

            XmlElement lengthElement = document.CreateElement("radius");
            lengthElement.InnerText = circle.Radius.ToString();
            circleElement.AppendChild(lengthElement);

            root.AppendChild(circleElement);
        }
    }
}
