using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketIOCPService
{
    /// <summary>
    /// 管理传输流的大小
    /// </summary>
    class BufferManager
    {
        //Buffer池控制字节数总长度
        int numBytes;
        //Buffer管理类维护的基本字节数组
        byte[] buffer;

        Stack<int> freeIndexPool;
        int currentIndex;
        int bufferSize;

        public BufferManager(int totalBytes, int bufferSize)
        {
            this.numBytes = totalBytes;
            this.currentIndex = 0;
            this.bufferSize = bufferSize;
            this.freeIndexPool = new Stack<int>();
        }

        /// <summary>
        /// 给Buffer池用的buffer分配空间
        /// </summary>
        public void InitBuffer()
        {
            //创建一个大的buffer以给每个SocketAsyncEventArg对象分配
            buffer = new byte[numBytes];
        }

        /// <summary>
        /// 从Buffer池中将一个buffer分配到指定的SocketAsyncEventArgs
        /// </summary>
        /// <param name="args"></param>
        /// <returns>buffer是否成功设置到SocketAsyncEventArgs中</returns>
        public bool SetBuffer(SocketAsyncEventArgs args)
        {
            if (freeIndexPool.Count > 0)
            {
                args.SetBuffer(buffer, freeIndexPool.Pop(), bufferSize);
            }
            else
            {
                if (numBytes - bufferSize < currentIndex)
                {
                    return false;
                }
                args.SetBuffer(buffer, currentIndex, bufferSize);
                currentIndex += bufferSize;
            }

            return true;
        }

        /// <summary>
        /// 从SocketAsyncEventArgs对象移除buffer，这里将buffer释放到Buffer池
        /// </summary>
        /// <param name="args"></param>
        public void FreeBuffer(SocketAsyncEventArgs args)
        {
            freeIndexPool.Push(args.Offset);
            args.SetBuffer(null, 0, 00);
        }
    }
}
