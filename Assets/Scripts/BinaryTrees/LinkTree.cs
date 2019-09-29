/**
 * 
 * Author:JoeyHuang
 * Time: 2019/8/26 11:28:12
 * 说明：
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTrees
{
    /// <summary>
    /// 链式存储二叉树
    /// </summary>
    public class LinkTree<T>
    {
        private Node<T> root;


        public Node<T> Root
        {
            get { return root; }
            set { root = value; }
        }

        public LinkTree()
        {
            root = null;
        }

        public LinkTree(T data)
        {
            Node<T> _node = new Node<T>(data);
            root = _node;
        }

        public LinkTree(T data,Node<T> _leftNode,Node<T> _rightNode)
        {
            Node<T> _node = new Node<T>(data, _leftNode, _rightNode);
            root = _node;
        }

        /// <summary>
        /// 获取节点p的左子节点
        /// </summary>
        /// <returns></returns>
        public Node<T> GetLeftChild(Node<T> p)
        {
            return p.LeftChild;
        }

        /// <summary>
        /// 获取节点p的右子节点
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public Node<T> GetRightNode(Node<T> p)
        {
            return p.RightChild;
        }

        public bool IsEmpty()
        {
            if (root == null) return true;
            else return false;
        }

    }


}
