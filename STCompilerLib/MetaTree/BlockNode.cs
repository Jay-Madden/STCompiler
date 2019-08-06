using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STCompilerLib.SyntaxTree.Nodes
{
    internal class BlockNode : StNode
    {
        public BlockNode() : base(StRules.Block)
        {

        }

        internal List<StNode> Children = new List<StNode>();

        internal override int ParentChildren => throw new NotImplementedException();

        internal override int LocalIndex => throw new NotImplementedException();

        internal override int ChildNum => throw new NotImplementedException();
    }
}
