using System;
using System.Collections.Generic;
using STCompilerLib.GenericTree;

namespace STCompilerLib.MetaTree
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

        public int ParentMax { get; set; }

        public int ParentIndex { get; set; }

        public int TreeDepth { get; set; }

        public int ScopeDepth { get; set; }

        internal override GenericOptional<StRules, MetaTreeNode> ChildAt(int index)
        {
            return Children[index];
        }

        public override string ToString()
        {
            return Kind.ToString();
        }

        public void PrintChildren(string indent = "", bool last = true)
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
            Console.Write($"{Kind}: (ParentIndex: {ParentIndex}, ParentMax: {ParentMax}) (TreeDepth: {TreeDepth}, ScopeDepth: {ScopeDepth})");
            if (RuleContainsToken(Kind))
            {
                if (Children.Count == 1)
                {
                    Console.WriteLine($"Token: {Children[0].Token.Value}");
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

        private bool RuleContainsToken(StRules rule)
        {
            return rule == StRules.IdentifierNode ||
                   rule == StRules.BooleanIdentifierNode ||
                   rule == StRules.DigitSeqNode ||
                   rule == StRules.HexIdentifierNode ||
                   rule == StRules.MemberIndexNode ||
                   rule == StRules.MemberNode || 
                   rule == StRules.String || 
                   rule == StRules.CaseIdentifier;
        }
    }
}
