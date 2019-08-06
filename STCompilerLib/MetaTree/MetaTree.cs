
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
        /// Called During Tree Creation
        /// </summary>
        private void AddMetaData()
        {
            Stack<MetaTreeNode> stack = new Stack<MetaTreeNode>();
            stack.Push(MetaRoot);

            while(stack.Any())
            {
                MetaTreeNode node = stack.Pop();

                for (int i = node.Children.Count - 1; i >= 0; i--)
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
            AddDepthData(0, 0, MetaRoot);
        }

        /// <summary>
        /// Recursive DF traversal to add node depth information
        /// </summary>
        /// <param name="scopeDepth"></param>
        /// <param name="node"></param>
        /// <param name="treeDepth"></param>
        private void AddDepthData(int treeDepth, int scopeDepth, MetaTreeNode node)
        {
            node.TreeDepth = treeDepth;
            node.ScopeDepth = scopeDepth;
            if (node.Children.Count == 0)
                return;

            foreach (GenericOptional<StRules, MetaTreeNode> n in node)
            {
                if (n.IsNode)
                {
                    int scopeD = (node.Kind == StRules.Block) ? scopeDepth + 1: scopeDepth;
                    AddDepthData(treeDepth+1, scopeD, n.Node);
                }
            }
        }

        public void PrintTree()
        {
            MetaRoot.PrintChildren();
        }
    }
}