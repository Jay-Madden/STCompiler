
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using STCompilerLib.GenericTree;

namespace STCompilerLib.MetaTree
{
    internal class MetaTree
    {
        private AntlrVisitor AntlrVisitor { get; set; }

        public MetaTree()
        {
            AntlrVisitor = new AntlrVisitor();
        }
        public MetaTreeNode MetaRoot { get; set; }

        public void BuildMetaTree(AllenBradleySTParser.CompilationUnitContext ctx)
        {
            try
            {
                MetaRoot = AntlrVisitor.BuildTree(ctx);
                AddMetaData();
            }
            catch (Exception )
            {
                Console.WriteLine();
                throw;
            }
        }

        /// <summary>
        /// Iterativley DF traverses the tree and adds the appropriate meta data
        /// </summary>
        private void AddMetaData()
        {
            Stack<MetaTreeNode> stack = new Stack<MetaTreeNode>();
            stack.Push(MetaRoot);

            while(stack.Any())
            {
                MetaTreeNode node = stack.Pop();

                for (int i = 0; i < node.Children.Count; i++)
                {
                    if (node.Children[i].IsNode)
                    {
                        MetaTreeNode temp = node.Children[i].Node;
                        stack.Push(temp);
                        temp.ParentIndex = i;
                        temp.ParentMax = node.Children.Count;
                    }
                }
            }
        }

        public void PrintTree()
        {
            MetaRoot.PrintChildren();
        }
    }
}