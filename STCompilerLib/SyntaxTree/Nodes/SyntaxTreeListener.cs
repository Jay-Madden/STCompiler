using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime.Misc;

namespace STCompilerLib.SyntaxTree.Nodes
{
    internal class SyntaxTreeListener : AllenBradleySTBaseListener
    {

        public SyntaxTreeListener()
        {
            MetaTreeNode root = new MetaTreeNode(StRules.CompilationUnit);
            MetaTreeNode Current = root;
        }

        public override void EnterBlock([NotNull] AllenBradleySTParser.BlockContext context)
        {
            base.EnterBlock(context);
        }

        public override void EnterCompilationUnit([NotNull] AllenBradleySTParser.CompilationUnitContext context)
        {
            base.EnterCompilationUnit(context);
        }

        public override void ExitBlock([NotNull] AllenBradleySTParser.BlockContext context)
        {
            base.ExitBlock(context);
        }

        public override void ExitCompilationUnit([NotNull] AllenBradleySTParser.CompilationUnitContext context)
        {
            base.ExitCompilationUnit(context);
        }
    }
}
