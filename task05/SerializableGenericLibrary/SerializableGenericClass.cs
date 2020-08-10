using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;

namespace SerializableGenericLibrary
{
    /// <summary>
    /// Contains file`s types.
    /// </summary>
    public enum FileType
    {
        /// <summary>
        /// *.bin format.
        /// </summary>
        Bin,
        /// <summary>
        /// .json format.
        /// </summary>
        Json,
        /// <summary>
        /// *.xml format.
        /// </summary>
        Xml
    }

    /// <summary>
    /// Class describing functionality of serializable generic class.
    /// </summary>
    /// <typeparam name="T">The object type, which realizes the ISerializable interface.</typeparam>
    public class SerializableGenericClass<T> where T : ISerializable
    {
        string fileName;
        string filePath;

        /// <summary>
        /// Name of file.
        /// </summary>
        public string FileName
        {
            get
            {
                return fileName;
            }
            set
            {
                fileName = value;
                SetFilePath();
            }
        }

        /// <summary>
        /// Inits a generic class for serializble and deserializable objects.
        /// </summary>
        /// <param name="fileName">The file name (without file extension).</param>
        public SerializableGenericClass(string fileName)
        {
            if (!CheckFileNameFormat(fileName))
                throw new Exception("Incorrect file name.");

            Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\files");

            FileName = fileName;
        }

        private bool CheckFileNameFormat(string fileName)
        {
            string[] vs = fileName.Split('.');
            for (int i = vs.Length - 1; i >= 0; i--)
            {
                if (vs[i] == "bin" || vs[i] == "json" || vs[i] == "xml")
                    return false;
            }

            return true;
        }

        private void SetFilePath()
        {
            filePath = Directory.GetCurrentDirectory() + $@"\files\{fileName}";
        }

        #region (De)Serialize object.

        /// <summary>
        /// Serializes a object.
        /// </summary>
        /// <param name="obj">The currnet object.</param>
        /// <param name="fileType">The file type.</param>
        public void Serialize(T obj, FileType fileType)
        {
            try
            {
                switch (fileType)
                {
                    case FileType.Bin:
                        SerializeBinary(obj);
                        break;
                    case FileType.Json:
                        SerializeJson(obj);
                        break;
                    case FileType.Xml:
                        SerializeXml(obj);
                        break;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error: " + e.Message);
            }
        }

        /// <summary>
        /// Deserializes a object.
        /// </summary>
        /// <param name="fileType">The file type.</param>
        /// <returns></returns>
        public T Deserialize(FileType fileType)
        {
            try
            {
                switch (fileType)
                {
                    case FileType.Bin:
                        return DeserializeBinary();
                    case FileType.Json:
                        return DeserializeJson();
                    case FileType.Xml:
                        return DeserializeXml();
                    default:
                        return default;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error: " + e.Message);
            }
        }

        #region Bin serialize.

        private void SerializeBinary(T obj)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream(filePath + ".bin", FileMode.Create))
            {
                formatter.Serialize(fs, obj);
            }
        }

