using Microsoft.VisualStudio.TestTools.UnitTesting;
using SerializableClassLibrary;
using SerializableClassLibrary.Book;
using SerializableGenericLibrary;
using System;

namespace SerializableGenericClassUnitTest
{
    [TestClass]
    public class CollectionUnitTest
    {
        [TestMethod]
        public void BinarySerialization_Books()
        {
            Book firstBook = new Book { Name = "book1", Author = "author1", PublishDate = DateTime.Parse("07.07.2007") };
            Book secondBook = new Book { Name = "book2", Author = "author2", PublishDate = DateTime.Parse("08.07.2007") };
            Book thirdBook = new Book { Name = "book3", Author = "author3", PublishDate = DateTime.Parse("07.09.2007") };
            Book fourthBook = new Book { Name = "book4", Author = "author4", PublishDate = DateTime.Parse("10.07.2007") };
            Book fifthBook = new Book { Name = "book5", Author = "author5", PublishDate = DateTime.Parse("07.01.2007") };

            SerializableCollection<Book> books = new SerializableCollection<Book>
            {
                firstBook,
                secondBook,
                thirdBook,
                fourthBook,
                fifthBook
            };

            SerializableGenericClass<Book> serializable = new SerializableGenericClass<Book>("books");
            serializable.SerializeCollection(books, FileType.Bin);

            SerializableCollection<Book> actual = (SerializableCollection<Book>)serializable.DeserializeCollection(typeof(SerializableGenericClass<Book>), FileType.Bin);

            for (int i = 0; i < books.Count; i++)
            {
                if (!books[i].Equals(actual[i]))
                    Assert.Fail();
            }

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void JsonSerialization_Books()
        {
            Book firstBook = new Book { Name = "book1", Author = "author1", PublishDate = DateTime.Parse("07.07.2007") };
            Book secondBook = new Book { Name = "book2", Author = "author2", PublishDate = DateTime.Parse("08.07.2007") };
            Book thirdBook = new Book { Name = "book3", Author = "author3", PublishDate = DateTime.Parse("07.09.2007") };
            Book fourthBook = new Book { Name = "book4", Author = "author4", PublishDate = DateTime.Parse("10.07.2007") };
            Book fifthBook = new Book { Name = "book5", Author = "author5", PublishDate = DateTime.Parse("07.01.2007") };

            SerializableCollection<Book> books = new SerializableCollection<Book>
            {
                firstBook,
                secondBook,
                thirdBook,
                fourthBook,
                fifthBook
            };

            SerializableGenericClass<Book> serializable = new SerializableGenericClass<Book>("books");
            serializable.SerializeCollection(books, FileType.Json);

            SerializableCollection<Book> actual = (SerializableCollection<Book>)serializable.DeserializeCollection(typeof(SerializableCollection<Book>), FileType.Json);

            for (int i = 0; i < books.Count; i++)
            {
                if (!books[i].Equals(actual[i]))
                    Assert.Fail();
            }

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void XmlSerialization_Books()
        {
            Book firstBook = new Book { Name = "book1", Author = "author1", PublishDate = DateTime.Parse("07.07.2007") };
            Book secondBook = new Book { Name = "book2", Author = "author2", PublishDate = DateTime.Parse("08.07.2007") };
            Book thirdBook = new Book { Name = "book3", Author = "author3", PublishDate = DateTime.Parse("07.09.2007") };
            Book fourthBook = new Book { Name = "book4", Author = "author4", PublishDate = DateTime.Parse("10.07.2007") };
            Book fifthBook = new Book { Name = "book5", Author = "author5", PublishDate = DateTime.Parse("07.01.2007") };

            SerializableCollection<Book> books = new SerializableCollection<Book>
            {
                firstBook,
                secondBook,
                thirdBook,
                fourthBook,
                fifthBook
            };

            SerializableGenericClass<Book> serializable = new SerializableGenericClass<Book>("books");
            serializable.SerializeCollection(books, FileType.Xml);

            SerializableCollection<Book> actual = (SerializableCollection<Book>)serializable.DeserializeCollection(typeof(SerializableCollection<Book>), FileType.Xml);

            for (int i = 0; i < books.Count; i++)
            {
                if (!books[i].Equals(actual[i]))
                    Assert.Fail();
            }

            Assert.IsTrue(true);
        }
    }
}
