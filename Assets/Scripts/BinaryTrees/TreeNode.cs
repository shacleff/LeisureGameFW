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
    public class TreeNode<T>
    {

        private T data;
        private TreeNode<T> leftChild;
        private TreeNode<T> rightChild;

        public T Data
        {
            get { return data; }
            set { data = value; }
        }

        public TreeNode<T> LeftChild
        {
            get { return leftChild; }
            set { leftChild = value; }
        }

        public TreeNode<T> RightChild
        {
            get { return rightChild; }
            set { rightChild = value; }
        }

        public TreeNode()
        {
            data = default(T);
            leftChild = null;
            rightChild = null;
        }

        public TreeNode(T val)
        {
            data = val;
            leftChild = null;
            rightChild = null;
        }



    }
}
