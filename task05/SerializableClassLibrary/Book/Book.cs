using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SerializableClassLibrary.Book
{
    [Serializable]
    public class Book : ISerializable
    {
        public string Name { get; set; }
        public DateTime PublishDate { get; set; }
        public string Author { get; set; }

        public Book() { }

        public Book(string name, DateTime publishDate, string author)
        {
            Name = name;
            PublishDate = publishDate.ToUniversalTime();
            Author = author;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", Name);
            info.AddValue("PublishDate", PublishDate.ToString("dd/MM/yyyy HH:mm:ss"));
            info.AddValue("Author", Author);
        }

        public override bool Equals(object obj)
        {
            return obj is Book book &&
                   Name == book.Name &&
                   PublishDate.Date == book.PublishDate.Date &&
                   Author == book.Author;
        }

        public override int GetHashCode()
        {
            int hashCode = -638602472;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + PublishDate.Date.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Author);
            return hashCode;
        }

        public Book(SerializationInfo info, StreamingContext context)
        {
            Name = (string)info.GetValue("Name", typeof(string));
            PublishDate = DateTime.Parse((string)info.GetValue("PublishDate", typeof(string)));
            Author = (string)info.GetValue("Author", typeof(string));
        }
    }
}
