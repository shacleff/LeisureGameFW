/**
 * 
 * Author:JoeyHuang
 * Time: 2019/8/25 15:23:27
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
    /// 顺序存储二叉树
    /// </summary>
    public class OrderTree<T>
    {

        private T[] data;
        private int count = 0; //当前二叉树保存的数据有多少个

        /// <summary>
        /// 二叉树容量
        /// </summary>
        /// <param name="capacity"></param>
        public OrderTree(int capacity)
        {
            data = new T[capacity];
        }

        public bool Add(T _item)
        {
            if (count >= data.Length) return false;

            data[count] = _item;
            count++;
            return true;
        }

        public void FirstTraversal()
        {

        }

        private void FirstTraversal(int index)
        {
            if (index >= count || data[index].Equals(-1)) return;
            int number = index + 1;
            T _value = data[index];
            int leftNumber = number * 2;
            int rightNumber = number * 2 + 1;
            FirstTraversal(leftNumber - 1);
            FirstTraversal(rightNumber - 1);

        }

        public void MiddleTravesal()
        {
            MiddleTravesal(0);
        }

        private void MiddleTravesal(int index)
        {
            if (index >= count || data[index].Equals(-1)) return;
            int number = index + 1;
            int leftNumber = number * 2;
            int rightNumber = number * 2 + 1;
            MiddleTravesal(leftNumber - 1);
            T _value = data[index];
            MiddleTravesal(rightNumber - 1);
        }

        public void LastTraversal()
        {
            LastTraversal(0);
        }

        private void LastTraversal(int index)
        {
            if (index >= count || data[index].Equals(-1)) return;
            int number = index + 1;
            int leftNumber = number * 2;
            int rightNumber = number * 2 + 1;
            LastTraversal(leftNumber - 1);
            LastTraversal(rightNumber - 1);
            T _value = data[index];
            
        }

        public void LayerTraversal()
        {
            for (int i = 0; i < count; i++)
            {
                if (data[i].Equals(-1)) continue;
                T _value = data[i];
            }
        }

    }
}
