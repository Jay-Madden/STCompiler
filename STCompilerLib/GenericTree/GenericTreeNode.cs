using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STCompilerLib.GenericTree
{
    internal abstract class GenericTreeNode<TTreeRule, TTreeNode> 
        where TTreeRule : struct
        where TTreeNode : GenericTreeNode<TTreeRule, TTreeNode>
    {

        public readonly TTreeRule Kind;

        protected GenericTreeNode(TTreeRule kind)
        {
            Kind = kind;
        }

        //internal abstract int ChildCount { get; set; }

        public abstract List<GenericOptional<TTreeRule, TTreeNode>> Children { get; set; }

        public Enumerator GetEnumerator()
            => new Enumerator(this);

        protected abstract GenericOptional<TTreeRule, TTreeNode> ChildAt(int index);
 
        public struct Enumerator
        {
            private readonly GenericTreeNode<TTreeRule, TTreeNode> _node;
            private readonly int _childCount;
            private int _currentIndex;
 
            public Enumerator(GenericTreeNode<TTreeRule, TTreeNode> node)
            {
                _node = node;
                _childCount = _node.Children.Count;
                _currentIndex = -1;
                Current = default;
            }
 
            public GenericOptional<TTreeRule, TTreeNode> Current { get; private set; }

            public bool MoveNext()
            {
                _currentIndex++;
                if (_currentIndex >= _childCount)
                {
                    Current = default;
                    return false;
                }
 
                Current = _node.ChildAt(_currentIndex);
                return true;
            }
        }
    }
}