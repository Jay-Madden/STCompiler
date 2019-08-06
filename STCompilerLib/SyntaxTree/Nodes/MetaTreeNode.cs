using STCompilerLib.GenericTree;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace STCompilerLib.SyntaxTree.Nodes
{
    using Optional = GenericOptional<StRules, MetaTreeNode>;

    internal class MetaTreeNode : GenericTreeNode<StRules, MetaTreeNode>
    {
        internal MetaTreeNode(StRules rule) : base(rule)
        {
            Children = new List<Optional>();
        }

        public void Add(GenericTreeToken token)
        {
            Children.Add(token);
        }

        public void Add(MetaTreeNode node)
        {
            Children.Add(node);
        }

        public sealed override List<Optional> Children { get; set; }

        internal override GenericOptional<StRules, MetaTreeNode> ChildAt(int index)
        {
            return Children[index];
        }

        public override string ToString()
        {
            return Kind.ToString();
        }

        public void PrintChildren(string indent, bool last)
        {
            Console.Write(indent);
            if (last)
            {
                Console.Write("\\-");
                indent += "  ";
            }
            else
            {
                Console.Write("|-");
                indent += "| ";
            }
            Console.Write(Kind);
            if(
                Kind == StRules.IdentifierNode ||
                Kind == StRules.BooleanIdentifierNode ||
                Kind == StRules.DigitSeqNode ||
                Kind == StRules.HexIdentifierNode ||
                Kind == StRules.MemberIndexNode ||
                Kind == StRules.MemberNode
               ) 
            {
                if (Children.Count == 1)
                {
                    Console.WriteLine($": {Children[0].Token.Value}");
                }
                else
                {
                    Console.WriteLine();
                    for (int i = 0; i < Children.Count; i++)
                    {
                        Children[i].Node?.PrintChildren(indent, i == Children.Count - 1);
                    }
                }
            }
            else
            {
                Console.WriteLine();
                for (int i = 0; i < Children.Count; i++)
                {
                    Children[i].Node?.PrintChildren(indent, i == Children.Count - 1);
                }
            }
        }
    }
}
