using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.二叉树
{
    public class BTree<T> where T : IComparable<T>
    {
        /// <summary>
        /// 节点数据
        /// </summary>
        private T data;

        /// <summary>
        /// 初始构造器
        /// </summary>
        /// <param name="nodeData"></param>
        public BTree(T nodeData)
        {
            this.data = nodeData;

        }

        /// <summary>
        /// 节点数据
        /// </summary>
        public T Data
        {
            get
            {
                return this.data;
            }
        }

        /// <summary>
        /// 左节点
        /// </summary>
        public BTree<T> LeftTree { get; set; }

        /// <summary>
        /// 右节点
        /// </summary>
        public BTree<T> RightTree { get; set; }

        /// <summary>
        /// 插入子节点
        /// 存储思想，凡是小于该结点值的数据全部都在该节点的左子树中，凡是大于该结点结点值的数据全部在该节点的右子树中
        /// </summary>
        /// <param name="nodeData"></param>
        public void Insert(T nodeData)
        {
            if (this.data.CompareTo(nodeData) > 0)
            {
                InsertLeft(nodeData);
            }
            else
            {
                InsertRight(nodeData);
            }
        }

        /// <summary>
        /// 向左插入子节点
        /// </summary>
        /// <param name="nodeData"></param>
        public void InsertLeft(T nodeData)
        {
            if (this.LeftTree == null)
            {
                this.LeftTree = new BTree<T>(nodeData);
            }
            else
            {
                this.LeftTree.Insert(nodeData);
            }
        }

        /// <summary>
        /// 向右插入子节点
        /// </summary>
        /// <param name="nodeData"></param>
        public void InsertRight(T nodeData)
        {
            if (this.RightTree == null)
            {
                this.RightTree = new BTree<T>(nodeData);
            }
            else
            {
                this.RightTree.Insert(nodeData);
            }
        }

        /// <summary>
        /// 设置左节点
        /// </summary>
        /// <param name="nodeData"></param>
        public void SetLeft(T nodeData)
        {
            this.LeftTree = new BTree<T>(nodeData);
        }

        /// <summary>
        /// 设置右节点
        /// </summary>
        /// <param name="nodeData"></param>
        public void SetRight(T nodeData)
        {
            this.RightTree = new BTree<T>(nodeData);
        }


        /// <summary>
        /// 前序遍历
        /// 先根节点节点然后左子树，最后右子树
        /// </summary>
        /// <param name="root"></param>
        public void PreOrderConsoleWrite(BTree<T> root)
        {
            if (root == null)
            {
                return;
            }
            Console.WriteLine(root.Data.ToString());
            PreOrderConsoleWrite(root.LeftTree);
            PreOrderConsoleWrite(root.RightTree);
        }

        /// <summary>
        /// 前序遍历
        /// 先左子树节点然后根节点，最后右子树
        /// </summary>
        /// <param name="root"></param>
        public void InOrderConsoleWrite(BTree<T> root)
        {
            if (root == null)
            {
                return;
            }

            InOrderConsoleWrite(root.LeftTree);
            Console.WriteLine(root.Data.ToString());
            InOrderConsoleWrite(root.RightTree);
        }

        /// <summary>
        /// 前序遍历
        /// 先左子树节点然后右子树，最后根节点
        /// </summary>
        /// <param name="root"></param>
        public void PostOrderConsoleWrite(BTree<T> root)
        {
            if (root == null)
            {
                return;
            }

            PostOrderConsoleWrite(root.LeftTree);
            PostOrderConsoleWrite(root.RightTree);
            Console.WriteLine(root.Data.ToString());
        }

        /// <summary>
        /// 逐层遍历
        /// </summary>
        /// <param name="root"></param>
        public void WideOrderConsoleWrite(BTree<T> root)
        {
            if (root == null)
            {
                return;
            }
            List<BTree<T>> nodeList = new List<BTree<T>>();
            nodeList.Add(root);
            while (nodeList.Count > 0)
            {
                //当前层处理
                BTree<T> temp = nodeList[0];
                Console.WriteLine(temp.Data.ToString());
                nodeList.RemoveAt(0);

                //下一层左节点
                if (temp.LeftTree != null)
                {
                    nodeList.Add(temp.LeftTree);
                }
                //下一层右节点
                if (temp.RightTree != null)
                {
                    nodeList.Add(temp.RightTree);
                }

            }
        }

    }
}
