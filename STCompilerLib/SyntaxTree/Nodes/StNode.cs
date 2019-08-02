//using STCompilerLib.GenericTree;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace STCompilerLib.SyntaxTree.Nodes
//{
//    internal abstract class StNode : GenericTreeNode<StRules, StNode>
//    {
//        public StNode(StRules rule) : base(rule)
//        {
//        }
//        public readonly int LocalIndex;
//        public readonly int ParentChildNum;
//    }


//    internal class CompilationUnitNode : StNode
//    {

//        public CompilationUnitNode(List<BlockNode> blocks) : base(StRules.CompilationUnit)
//        {
//            Blocks = blocks;
//            ChildCount = Blocks.Count;
//        }

//        public List<BlockNode> Blocks { get; set; }

//        internal override int ChildCount { get; set; }

//        internal override GenericOptional<StRules, StNode> ChildAt(int index)
//        {
//            return Blocks[index];
//        }
//    }

//    internal abstract class ExpressionNode : StNode
//    {
//        public ExpressionNode(StRules rule) : base(rule)
//        {
//        }
//    }

//    internal class IdExpressionNode : ExpressionNode
//    {
//        public IdExpressionNode(object value) : base(StRules.IdExpression)
//        {
//            Value = new GenericTreeToken(value);
//        }

//        public GenericTreeToken Value { get; set; }

//        internal override int ChildCount { get; set; } = 1;

//        internal override GenericOptional<StRules, StNode> ChildAt(int index)
//        {
//            return Value;
//        }
//    }

//    internal class ParensExpressionNode : ExpressionNode
//    {
//        public ParensExpressionNode(ExpressionNode expression) : base(StRules.ParensExpression)
//        {
//            Expression = expression;
//        }

//        public ExpressionNode Expression { get; set; }

//        internal override int ChildCount { get; set; } = 1;

//        internal override GenericOptional<StRules, StNode> ChildAt(int index)
//        {
//            return Expression;
//        }
//    }

//    internal class NegationExpressionNode : ExpressionNode
//    {
//        public NegationExpressionNode(ExpressionNode expression) : base(StRules.NegationExpression)
//        {
//            Expression = expression;
//        }

//        public ExpressionNode Expression { get; set; }

//        internal override int ChildCount { get; set; } = 1;

//        internal override GenericOptional<StRules, StNode> ChildAt(int index)
//        {
//            return Expression;
//        }
//    }

//    internal class ArithmaticMathExpressionNode : ExpressionNode
//    {
//        public ArithmaticMathExpressionNode(ExpressionNode left, object op, ExpressionNode right)
//            : base(StRules.ArithmaticMathExpression)
//        {
//            Left = left;
//            Op = new GenericTreeToken(op);
//            Right = right;
//        }
//        public ExpressionNode Left { get; set; }

//        public GenericTreeToken Op { get; set; }

//        public ExpressionNode Right { get; set; }

//        internal override int ChildCount { get; set; } = 3;

//        internal override GenericOptional<StRules, StNode> ChildAt(int index)
//        {
//            switch (index)
//            {
//                case 0:
//                    return Left;
//                case 1:
//                    return Op;
//                case 2:
//                    return Right;
//            }
//            throw new InvalidOperationException();
//        }
//    }

//    internal class ArithmaticCompareExpressionNode : ExpressionNode
//    {
//        public ArithmaticCompareExpressionNode(ExpressionNode left, object op, ExpressionNode right)
//            : base(StRules.ArithmaticCompareExpression)
//        {
//            Left = left;
//            Op = new GenericTreeToken(op);
//            Right = right;
//        }
//        public ExpressionNode Left { get; set; }

//        public GenericTreeToken Op { get; set; }

//        public ExpressionNode Right { get; set; }

//        internal override int ChildCount { get; set; } = 3;

//        internal override GenericOptional<StRules, StNode> ChildAt(int index)
//        {
//            switch (index)
//            {
//                case 0:
//                    return Left;
//                case 1:
//                    return Op;
//                case 2:
//                    return Right;
//            }
//            throw new InvalidOperationException();
//        }
//    }

//    internal class BooleanCompareExpressionNode : ExpressionNode
//    {
//        public BooleanCompareExpressionNode(ExpressionNode left, object op, ExpressionNode right)
//            : base(StRules.BooleanCompareExpression)
//        {
//            Left = left;
//            Op = new GenericTreeToken(op);
//            Right = right;
//        }
//        public ExpressionNode Left { get; set; }

//        public GenericTreeToken Op { get; set; }

