using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketSAEA
{
    /// <summary>
    /// 客户端信息
    /// </summary>
    public class AsyncUserToken
    {
        /// <summary>
        /// 客户端IP地址
        /// </summary>
        public IPAddress IPAddress { get; set; }

        /// <summary>
        /// 远程地址
        /// </summary>
        public EndPoint Remote { get; set; }

        /// <summary>
        /// 通信Socket
        /// </summary>
        public Socket Socket { get; set; }

        /// <summary>
        /// 链接时间
        /// </summary>
        public DateTime ConnectTime { get; set; }

        /// <summary>
        /// 用户信息
        /// </summary>
        public string UserInfo { get; set; }

        /// <summary>
        /// 缓冲数据
        /// </summary>
        public List<byte> Buffer { get; set; }

        public AsyncUserToken()
        {
            //TODO:这里需要先new？
            this.Buffer = new List<byte>();
        }
    }
}
