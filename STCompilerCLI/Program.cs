using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using STCompilerLib;
using Antlr4.Runtime;

namespace STCompilerCLI
{
    class Program
    {
        public static void Main(string[] args)
        {
            string input = File.ReadAllText(@"C:\STCompiler\STCompiler\STCompilerCLI\AntlrInput.txt");
            STCompiler stCompiler = new STCompiler(input);
        }
    }
}