//        public ExpressionNode Right { get; set; }

//        internal override int ChildCount { get; set; } = 3;

//        internal override GenericOptional<StRules, StNode> ChildAt(int index)
//        {
//            switch (index)
//            {
//                case 0:
//                    return Left;
//                case 1:
//                    return Op;
//                case 2:
//                    return Right;
//            }
//            throw new InvalidOperationException();
//        }
//    }

//    internal class FucntionExpressionNode : ExpressionNode
//    {
//        public FucntionExpressionNode(ExpressionNode expression, List<FunctionalArgNode> args)
//            : base(StRules.Function)
//        {
//            Expression = expression;
//            Args = args;
//            ChildCount = 1 + Args.Count;
//        }

//        public ExpressionNode Expression { get; set; }

//        public List<FunctionalArgNode> Args { get; set; }

//        internal override int ChildCount { get; set; }

//        internal override GenericOptional<StRules, StNode> ChildAt(int index)
//        {
//            switch (index)
//            {
//                case 0:
//                    return Expression;
//                case int n when n > 0 && n < Args.Count:
//                    return Args[index];
//            }
//            throw new InvalidOperationException();
//        }
//    }

//    internal class FunctionalArgNode : StNode
//    {
//        public FunctionalArgNode(ExpressionNode expression) : base(StRules.FunctionArg)
//        {
//            Expression = expression;
//        }
//        public ExpressionNode Expression { get; set; }

//        internal override int ChildCount { get; set; } = 1;

//        internal override GenericOptional<StRules, StNode> ChildAt(int index)
//        {
//            return Expression;
//        }
//    }

//    internal class AssignmentNode : StNode
//    {
//        public AssignmentNode(IdentifierNode id, ExpressionNode expressionNode)
//            : base(StRules.Assignment)
//        {
//            ID = id;
//            ExpressionNode = expressionNode;
//        }

//        public IdentifierNode ID { get; set; }

//        public ExpressionNode ExpressionNode { get; set; }

//        internal override int ChildCount { get; set; } = 2;

//        internal override GenericOptional<StRules, StNode> ChildAt(int index)
//        {
//            switch (index)
//            {
//                case 0:
//                    return ID;
//                case 1:
//                    return ExpressionNode;
//            }
//            throw new InvalidOperationException();
//        }
//    }

//    internal class BlockNode : StNode
//    {
//        public BlockNode(List<StNode> blocks) : base(StRules.Block)
//        {
//            Blocks = blocks;
//            ChildCount = blocks.Count;
//        }

//        internal List<StNode> Blocks = new List<StNode>();

//        internal override int ChildCount { get; set; }

//        internal override GenericOptional<StRules, StNode> ChildAt(int index)
//        {
//            return Blocks[index];
//        }
//    }


//    internal class IdentifierNode : StNode
//    {
//        public IdentifierNode(GenericTreeToken token) : base(StRules.Identifier)
//        {
//            Token = token;
//        }

//        GenericTreeToken Token;

//        internal override int ChildCount { get; set; } = 1;

//        internal override GenericOptional<StRules, StNode> ChildAt(int index)
//        {
//            return Token;
//        }
//    }

//    internal class IfBlockNode : StNode
//    {
//        public IfBlockNode(IfStatementNode ifStatement, List<BlockNode> blocks) : base(StRules.IfBlock)
//        {
//            IfStatementNode = ifStatement;
//            Blocks = blocks;
//            ChildCount = Blocks.Count + 1;
//        }

//        public void Add(BlockNode block)
//        {
//            Blocks.Add(block);
//            ChildCount = Blocks.Count + 1;
//        }

//        internal IfStatementNode IfStatementNode;

//        internal List<BlockNode> Blocks;

//        internal override int ChildCount { get; set; }

//        internal override GenericOptional<StRules, StNode> ChildAt(int index)
//        {
//            switch (index)
//            {
//                case 0:
//                    return IfStatementNode;
//                case int n when n > 0 && n < Blocks.Count:
//                    return Blocks[index];
//            }
//            throw new InvalidOperationException();

//        }
//    }

//    internal class IfStatementNode : StNode
//    {
//        public IfStatementNode(ExpressionNode expression) : base(StRules.IfStatement)
//        {
//            Expression = expression;
//        }

//        internal ExpressionNode Expression { get; set; }

//        internal override int ChildCount { get; set; } = 1;

//        internal override GenericOptional<StRules, StNode> ChildAt(int index)
//        {
//            return Expression;
//        }
//    }

//}