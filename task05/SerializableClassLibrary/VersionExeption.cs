using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializableClassLibrary
{
    public class VersionExeption : Exception
    {
        public VersionExeption(string message) 
            : base(message) { }
    }
}
