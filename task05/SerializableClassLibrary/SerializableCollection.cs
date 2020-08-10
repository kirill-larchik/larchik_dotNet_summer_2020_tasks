using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SerializableClassLibrary
{
    [Serializable]
    public class SerializableCollection<T> : ICollection<T> where T : ISerializable
    {
        readonly List<T> ts;

        public SerializableCollection()
        {
            ts = new List<T>();
        }

        public T this[int index] { get { return ts[index]; } set { ts[index] = value; } }

        public int Count => ts.Count;

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            ts.Add(item);
        }

        public void Clear()
        {
            ts.Clear();
        }

        public bool Contains(T item)
        {
            return ts.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            ts.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ts.GetEnumerator();
        }

        public bool Remove(T item)
        {
            return ts.Remove(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
