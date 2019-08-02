using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STCompilerLib
{
    public enum DataType
    {
        DINT,
        INT,
        SINT,
        STRING,
        FLOAT,
        BOOL
    }

    public enum OpCodes
    {
        MOV, //Move
        CPT, //Compute
        EQU, //Equals
        CMP, //Compare
        ADD, //Adds
        SUB, //SUB
        XIC, //Examine On
        XIO  //Examine Off
    }
}
