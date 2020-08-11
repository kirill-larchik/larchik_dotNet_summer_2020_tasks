using Microsoft.VisualStudio.TestTools.UnitTesting;
using SerializableClassLibrary;
using SerializableClassLibrary.Book;
using SerializableGenericLibrary;
using System;
using System.Reflection;

namespace SerializableGenericClassUnitTest
{
    [TestClass]
    public class ObjectUnitTest
    {
        [DataTestMethod]
        [DataRow("book1", "author1")]
        [DataRow("book2", "author2")]
        [DataRow("book3", "author3")]
        [DataRow("book4", "author4")]
        [DataRow("book5", "author5")]
        public void BinarySerialization_Book(string name, string author)
        {
            DateTime publishDate = DateTime.Now;
            Book expected = new Book(name, publishDate, author);

            SerializableGenericClass<Book> genericClass = new SerializableGenericClass<Book>("book");
            genericClass.Serialize(expected, FileType.Bin);

            Book actual = genericClass.Deserialize(FileType.Bin);

            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow("book1", "author1")]
        [DataRow("book2", "author2")]
        [DataRow("book3", "author3")]
        [DataRow("book4", "author4")]
        [DataRow("book5", "author5")]
        public void JsonSerialization_Book(string name, string author)
        {
            DateTime publishDate = DateTime.Now;
            Book expected = new Book(name, publishDate, author);

            SerializableGenericClass<Book> genericClass = new SerializableGenericClass<Book>("book");
            genericClass.Serialize(expected, FileType.Json);

            Book actual = genericClass.Deserialize(FileType.Json);

            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow("book1", "author1")]
        [DataRow("book2", "author2")]
        [DataRow("book3", "author3")]
        [DataRow("book4", "author4")]
        [DataRow("book5", "author5")]
        public void XmlSerialization_Book(string name, string author)
        {
            DateTime publishDate = DateTime.Now;
            Book expected = new Book(name, publishDate, author);

            SerializableGenericClass<Book> genericClass = new SerializableGenericClass<Book>("book");
            genericClass.Serialize(expected, FileType.Xml);

            Book actual = genericClass.Deserialize(FileType.Xml);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "The calss version is 1.0.0.0, but your file has version 1.0.0.1.")]
        public void XmlDeserialization_Book_GetExptected()
        {
            SerializableGenericClass<Book> genericClass = new SerializableGenericClass<Book>("test");
            Book book = genericClass.Deserialize(FileType.Xml);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "The calss version is 1.0.0.0, but your file has version 1.0.0.1.")]
        public void JsonDeserialization_Book_GetExptected()
        {
            SerializableGenericClass<Book> genericClass = new SerializableGenericClass<Book>("test");
            Book book = genericClass.Deserialize(FileType.Json);
        }
    }
}
