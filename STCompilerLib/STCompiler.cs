using System;
using Antlr4.Runtime;
using STCompilerLib.MetaTree;
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

            AllenBradleySTLexer allenBradleyStLexer = new AllenBradleySTLexer(inputStream);
            CommonTokenStream commonTokenStream = new CommonTokenStream(allenBradleyStLexer);

            AllenBradleySTParser allenBradleyStParser = new AllenBradleySTParser(commonTokenStream);
            AllenBradleySTParser.CompilationUnitContext fileContext = allenBradleyStParser.compilationUnit();

            BuildMetaTree(fileContext);
        }

        private void BuildMetaTree(AllenBradleySTParser.CompilationUnitContext ctx)
        {
            MetaTree.MetaTree metaTree = new MetaTree.MetaTree();
            metaTree.BuildMetaTree(ctx);
            metaTree.PrintTree();
        }

    }
}