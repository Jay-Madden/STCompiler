using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using STCompilerLib.GenericTree;
using STCompilerLib.SyntaxTree;
using STCompilerLib.SyntaxTree.Nodes;
using System.Runtime.CompilerServices;

namespace STCompilerLib
{
    internal class Visitor  : AllenBradleySTBaseVisitor<MetaTreeNode>
    {

        public string LineOut { get; set; }

        MetaTreeNode Root; 

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

        public override MetaTreeNode VisitIdentifier([NotNull] AllenBradleySTParser.IdentifierContext context)
        {
            MetaTreeNode Operator = new MetaTreeNode(StRules.Identifier);
            if(context.children.Count > 1)
            {
                foreach (var node in context.children)
                {
                    Operator.Add(base.Visit(node));
                }
            }
            else
            {
                Operator.Add(new GenericTreeToken(context.children[0]));
            }

            return Operator;
        }

        public override MetaTreeNode VisitIdentiferResolvedName([NotNull] AllenBradleySTParser.IdentiferResolvedNameContext context)
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

        public override MetaTreeNode VisitArithmaticOperator([NotNull] AllenBradleySTParser.ArithmaticOperatorContext context)
        {
            MetaTreeNode Operator = new MetaTreeNode(StRules.ArithmaticMathOp);
            Operator.Add(new GenericTreeToken(context.children[0]));
            return Operator;
        }

        public override MetaTreeNode VisitNegationExpression([NotNull] AllenBradleySTParser.NegationExpressionContext context)
        {
            return base.VisitNegationExpression(context);
        }

        public override MetaTreeNode VisitArithmaticMathExpression([NotNull] AllenBradleySTParser.ArithmaticMathExpressionContext context)
        {
            MetaTreeNode ArithmaticMathNode = new MetaTreeNode(StRules.ArithmaticMathExpression);
            foreach (var node in context.children)
            {
                ArithmaticMathNode.Add(base.Visit(node));
            }
            return ArithmaticMathNode;
        }

        public override MetaTreeNode VisitBooleanCompareExpression([NotNull] AllenBradleySTParser.BooleanCompareExpressionContext context)
        {
            return base.VisitBooleanCompareExpression(context);
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
            MetaTreeNode ArithmaticCompareExpressionNode = new MetaTreeNode(StRules.ArithmaticCompareExpression);
            foreach (var node in context.children)
            {
                ArithmaticCompareExpressionNode.Add(base.Visit(node));
            }
            return ArithmaticCompareExpressionNode;
        }

        public override MetaTreeNode VisitArithmaticCompare([NotNull] AllenBradleySTParser.ArithmaticCompareContext context)
        {
            MetaTreeNode Operator = new MetaTreeNode(StRules.ArithmaticCompareOp);
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
            return base.VisitBooleanCompare(context);
        }

        public override MetaTreeNode VisitString([NotNull] AllenBradleySTParser.StringContext context)
        {
            return base.VisitString(context);
        }

        public override MetaTreeNode VisitBooleanIdentifier([NotNull] AllenBradleySTParser.BooleanIdentifierContext context)
        {
            return base.VisitBooleanIdentifier(context);
        }

        public override MetaTreeNode VisitNegative([NotNull] AllenBradleySTParser.NegativeContext context)
        {
            return base.VisitNegative(context);
        }

        public override MetaTreeNode VisitIndexOperator([NotNull] AllenBradleySTParser.IndexOperatorContext context)
        {
            return base.VisitIndexOperator(context);
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
