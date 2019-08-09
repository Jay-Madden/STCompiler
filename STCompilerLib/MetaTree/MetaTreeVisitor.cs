using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using STCompilerLib.GenericTree;
#nullable enable

namespace STCompilerLib.MetaTree
{
    internal abstract class MetaTreeVisitor
    {
        protected MetaTreeVisitor(MetaTreeNode node)
        {
            Visit(node);
        }
        private MetaTreeNode Visit(MetaTreeNode node)
        {
            Func<MetaTreeNode, MetaTreeNode>[] funcMap  =
            {
                VisitArthmeticMathOp,
                VisitArtihmeticCompareOp,
                VisitCompilationUnit,
                VisitString,
                VisitIndexOperator,
                VisitFunction,
                VisitFunctionArg,
                VisitPrimaryExpression,
                VisitAssignment,
                VisitStatement,
                VisitBlock,
                VisitConditional,
                VisitIfStatement,
                VisitIfBlock,
                VisitElseIfStatement,
                VisitElseIfBlock,
                VisitElseBlock,
                VisitCaseStatement,
                VisitCaseIdentifier,
                VisitCaseBlock,
                VisitParensExpression,
                VisitNegationExpression,
                VisitArithmeticMathExpression,
                VisitArithmeticCompareExpression,
                VisitBooleanCompareExpression,
                VisitExitStatement,
                VisitForLoop,
                VisitRepeatLoop,
                VisitIdentifierExpression,
                VisitForLoopBlock,
                VisitRepeatLoopBlock,
                VisitIdentifierResolvedName,
                VisitDigitSeqNode,
                VisitBooleanIdentifierNode,
                VisitIdentifierNode,
                VisitMemberNode,
                VisitHexIdentifierNode,
                VisitMemberNode
            };
            foreach (var n in node.Children)
            {
                if (n.IsNode)
                    funcMap[(int)node.Kind](n.Node);
            }
            return node;
        }
        public MetaTreeNode VisitArthmeticMathOp(MetaTreeNode node)
        {
            return Visit(node);
        }
        public  MetaTreeNode VisitArtihmeticCompareOp(MetaTreeNode node)
        {
            return Visit(node);
        }
        public  MetaTreeNode VisitCompilationUnit(MetaTreeNode node)
        {
            return Visit(node);
        }
        public  MetaTreeNode VisitString(MetaTreeNode node)
        {
            return Visit(node);
        }
        public  MetaTreeNode VisitIndexOperator(MetaTreeNode node)
        {
            return Visit(node);
        }
        public  MetaTreeNode VisitFunction(MetaTreeNode node)
        {
            return Visit(node);
        }
        public  MetaTreeNode VisitFunctionArg(MetaTreeNode node)
        {
            return Visit(node);
        }
        public  MetaTreeNode VisitPrimaryExpression(MetaTreeNode node)
        {
            return Visit(node);
        }
        public  MetaTreeNode VisitAssignment(MetaTreeNode node)
        {
            return Visit(node);
        }
        public  MetaTreeNode VisitStatement(MetaTreeNode node)
        {
            return Visit(node);
        }
        public  MetaTreeNode VisitBlock(MetaTreeNode node)
        {
            return Visit(node);
        }
        public  MetaTreeNode VisitConditional(MetaTreeNode node)
        {
            return Visit(node);
        }
        public  MetaTreeNode VisitIfStatement(MetaTreeNode node)
        {
            return Visit(node);
        }
        public  MetaTreeNode VisitIfBlock(MetaTreeNode node)
        {
            return Visit(node);
        }
        public  MetaTreeNode VisitElseIfStatement(MetaTreeNode node)
        {
            return Visit(node);
        } 
        public  MetaTreeNode VisitElseIfBlock(MetaTreeNode node)
        {
            return Visit(node);
        }

        public  MetaTreeNode VisitElseBlock(MetaTreeNode node)
        {
            return Visit(node);
        }
        public  MetaTreeNode VisitCaseStatement(MetaTreeNode node)
        {
            return Visit(node);
        }
        public  MetaTreeNode VisitCaseIdentifier(MetaTreeNode node)
        {
            return Visit(node);
        }
        public  MetaTreeNode VisitCaseBlock(MetaTreeNode node)
        {
            return Visit(node);
        }
        public  MetaTreeNode VisitParensExpression(MetaTreeNode node)
        {
            return Visit(node);
        }
        public  MetaTreeNode VisitNegationExpression(MetaTreeNode node)
        {
            return Visit(node);
        }
        public  MetaTreeNode VisitArithmeticMathExpression(MetaTreeNode node)
        {
            return Visit(node);
        }
        public  MetaTreeNode VisitArithmeticCompareExpression(MetaTreeNode node)
        {
            return Visit(node);
        }
        public  MetaTreeNode VisitBooleanCompareExpression(MetaTreeNode node)
        {
            return Visit(node);
        }
        public  MetaTreeNode VisitExitStatement(MetaTreeNode node)
        {
            return Visit(node);
        }
        public  MetaTreeNode VisitForLoop(MetaTreeNode node)
        {
            return Visit(node);
        }
        public  MetaTreeNode VisitRepeatLoop(MetaTreeNode node)
        {
            return Visit(node);
        }
        public  MetaTreeNode VisitIdentifierExpression(MetaTreeNode node)
        {
            return Visit(node);
        }
        public  MetaTreeNode VisitForLoopBlock(MetaTreeNode node)
        {
            return Visit(node);
        }
        public  MetaTreeNode VisitRepeatLoopBlock(MetaTreeNode node)
        {
            return Visit(node);
        }
        public  MetaTreeNode VisitIdentifierResolvedName(MetaTreeNode node)
        {
            return Visit(node);
        }
        public  MetaTreeNode VisitDigitSeqNode(MetaTreeNode node)
        {
            return Visit(node);
        }
        public  MetaTreeNode VisitBooleanIdentifierNode(MetaTreeNode node)
        {
            return Visit(node);
        }
        public MetaTreeNode VisitIdentifierNode(MetaTreeNode node)
        {
            return Visit(node);
        }
        public  MetaTreeNode VisitMemberNode(MetaTreeNode node)
        {
            return Visit(node);
        }
        public  MetaTreeNode VisitHexIdentifierNode(MetaTreeNode node)
        {
            return Visit(node);
        }
        public  MetaTreeNode VisitMemberIndexNode(MetaTreeNode node)
        {
            return Visit(node);
        }
    }
}