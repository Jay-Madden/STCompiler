using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STCompilerLib.GenericTree;

namespace STCompilerLib.SyntaxTree.Nodes
{
    internal abstract class PrimaryExpressionNode : StNode
    {
        public PrimaryExpressionNode(StRules rule) :base(rule)
        {
        }
    }
}
