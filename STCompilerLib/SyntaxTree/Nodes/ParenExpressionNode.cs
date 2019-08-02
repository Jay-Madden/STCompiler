using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STCompilerLib.GenericTree;

namespace STCompilerLib.SyntaxTree.Nodes
{
    internal class ParenExpressionNode : ExpressionNode
    {
        public ParenExpressionNode(ExpressionNode expression) :base(StRules.ParensExpression)
        {
        }

        public override List<StNode> Children
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        internal override GenericOptional<StRules, StNode> ChildAt(int index)
        {

        }
    }
}
