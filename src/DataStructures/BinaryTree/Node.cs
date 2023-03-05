using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.BinaryTree
{
    public class Node
    {
        public Node? LeftChild { get; set; }
        public Node? RightChild { get; set; }
        public string Label { get; set; }

        public bool HasLeftChild { get => LeftChild is not null; }
        public bool HasRightChild { get => RightChild is not null; }
        public bool IsLeaf {  get => (!HasLeftChild && !HasRightChild); }

        public Node()
        {
            Label = "*";
        }

        public Node(string label)
        {
            Label = label;
            LeftChild = null;
            RightChild = null;
        }

        public Node(Node? leftChild, Node? rightChild)
        {
            Label = "*";
            LeftChild = leftChild;
            RightChild = rightChild;
        }

        public Node(string label, Node? leftChild, Node? rightChild)
        {
            Label = label;
            LeftChild = leftChild;
            RightChild = rightChild;
        }

        public List<Node> GetFringeAsList()
        {
            var fringe = new List<Node>();

            if (IsLeaf)
            {
                fringe.Add(this);
                return fringe;
            }

            if(HasLeftChild)
               fringe.AddRange(LeftChild.GetFringe());

            if (HasRightChild)
                fringe.AddRange(RightChild.GetFringe());

            return fringe;
        }

        public IEnumerable<Node> GetFringe()
        {
            var fringe = new List<Node>();

            if (IsLeaf)
            {
                yield return this;
            }

            if (HasLeftChild)
            {
                foreach (var node in LeftChild.GetFringe())
                    yield return node;
            }

            if (HasRightChild)
            {
                foreach (var node in RightChild.GetFringe())
                    yield return node;
            }
        }
    }
}
