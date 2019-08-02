using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STCompilerLib.SyntaxTree.Nodes
{
    internal class StatementNode : StNode
    {
        public StatementNode() : base(StRules.Statement)
        {

        }
    }
}
