/**
 * 
 * Author:JoeyHuang
 * Time: 2019/8/25 16:28:17
 * 说明：
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTrees
{
    public class Node<T>
    {

        private T data;
        private Node<T> leftChild;
        private Node<T> rightChild;

        public T Data
        {
            get { return data; }
            set { data = value; }
        }

        public Node<T> LeftChild
        {
            get { return leftChild; }
            set { leftChild = value; }
        }

        public Node<T> RightChild
        {
            get { return rightChild; }
            set { rightChild = value; }
        }

        public Node()
        {
            data = default(T);
            leftChild = null;
            rightChild = null;
        }

        public Node(T val)
        {
            data = val;
            leftChild = null;
            rightChild = null;
        }

        public Node(T data,Node<T> _leftNode,Node<T> _rightNode)
        {
            this.data = data;
            this.leftChild = _leftNode;
            this.rightChild = _rightNode;
        }

        public Node(Node<T> _leftNode,Node<T> _rightNode)
        {
            this.data = default(T);
            this.leftChild = _leftNode;
            this.rightChild = _rightNode;
        }

    }
}
