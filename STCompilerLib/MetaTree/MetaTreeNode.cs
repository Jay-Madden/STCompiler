using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        protected override GenericOptional<StRules, MetaTreeNode> ChildAt(int index)
        {
            return Children[index];
        }

        public override string ToString()
        {
            return Kind.ToString();
        }

        /// <summary>
        /// Recursively traverses the tree and builds a string representation of its structure
        /// </summary>
        /// <param name="indent"></param>
        /// <param name="last"></param>
        /// <param name="sb"></param>
        /// <returns></returns>
        public string TreeToString(string indent = "", bool last = true, StringBuilder sb = null)
        {
            bool topLevel = false;
            if(sb == null)
            {
                topLevel = true;
                sb = new StringBuilder();
            }

            sb.Append(indent);
            if (last)
            {
                sb.Append("\\-");
                indent += "  ";
            }
            else
            {
                sb.Append("|-");
                indent += "| ";
            }
            sb.Append($"{Kind}: (ParentIndex: {ParentIndex}, ParentMax: {ParentMax}) (TreeDepth: {TreeDepth}, ScopeDepth: {ScopeDepth})");
            bool tokenFound = false;
            if (RuleContainsToken(Kind))
            {
                if (Children.Count == 1)
                {
                    sb.AppendLine($"Token: {Children[0].Token.Value}");
                    tokenFound = true;
                }
            }
            if (!tokenFound)
            {
                sb.AppendLine();
                for (int i = 0; i < Children.Count; i++)
                {
                    Children[i].Node?.TreeToString(indent, i == Children.Count - 1, sb);
                }
            }
            return topLevel ? sb.ToString() : "";
        }

        /// <summary>
        /// Recursively traverses the tree and prints out a string representation of its structure
        /// </summary>
        /// <param name="indent"></param>
        /// <param name="last"></param>
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

            Console.Write($"{Kind}:");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write($"ParentIndex:");
            Console.ResetColor();
            Console.Write($"{ParentIndex},");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write($"ParentMax:");
            Console.ResetColor();
            Console.Write($"{ParentMax})");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write($"TreeDepth:);");
            Console.ResetColor();
            Console.Write($"{TreeDepth},");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write($"ScopeDepth:");
            Console.ResetColor();
            Console.Write($"{ScopeDepth})");

            bool tokenFound = false;
            if (RuleContainsToken(Kind))
            {
                if (Children.Count == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Token: {Children[0].Token.Value}");
                    Console.ResetColor();
                    tokenFound = true;
                }
            }
            if (!tokenFound)
            {
                Console.WriteLine();
                for (int i = 0; i < Children.Count; i++)
                {
                    Children[i].Node?.PrintChildren(indent, i == Children.Count - 1);
                }
            }
        }

        private bool RuleContainsToken(StRules rule) =>
            rule == StRules.IdentifierNode ||
            rule == StRules.BooleanIdentifierNode ||
            rule == StRules.DigitSeqNode ||
            rule == StRules.HexIdentifierNode ||
            rule == StRules.MemberIndexNode ||
            rule == StRules.MemberNode ||
            rule == StRules.String ||
            rule == StRules.CaseIdentifier;
    }
}