        private T DeserializeBinary()
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream(filePath + ".bin", FileMode.Open))
            {
                return (T)formatter.Deserialize(fs);
            }
        }

        #endregion

        #region Json serialize.
        private void SerializeJson(T obj)
        {
            DataContractJsonSerializerSettings settings = new DataContractJsonSerializerSettings
            {
                DateTimeFormat = new DateTimeFormat("MM/dd/yyyy HH:mm:ss")
            };

            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T), settings);

            using (FileStream fs = new FileStream(filePath + ".json", FileMode.Create))
            {
                serializer.WriteObject(fs, obj);
            }
        }

        private T DeserializeJson()
        {
            DataContractJsonSerializerSettings settings = new DataContractJsonSerializerSettings
            {
                DateTimeFormat = new DateTimeFormat("MM/dd/yyyy HH:mm:ss")
            };

            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T), settings);

            using (FileStream fs = new FileStream(filePath + ".json", FileMode.Open))
            {
                return (T)serializer.ReadObject(fs);
            }
        }

        #endregion

        #region Xml serialize
        private void SerializeXml(T obj)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            using (FileStream fs = new FileStream(filePath + ".xml", FileMode.Create))
            {
                serializer.Serialize(fs, obj);
            }
        }

        private T DeserializeXml()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            using (FileStream fs = new FileStream(filePath + ".xml", FileMode.Open))
            {
                return (T)serializer.Deserialize(fs);
            }
        }

        #endregion

        #endregion

        #region (De)Serialize object collection.

        /// <summary>
        /// Serializes a object collection.
        /// </summary>
        /// <param name="ts">The currnet object collection.</param>
        /// <param name="fileType">The file type.</param>
        public void SerializeCollection(ICollection<T> ts, FileType fileType)
        {
            try
            {
                switch (fileType)
                {
                    case FileType.Bin:
                        SerializeCollectionBinary(ts);
                        break;
                    case FileType.Json:
                        SerializeCollectionJson(ts);
                        break;
                    case FileType.Xml:
                        SerializeCollectionXml(ts);
                        break;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error: " + e.Message);
            }
        }

        /// <summary>
        /// Deserializes a object collection.
        /// </summary>
        /// <param name="type">The collection type.</param>
        /// <param name="fileType">The file type.</param>
        /// <returns></returns>
        public ICollection<T> DeserializeCollection(Type type, FileType fileType)
        {
            try
            {
                switch (fileType)
                {
                    case FileType.Bin:
                        return DeserializeCollectionBinary();
                    case FileType.Json:
                        return DeserializeCollectionJson(type);
                    case FileType.Xml:
                        return DeserializeCollectionXml(type);
                    default:
                        return default;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error: " + e.Message);
            }
        }

        #region Bin serialize collection.

        private void SerializeCollectionBinary(ICollection<T> ts)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream(filePath + ".bin", FileMode.Create))
            {
                formatter.Serialize(fs, ts);
            }
        }

        private ICollection<T> DeserializeCollectionBinary()
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream(filePath + ".bin", FileMode.Open))
            {
                return (ICollection<T>)formatter.Deserialize(fs);
            }
        }

        #endregion

        #region Json serialize Collection.
        private void SerializeCollectionJson(ICollection<T> ts)
        {
            DataContractJsonSerializerSettings settings = new DataContractJsonSerializerSettings
            {
                DateTimeFormat = new DateTimeFormat("MM/dd/yyyy HH:mm:ss")
            };

            DataContractJsonSerializer serializer = new DataContractJsonSerializer(ts.GetType(), settings);

            using (FileStream fs = new FileStream(filePath + ".json", FileMode.Create))
            {
                serializer.WriteObject(fs, ts);
            }
        }

        private ICollection<T> DeserializeCollectionJson(Type type)
        {
            DataContractJsonSerializerSettings settings = new DataContractJsonSerializerSettings
            {
                DateTimeFormat = new DateTimeFormat("MM/dd/yyyy HH:mm:ss")
            };

            DataContractJsonSerializer serializer = new DataContractJsonSerializer(type, settings);

            using (FileStream fs = new FileStream(filePath + ".json", FileMode.Open))
            {
                return (ICollection<T>)serializer.ReadObject(fs);
            }
        }

        #endregion

        #region Xml serialize
        private void SerializeCollectionXml(ICollection<T> ts)
        {
            XmlSerializer serializer = new XmlSerializer(ts.GetType());

            using (FileStream fs = new FileStream(filePath + ".xml", FileMode.Create))
            {
                serializer.Serialize(fs, ts);
            }
        }

        private ICollection<T> DeserializeCollectionXml(Type type)
        {
            XmlSerializer serializer = new XmlSerializer(type);

            using (FileStream fs = new FileStream(filePath + ".xml", FileMode.Open))
            {
                return (ICollection<T>)serializer.Deserialize(fs);
            }
        }

        #endregion

        #endregion
    }
}
