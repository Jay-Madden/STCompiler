using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using STCompilerLib.SyntaxTree;
[assembly: CLSCompliant(true)]

namespace STCompilerLib
{
    public class STCompiler
    {

        public STCompiler(string input)
        {
            Run(input);
        }
        public void Run(string input)
        {
            //try
            //{
                Console.WriteLine("START");
                RunParser(input);
                Console.Write("DONE. Hit RETURN to exit: ");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("ERROR: " + ex);
            //    Console.Write("Hit RETURN to exit: ");
            //}
            Console.ReadLine();
        }
        private void RunParser(string input)
        {
            AntlrInputStream inputStream = new AntlrInputStream(input);

            AllenBradleySTLexer AllenBradleySTLexer = new AllenBradleySTLexer(inputStream);
            CommonTokenStream commonTokenStream = new CommonTokenStream(AllenBradleySTLexer);

            AllenBradleySTParser AllenBradleySTParser = new AllenBradleySTParser(commonTokenStream);
            AllenBradleySTParser.CompilationUnitContext fileContext = AllenBradleySTParser.compilationUnit();

            AntlrVisitor visitor = new AntlrVisitor();
            visitor.Visit(fileContext);

            //Console.WriteLine(rContext.ToStringTree());
            //SyntaxTreeListener TL = new SyntaxTreeListener();
            //ParseTreeWalker.Default.Walk(TL, fileContext);

            //using (System.IO.StreamWriter file = new System.IO.StreamWriter($"{Environment.CurrentDirectory}\\out.txt"))
            //{
            //    foreach (var x in TL.Rungs)
            //    {
            //        // If the line doesn't contain the word 'Second', write the line to the file.
            //        file.Write("<![CDATA[");
            //        file.Write(x);
            //        file.Write(";]]>");
            //        Console.WriteLine(x);
            //    }
            //}
        }
    }
}