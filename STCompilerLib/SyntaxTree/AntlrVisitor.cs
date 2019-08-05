using System;
using System.Diagnostics.CodeAnalysis;
using Antlr4.Runtime.Misc;
using STCompilerLib.GenericTree;
using STCompilerLib.SyntaxTree.Nodes;

namespace STCompilerLib.SyntaxTree
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    internal class AntlrVisitor  : AllenBradleySTBaseVisitor<MetaTreeNode>
    {

        MetaTreeNode Root { get; set; }

        public override MetaTreeNode VisitCompilationUnit([NotNull] AllenBradleySTParser.CompilationUnitContext context)
        {
            Root = new MetaTreeNode(StRules.CompilationUnit);
            foreach(var node in context.children)
            {
                Root.Add(base.Visit(node));
            }
            Root.PrintChildren("", true);
            return Root; 
        }

        public override MetaTreeNode VisitDigitNode([NotNull] AllenBradleySTParser.DigitNodeContext context)
        {
            MetaTreeNode DigitNode = new MetaTreeNode(StRules.DigitSeqNode);
            DigitNode.Add(new GenericTreeToken(context.children[0]));
            return DigitNode;
        }

        /// <summary>
        /// Just a navigation method, overriddden here for consistency
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override MetaTreeNode VisitBooleanNode([NotNull] AllenBradleySTParser.BooleanNodeContext context)
        {
            return base.VisitBooleanNode(context);
        }

        public override MetaTreeNode VisitHexDigitNode([NotNull] AllenBradleySTParser.HexDigitNodeContext context)
        {
            MetaTreeNode HexNode = new MetaTreeNode(StRules.HexIdentifierNode);
            HexNode.Add(new GenericTreeToken(context.children[0]));
            return HexNode;
        }
        public override MetaTreeNode VisitHexIdNode([NotNull] AllenBradleySTParser.HexIdNodeContext context)
        {
            MetaTreeNode HexNode = new MetaTreeNode(StRules.HexIdentifierNode);
            HexNode.Add(new GenericTreeToken(context.children[0]));
            return HexNode;
        }


        public override MetaTreeNode VisitMembersIndexNode([NotNull] AllenBradleySTParser.MembersIndexNodeContext context)
        {
            MetaTreeNode MembersIndexNode = new MetaTreeNode(StRules.MemberIndexNode);
            MembersIndexNode.Add(base.Visit(context.children[0]));
            MembersIndexNode.Add(base.Visit(context.children[1]));
            return MembersIndexNode;
        }

        public override MetaTreeNode VisitMembersNode([NotNull] AllenBradleySTParser.MembersNodeContext context)
        {
            MetaTreeNode MembersNode = new MetaTreeNode(StRules.MemberNode);
            MembersNode.Add(base.Visit(context.children[0]));
            MembersNode.Add(base.Visit(context.children[2]));
            return MembersNode;
        }

        public override MetaTreeNode VisitBooleanIdentifier([NotNull] AllenBradleySTParser.BooleanIdentifierContext context)
        {
            MetaTreeNode BooleanNode = new MetaTreeNode(StRules.BooleanIdentifierNode);
            BooleanNode.Add(new GenericTreeToken(context.children[0]));
            return BooleanNode;
        }


        public override MetaTreeNode VisitIdNode([NotNull] AllenBradleySTParser.IdNodeContext context)
        {
            MetaTreeNode IdNode = new MetaTreeNode(StRules.IdentifierNode);
            IdNode.Add(new GenericTreeToken(context.children[0]));
            return IdNode;
        }

        //public override MetaTreeNode VisitIdentifier([NotNull] AllenBradleySTParser.IdentifierContext context)
        //{
        //    MetaTreeNode Operator = new MetaTreeNode(StRules.Identifier);
        //    if(context.children.Count > 1)
        //    {
        //        foreach (var node in context.children)
        //        {
        //            Operator.Add(base.Visit(node));
        //        }
        //    }
        //    else
        //    {
        //        Operator.Add(new GenericTreeToken(context.children[0]));
        //    }

        //    return Operator;
        //}

        public override MetaTreeNode VisitIdentifierResolvedName([NotNull] AllenBradleySTParser.IdentiferResolvedNameContext context)
        {
            MetaTreeNode IdResolvedNode = new MetaTreeNode(StRules.IdentifierResolvedName);
            IdResolvedNode.Add(base.Visit(context.children[0]));
            return IdResolvedNode;
        }

        public override MetaTreeNode VisitBlock([NotNull] AllenBradleySTParser.BlockContext context)
        {
            MetaTreeNode BlockNode = new MetaTreeNode(StRules.Block);
            foreach (var node in context.children)
            {
                BlockNode.Add(base.Visit(node));
            }
            return BlockNode;
        }

        public override MetaTreeNode VisitConditional([NotNull] AllenBradleySTParser.ConditionalContext context)
        {
            MetaTreeNode ConditionalNode = new MetaTreeNode(StRules.Conditional);
            foreach (var node in context.children)
            {
                ConditionalNode.Add(base.Visit(node));
            }
            return ConditionalNode;
        }

        public override MetaTreeNode VisitPrimaryExpression([NotNull] AllenBradleySTParser.PrimaryExpressionContext context)
        {
            MetaTreeNode PrimaryExpression = new MetaTreeNode(StRules.PrimaryExpression);

            foreach (var node in context.children)
            {
                PrimaryExpression.Add(base.Visit(node));
            }
            return PrimaryExpression;
        }

        public override MetaTreeNode VisitIfStatement([NotNull] AllenBradleySTParser.IfStatementContext context)
        {
            MetaTreeNode IfNode = new MetaTreeNode(StRules.IfStatement);
            IfNode.Add(base.Visit(context.children[1]));
            return IfNode;
        }

        public override MetaTreeNode VisitIfBlock([NotNull] AllenBradleySTParser.IfBlockContext context)
        {
            MetaTreeNode IfBlock = new MetaTreeNode(StRules.IfBlock);
            foreach (var node in context.children)
            {
                IfBlock.Add(base.Visit(node));
            }
            return IfBlock;
        }

        public override MetaTreeNode VisitArithmeticOperator([NotNull] AllenBradleySTParser.ArithmaticOperatorContext context)
        {
            MetaTreeNode Operator = new MetaTreeNode(StRules.ArithmeticMathOp);
            Operator.Add(new GenericTreeToken(context.children[0]));
            return Operator;
        }

        public override MetaTreeNode VisitNegationExpression([NotNull] AllenBradleySTParser.NegationExpressionContext context)
        {
            MetaTreeNode NegationNode = new MetaTreeNode(StRules.NegationExpression);
            NegationNode.Add(base.Visit(context.children[0]));
            NegationNode.Add(base.Visit(context.children[1]));
            return NegationNode;
        }

        public override MetaTreeNode VisitArithmaticMathExpression([NotNull] AllenBradleySTParser.ArithmaticMathExpressionContext context)
        {
            MetaTreeNode ArithmaticMathNode = new MetaTreeNode(StRules.ArithmeticMathExpression);
            foreach (var node in context.children)
            {
                ArithmaticMathNode.Add(base.Visit(node));
            }
            return ArithmaticMathNode;
        }

        public override MetaTreeNode VisitBooleanCompareExpression([NotNull] AllenBradleySTParser.BooleanCompareExpressionContext context)
        {
            MetaTreeNode BooleanExpNode = new MetaTreeNode(StRules.BooleanCompareExpression);
            foreach (var node in context.children)
            {
                BooleanExpNode.Add(base.Visit(node));
            }
            return BooleanExpNode;
        }

        public override MetaTreeNode VisitIdentifierExpression([NotNull] AllenBradleySTParser.IdentifierExpressionContext context)
        {
            MetaTreeNode Id = new MetaTreeNode(StRules.IdentifierExpression);
            Id.Add(base.Visit(context.children[0]));
            return Id;
        }

        public override MetaTreeNode VisitSubExpression([NotNull] AllenBradleySTParser.SubExpressionContext context)
        {
            MetaTreeNode SubNode = new MetaTreeNode(StRules.ParensExpression);
            SubNode.Add(base.Visit(context.children[1]));
            return SubNode;
        }

        public override MetaTreeNode VisitArithmaticCompareExpression([NotNull] AllenBradleySTParser.ArithmaticCompareExpressionContext context)
        {
            MetaTreeNode ArithmaticCompareExpressionNode = new MetaTreeNode(StRules.ArithmeticCompareExpression);
            foreach (var node in context.children)
            {
                ArithmaticCompareExpressionNode.Add(base.Visit(node));
            }
            return ArithmaticCompareExpressionNode;
        }

        public override MetaTreeNode VisitArithmaticCompare([NotNull] AllenBradleySTParser.ArithmaticCompareContext context)
        {
            MetaTreeNode Operator = new MetaTreeNode(StRules.ArithmeticCompareOp);
            Operator.Add(new GenericTreeToken(context.children[0]));
            return Operator;
        }

        public override MetaTreeNode VisitAssignment([NotNull] AllenBradleySTParser.AssignmentContext context)
        {

            MetaTreeNode AssignNode = new MetaTreeNode(StRules.Assignment);
            AssignNode.Add(base.Visit(context.children[0])); 
            AssignNode.Add(base.Visit(context.children[2])); 

            return AssignNode;
        }

        public override MetaTreeNode VisitStatement([NotNull] AllenBradleySTParser.StatementContext context)
        {
            MetaTreeNode StatementNode = new MetaTreeNode(StRules.Statement);
            StatementNode.Add(base.Visit(context.children[0]));
            return StatementNode;
        }

        public override MetaTreeNode VisitElseIfStatement([NotNull] AllenBradleySTParser.ElseIfStatementContext context)
        {
            MetaTreeNode ElseIfNode = new MetaTreeNode(StRules.ElseIfStatement);
            ElseIfNode.Add(base.Visit(context.children[1]));
            return ElseIfNode;
        }

        public override MetaTreeNode VisitElseIfBlock([NotNull] AllenBradleySTParser.ElseIfBlockContext context)
        {
            MetaTreeNode ElseIfBlockNode = new MetaTreeNode(StRules.ElseIfBlock);
            foreach (var node in context.children)
            {
                ElseIfBlockNode.Add(base.Visit(node));
            }
            return ElseIfBlockNode;
        }

        public override MetaTreeNode VisitElseBlock([NotNull] AllenBradleySTParser.ElseBlockContext context)
        {

            MetaTreeNode ElseBlockNode = new MetaTreeNode(StRules.ElseBlock);
            ElseBlockNode.Add(base.Visit(context.children[1]));
            return ElseBlockNode;
        }

        public override MetaTreeNode VisitCaseElseStatement([NotNull] AllenBradleySTParser.CaseElseStatementContext context)
        {
            MetaTreeNode CaseElseNode = new MetaTreeNode(StRules.CaseStatement);
            CaseElseNode.Add(base.Visit(context.children[1]));
            return CaseElseNode;
        }

        public override MetaTreeNode VisitCaseStatement([NotNull] AllenBradleySTParser.CaseStatementContext context)
        {
            MetaTreeNode CaseStatementNode = new MetaTreeNode(StRules.CaseStatement);
            CaseStatementNode.Add(base.Visit(context.children[1]));
            return CaseStatementNode;
        }

        public override MetaTreeNode VisitCaseIdentifier([NotNull] AllenBradleySTParser.CaseIdentifierContext context)
        {
            MetaTreeNode CaseIdNode = new MetaTreeNode(StRules.CaseIdentifier);
            CaseIdNode.Add(new GenericTreeToken(context.children[0]));
            return CaseIdNode;
        }

        public override MetaTreeNode VisitCaseBlock([NotNull] AllenBradleySTParser.CaseBlockContext context)
        {
            MetaTreeNode CaseBlockNode = new MetaTreeNode(StRules.CaseBlock);
            foreach (var node in context.children)
            {
                CaseBlockNode.Add(base.Visit(node));
            }
            return CaseBlockNode;
        }

        public override MetaTreeNode VisitExitStatement([NotNull] AllenBradleySTParser.ExitStatementContext context)
        {
            MetaTreeNode ExitNode = new MetaTreeNode(StRules.ExitStatement);
            ExitNode.Add(base.Visit(context.children[0]));
            return ExitNode;
        }

        public override MetaTreeNode VisitBooleanCompare([NotNull] AllenBradleySTParser.BooleanCompareContext context)
        {
            throw new NotImplementedException();
            return base.VisitBooleanCompare(context);
        }

        public override MetaTreeNode VisitString([NotNull] AllenBradleySTParser.StringContext context)
        {
            MetaTreeNode StringNode = new MetaTreeNode(StRules.String);
            StringNode.Add(new GenericTreeToken(context.children[0]));
            return StringNode;
        }

        public override MetaTreeNode VisitIndexOperator([NotNull] AllenBradleySTParser.IndexOperatorContext context)
        {
            MetaTreeNode IndexOperatorNode = new MetaTreeNode(StRules.IndexOperator);
            IndexOperatorNode.Add(base.Visit(context.children[1]));
            return IndexOperatorNode;
        }

        public override MetaTreeNode VisitFunction([NotNull] AllenBradleySTParser.FunctionContext context)
        {
            MetaTreeNode FunctionNode = new MetaTreeNode(StRules.Function);
            FunctionNode.Add(base.Visit(context.children[0]));
            for (int i = 1; i < context.children.Count; i++)
            {
                FunctionNode.Add(base.Visit(context.children[i]));
            }
            return FunctionNode;
        }

        public override MetaTreeNode VisitFunctionArg([NotNull] AllenBradleySTParser.FunctionArgContext context)
        {
            MetaTreeNode FuncArgNode = new MetaTreeNode(StRules.FunctionArg);
            FuncArgNode.Add(base.Visit(context.children[0]));
            return FuncArgNode;
        }

        public override MetaTreeNode VisitConditionalScopeEnd([NotNull] AllenBradleySTParser.ConditionalScopeEndContext context)
        {
            return base.VisitConditionalScopeEnd(context);
        }

        public override MetaTreeNode VisitLoopScopeEnd([NotNull] AllenBradleySTParser.LoopScopeEndContext context)
        {
            return base.VisitLoopScopeEnd(context);
        }

        public override MetaTreeNode VisitCaseScopeEnd([NotNull] AllenBradleySTParser.CaseScopeEndContext context)
        {
            return base.VisitCaseScopeEnd(context);
        }
        public override MetaTreeNode VisitForLoop([NotNull] AllenBradleySTParser.ForLoopContext context)
        {
            MetaTreeNode ForLoopNode = new MetaTreeNode(StRules.ForLoop);
            ForLoopNode.Add(base.Visit(context.children[1]));
            ForLoopNode.Add(base.Visit(context.children[3]));

            if(context.children.Count > 5)
            {
                ForLoopNode.Add(base.Visit(context.children[5]));
            }

            return ForLoopNode;
        }

        public override MetaTreeNode VisitRepeatLoop([NotNull] AllenBradleySTParser.RepeatLoopContext context)
        {
            MetaTreeNode RepeatLoopNode = new MetaTreeNode(StRules.RepeatLoop);
            RepeatLoopNode.Add(base.Visit(context.children[1]));
            return RepeatLoopNode;
        }

        public override MetaTreeNode VisitForLoopBlock([NotNull] AllenBradleySTParser.ForLoopBlockContext context)
        {
            MetaTreeNode ForLoopBlockNode = new MetaTreeNode(StRules.ForLoopBlock);
            for (int i = 0; i < context.children.Count-1; i++)
            {
                ForLoopBlockNode.Add(base.Visit(context.children[i]));
            }
            return ForLoopBlockNode;
        }

        public override MetaTreeNode VisitRepeatLoopBlock([NotNull] AllenBradleySTParser.RepeatLoopBlockContext context)
        {
            MetaTreeNode RepeatLoopBlockNode = new MetaTreeNode(StRules.RepeatLoopBlock);
            RepeatLoopBlockNode.Add(base.Visit(context.children[context.children.Count - 2]));
            for(int i = 1; i < context.children.Count - 2; i++)
            {
                RepeatLoopBlockNode.Add(base.Visit(context.children[i]));
            }
            return RepeatLoopBlockNode;
        }

    }

}
