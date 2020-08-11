using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;

namespace SerializableClassLibrary.Book
{
    [Serializable]
    public class Book : ISerializable
    {
        [DataMember]
        private string Version { get; set; }

        public string Name { get; set; }
        public DateTime PublishDate { get; set; }
        public string Author { get; set; }

        public Book()
        {
            Version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        public Book(string name, DateTime publishDate, string author)
        {
            Name = name;
            PublishDate = publishDate.ToUniversalTime();
            Author = author;

            Version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Version", Version);
            info.AddValue("Name", Name);
            info.AddValue("PublishDate", PublishDate.ToString("dd/MM/yyyy"));
            info.AddValue("Author", Author);
        }

        public override bool Equals(object obj)
        {
            return obj is Book book &&
                   Version == book.Version &&
                   Name == book.Name &&
                   PublishDate.Date == book.PublishDate.Date &&
                   Author == book.Author;
        }

        public override int GetHashCode()
        {
            int hashCode = -2069121353;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Version);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + PublishDate.Date.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Author);
            return hashCode;
        }

        public Book(SerializationInfo info, StreamingContext context)
        {
            Version = Assembly.GetExecutingAssembly().GetName().Version.ToString();

            string tempVersion = (string)info.GetValue("Version", typeof(string));
            
            if (tempVersion != Version)
                throw new VersionExeption($"The calss version is {Version}, but your file has version {tempVersion}.");

            Name = (string)info.GetValue("Name", typeof(string));
            PublishDate = DateTime.Parse((string)info.GetValue("PublishDate", typeof(string)));
            Author = (string)info.GetValue("Author", typeof(string));
        }
    }
}
