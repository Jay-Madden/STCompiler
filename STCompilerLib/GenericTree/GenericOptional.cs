using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STCompilerLib.GenericTree
{
    internal struct GenericOptional<TTreeKind, TTreeNode>
        where TTreeKind : struct
        where TTreeNode : GenericTreeNode<TTreeKind, TTreeNode>
    {
        public readonly TTreeNode Node;
        public readonly GenericTreeToken Token;

        internal GenericOptional(TTreeNode node) : this()
        {
            Node = node;
        }

        internal GenericOptional(GenericTreeToken token) : this()
        {
            Token = token;
        }

        public bool IsNode => Node != null;

        public static implicit operator GenericOptional<TTreeKind, TTreeNode>(TTreeNode node)
            => new GenericOptional<TTreeKind, TTreeNode>(node);

        public static implicit operator GenericOptional<TTreeKind, TTreeNode>(GenericTreeToken token)
            => new GenericOptional<TTreeKind, TTreeNode>(token);
    
        public override string ToString()
        {
            return (IsNode) ? $"Rule = {Node.Kind}" : $"Token = {Token.Value?.ToString()}";
        }

        internal void PrintPretty(string indent, bool v)
        {
            throw new NotImplementedException();
        }
    }
}
