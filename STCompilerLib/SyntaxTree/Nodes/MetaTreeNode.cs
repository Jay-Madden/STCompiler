﻿using STCompilerLib.GenericTree;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
            Children.Add(new Optional(token));
        }

        public void Add(MetaTreeNode node)
        {
            Children.Add(node);
        }


        public override List<Optional> Children { get; set; } = new List<Optional>();

        internal override GenericOptional<StRules, MetaTreeNode> ChildAt(int index)
        {
            return Children[index];
        }

        public override string ToString()
        {
            return Kind.ToString();
        }
        
        public string GetAllChildren()
        {
            return VisitChildren();
        }
        public string VisitChildren(string s = "")
        {

            Console.WriteLine($"{Environment.NewLine} {this.Kind}");

            foreach (var child in this)
            {
                s = child.Node?.VisitChildren(s) + $" {Environment.NewLine} {this.Kind}";
            }
            return s;
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
            if(Kind == StRules.Identifier)
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
    }
}