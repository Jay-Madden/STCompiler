using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STCompilerLib.SyntaxTree.Nodes
{
    internal class IndexOperatorNode : StNode
    {
        public IndexOperatorNode(ExpressionNode expressionNode) : base(StRules.IndexOperator)
        {
            ExpressionNode = expressionNode;
        }

        public ExpressionNode ExpressionNode { get; set; }

        internal override int ParentChildren => throw new NotImplementedException();

        internal override int LocalIndex => throw new NotImplementedException();

        internal override int ChildNum => throw new NotImplementedException();
    }
}
