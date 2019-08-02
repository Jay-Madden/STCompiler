using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STCompilerLib
{
    public class Tag
    {
        string Name { get; set; }
        DataType DataType { get; set; }
        string Radix { get; set; }

        public Tag(string name, DataType data, string rad)
        {
            Name = name;
            DataType = data;
            Radix = rad;
        }
    }
}
