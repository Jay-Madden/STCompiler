using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STCompilerLib.SyntaxTree
{
    internal enum StRules
    {
        File,
        ArithmaticMathOp,
        ArithmaticCompareOp,
        BooleanCompareOp,
        CompilationUnit,
        String,
        BooleanIdentifier,
        Identifier,
        Negative,
        IndexOperator,
        Function,
        FunctionArg,
        PrimaryExpression,
        Expression,
        Assignment,
        Statement,
        Block,
        ConditionalScopeEnd,
        LoopScopeEnd,
        CaseScopeEnd,
        Conditional,
        IfStatement,
        IfBlock,
        ElseIfStatement,
        ElseIfBlock,
        ElseBlock,
        CaseElseStatement,
        CaseStatement,
        CaseIdentifier,
        CaseBlock,
        ParensExpression,
        IdExpression,
        NegationExpression,
        ArithmaticMathExpression,
        ArithmaticCompareExpression,
        BooleanCompareExpression,
        FunctionExpression,
        ExitStatement,
        Loop,
        ForLoop,
        RepeatLoop,
        IdentifierExpression,
        ForLoopBlock
    }
}
