using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STCompilerLib.GenericTree
{
    internal struct GenericTreeToken
    {
        public GenericTreeToken(object value)
        {
            Value = value;
        }

        public readonly object Value;
    }
}
