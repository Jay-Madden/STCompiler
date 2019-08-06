
using System;

namespace STCompilerLib.MetaTree
{
    internal class MetaTree
    {
        private AntlrVisitor AntlrVisitor { get; set; }

        public MetaTree()
        {
            AntlrVisitor = new AntlrVisitor();
        }
        public MetaTreeNode MetaRoot { get; set; }

        public void BuildMetaTree(AllenBradleySTParser.CompilationUnitContext ctx)
        {
            try
            {
                MetaRoot = AntlrVisitor.BuildTree(ctx);
            }
            catch (Exception )
            {
                Console.WriteLine();
                throw;
            }
        }

        public void PrintTree()
        {
            MetaRoot.PrintChildren();
        }
    }
}