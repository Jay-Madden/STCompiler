
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Antlr4.Runtime.Tree;
using STCompilerLib.GenericTree;

namespace STCompilerLib.MetaTree
{
    internal class MetaTree
    {
        private AntlrTreeVisitor AntlrVisitor { get; set; }

        public MetaTree()
        {
            AntlrVisitor = new AntlrTreeVisitor();
        }

        public MetaTreeNode MetaRoot { get; set; }

        /// <summary>
        /// Public Build MetaTree method
        /// /// </summary>
        /// <param name="ctx">Root node from which the tree will be build</param>
        public void BuildMetaTree(IParseTree ctx)
        {
            try
            {
                MetaRoot = AntlrVisitor.BuildTree(ctx);
                AddMetaData(MetaRoot);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /// <summary>
        /// Traverses the tree several times to add the appropriate metadata
        /// </summary>
        /// <param name="root"></param>
        private void AddMetaData(MetaTreeNode root)
        {
            AddParentData(root);
            AddDepthData(0, 0, MetaRoot);
        }

        /// <summary>
        /// Iterativley DF adds the parent info to the tree
        /// </summary>
        /// <param name="root"></param>
        private void AddParentData(MetaTreeNode root)
        {
            Stack<MetaTreeNode> stack = new Stack<MetaTreeNode>();
            stack.Push(root);

            while (stack.Any())
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

        /// <summary>
        /// Recursively traverses the tree and builds a string representation of its structure
        /// </summary>
        /// <returns></returns>
        public string GetTreeString() => MetaRoot.TreeToString();

        /// <summary>
        /// Recursively traverses the tree and prints out a string representation of its structure
        /// </summary>
        public void PrintTree() => MetaRoot.PrintChildren();
    }
}