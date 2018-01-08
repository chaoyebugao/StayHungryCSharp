using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketSAEA
{
    /// <summary>
    /// 管理SocketAsyncEventArgs的一个应用池. 有效地重复使用
    /// </summary>
    class SocketEventPool
    {
        Stack<SocketAsyncEventArgs> pool;

        public SocketEventPool(int capacity)
        {
            pool = new Stack<SocketAsyncEventArgs>(capacity);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="args"></param>
        public void Push(SocketAsyncEventArgs args)
        {
            if(args == null)
            {
                throw new ArgumentNullException("参数args不能为null");
            }
            lock (pool)
            {
                pool.Push(args);
            }
        }

        //从管理池中移出并返回
        public SocketAsyncEventArgs Pop()
        {
            lock (pool)
            {
                return pool.Pop();
            }
        }

        /// <summary>
        /// 数量
        /// </summary>
        public int Count
        {
            get
            {
                return pool.Count;
            }
        }

        /// <summary>
        /// 清除
        /// </summary>
        public void Clear()
        {
            pool.Clear();
        }
    }
}
