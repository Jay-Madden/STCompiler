using STCompilerLib.GenericTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STCompilerLib.SyntaxTree.Nodes
{
    internal abstract class ExpressionNode : PrimaryExpressionNode
    {
        public ExpressionNode(StRules rule) :base(rule)
        {
        }
    }
}
