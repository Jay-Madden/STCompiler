namespace STCompilerLib.LadderEnums
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
