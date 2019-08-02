//using Antlr4.Runtime;
//using Antlr4.Runtime.Misc;
//using Antlr4.Runtime.Tree;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace STCompilerLib
//{
//    public class TreeListener : AllenBradleySTBaseListener
//    {
//        private const int MAX_SCOPE_LEVEL = 3;

//        private string mathExpression;

//        private int currentRung = 0;

//        private int scopeChildren = 0;

//        private int foundChildren = 0;

//        //defines the currentScope level, this is used to decide when to create a new rung
//        private int currentScopeLevel = 0;

//        private int prevScope = 0;

//        public List<string> Rungs = new List<string>();

//        public List<Tag> GeneratedTags = new List<Tag>();

//        private void AddToCurrentRung(string input)
//        {
//            CheckScope();

//            if (Rungs.Count <= currentRung)
//            {
//                Rungs.Add(input);
//            }
//            else
//            {
//                Rungs[currentRung] += input;
//            }
//        }

//        private void CheckScope()
//        {
//            if((currentScopeLevel == 0 && Rungs.Count != 0) || currentScopeLevel > MAX_SCOPE_LEVEL)
//            {
//                currentRung++;
//                currentScopeLevel = 0;
//            }
//        }

//        private string BuildMathAssign(string id, string exp)
//        {
//            if (exp.IndexOfAny(new char[] { '+', '-', '*', '/' }) != -1)
//            {
//                return $"{OpCodes.CPT}({id},{exp})";
//            }
//            else
//            {
//                return $"{OpCodes.MOV}({exp},{id})";
//            }
//        }

//        private string BuildMathConditional(string exp)
//        {
//            return $"{OpCodes.CMP}({exp})";
//        }

//        public override void EnterArithmaticOperator([NotNull] AllenBradleySTParser.ArithmaticOperatorContext context)
//        {
//            //mathExpression += context.
//            mathExpression += context.Start.Text;
//            base.EnterArithmaticOperator(context);
//        }

//        public override void ExitArithmaticOperator([NotNull] AllenBradleySTParser.ArithmaticOperatorContext context)
//        {
//            base.ExitArithmaticOperator(context);
//        }

//        public override void EnterArithmaticCompare([NotNull] AllenBradleySTParser.ArithmaticCompareContext context)
//        {
//            mathExpression += context.Start.Text;
//            base.EnterArithmaticCompare(context);
//        }

//        public override void EnterIdentifier([NotNull] AllenBradleySTParser.IdentifierContext context)
//        {
//            mathExpression += context.Start.Text;
//            base.EnterIdentifier(context);
//        }

//        public override void EnterPrimaryExpression([NotNull] AllenBradleySTParser.PrimaryExpressionContext context)
//        {
//            mathExpression = "";
//            base.EnterPrimaryExpression(context);
//        }

//        public override void EnterAssignment([NotNull] AllenBradleySTParser.AssignmentContext context)
//        {
//            base.ExitAssignment(context);
//        }

//        public override void ExitAssignment([NotNull] AllenBradleySTParser.AssignmentContext context)
//        {
//            AddToCurrentRung(BuildMathAssign(context.Start.Text, mathExpression));
//            base.ExitAssignment(context);
//        }

//        public override void ExitIfStatement([NotNull] AllenBradleySTParser.IfStatementContext context)
//        {
//            AddToCurrentRung(BuildMathConditional(mathExpression)); 
//            currentScopeLevel++;
//            prevScope = currentScopeLevel;


//            base.ExitIfStatement(context);
//        }

//        public override void EnterIfStatement([NotNull] AllenBradleySTParser.IfStatementContext context)
//        {
//            base.EnterIfStatement(context);
//        }

//        public override void EnterBlock([NotNull] AllenBradleySTParser.BlockContext context)
//        {
//            scopeChildren = context.ChildCount;
//            if (context.children.Count > 1)
//            {
//                Rungs[currentRung] += '[';
//            }

//            base.EnterBlock(context);

//        }

//        public override void ExitBlock([NotNull] AllenBradleySTParser.BlockContext context)
//        { 
//            if (context.children.Count > 1)
//            {
//                Rungs[currentRung] += ']';
//            }
//            scopeChildren = 0;
//            foundChildren = 0;

//            base.ExitBlock(context);
//        }

//        public override void EnterConditionalScopeEnd([NotNull] AllenBradleySTParser.ConditionalScopeEndContext context)
//        { 
//            base.EnterConditionalScopeEnd(context);
//        }

//        public override void ExitConditionalScopeEnd([NotNull] AllenBradleySTParser.ConditionalScopeEndContext context)
//        {
//            currentScopeLevel--;
//            prevScope = currentScopeLevel;
//            base.ExitConditionalScopeEnd(context);
//        }

//        public override void EnterStatement([NotNull] AllenBradleySTParser.StatementContext context)
//        {
//            foundChildren++;
//            base.EnterStatement(context);
//        }

//        public override void ExitStatement([NotNull] AllenBradleySTParser.StatementContext context)
//        { 
//            if (context.ChildCount > 1 && foundChildren < scopeChildren)
//            {
//                Rungs[currentRung] += ", ";
//            }
//            base.ExitStatement(context);
//        }
//    }
//}