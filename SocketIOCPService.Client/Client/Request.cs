using Newtonsoft.Json;
using SocketSAEA.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SocketSAEA.Client
{
    class Request
    {
        //TODO:不要public，不要static
        public static ClientSocketManager sManager = null;
        static string userInfo = null;

        //定义事件与委托  
        public delegate void ReceiveData(object message);
        public delegate void ServerClosed();
        public static event ReceiveData OnReceiveData;
        public static event ServerClosed OnServerClosed;

        /// <summary>  
        /// 心跳定时器  
        /// </summary>  
        static System.Timers.Timer heartTimer = null;
        /// <summary>  
        /// 心跳包  
        /// </summary>  
        static ApiResponse heartRes = null;

        /// <summary>  
        /// 判断是否已连接  
        /// </summary>  
        public static bool Connected
        {
            get { return sManager != null && sManager.Connected; }
        }

        /// <summary>  
        /// 已登录的用户信息  
        /// </summary>  
        public static string UserInfo
        {
            get { return userInfo; }
        }


        #region 基本方法  

        /// <summary>  
        /// 连接到服务器  
        /// </summary>  
        /// <returns></returns>  
        public static SocketError Connect()
        {
            if (Connected) return SocketError.Success;
            //我这里是读取配置,   
            string ip = "127.0.0.1";
            int port = 13909;
            if (string.IsNullOrWhiteSpace(ip) || port <= 1000) return SocketError.Fault;

            //创建连接对象, 连接到服务器  
            sManager = new ClientSocketManager(ip, port);
            SocketError error = sManager.Connect();
            if (error == SocketError.Success)
            {
                //连接成功后,就注册事件. 最好在成功后再注册.  
                sManager.ServerDataHandler += OnReceivedServerData;
                sManager.ServerStopEvent += OnServerStopEvent;
            }
            return error;
        }

        /// <summary>  
        /// 断开连接  
        /// </summary>  
        public static void Disconnect()
        {
            try
            {
                sManager.Disconnect();
            }
            catch (Exception) { }
        }


        /// <summary>  
        /// 发送请求  
        /// </summary>  
        /// <param name="request"></param>  
        /// <returns></returns>  
        public static bool Send(ApiResponse request)
        {
            return Send(JsonConvert.SerializeObject(request));
        }

        /// <summary>  
        /// 发送消息  
        /// </summary>  
        /// <param name="message">消息实体</param>  
        /// <returns>True.已发送; False.未发送</returns>  
        public static bool Send(string message)
        {
            if (!Connected)
            {
                return false;
            }

            byte[] buff = Encoding.UTF8.GetBytes(message);
            //加密,根据自己的需要可以考虑把消息加密  
            //buff = AESEncrypt.Encrypt(buff, m_aesKey);  
            sManager.Send(buff);
            return true;
        }


        /// <summary>  
        /// 发送字节流  
        /// </summary>  
        /// <param name="buff"></param>  
        /// <returns></returns>  
        static bool Send(byte[] buff)
        {
            if (!Connected) return false;
            sManager.Send(buff);
            return true;
        }



        /// <summary>  
        /// 接收消息  
        /// </summary>  
        /// <param name="buff"></param>  
        private static void OnReceivedServerData(byte[] buff)
        {
            //To do something  
            //你要处理的代码,可以实现把buff转化成你具体的对象, 再传给前台  
            if (OnReceiveData != null)
                OnReceiveData(buff);
        }



        /// <summary>  
        /// 服务器已断开  
        /// </summary>  
        private static void OnServerStopEvent()
        {
            if (OnServerClosed != null)
                OnServerClosed();
        }

        #endregion

        #region 心跳包  
        //心跳包也是很重要的,看自己的需要了, 我只定义出来, 你自己找个地方去调用吧  
        /// <summary>  
        /// 开启心跳  
        /// </summary>  
        private static void StartHeartbeat()
        {
            if (heartTimer == null)
            {
                heartTimer = new System.Timers.Timer();
                heartTimer.Elapsed += TimeElapsed;
            }
            heartTimer.AutoReset = true;     //循环执行  
            heartTimer.Interval = 30 * 1000; //每30秒执行一次  
            heartTimer.Enabled = true;
            heartTimer.Start();

            //初始化心跳包  
            heartRes = new ApiResponse()
            {
                 Content = "ksdof",
            };
        }

        /// <summary>  
        /// 定时执行  
        /// </summary>  
        /// <param name="source"></param>  
        /// <param name="e"></param>  
        static void TimeElapsed(object source, ElapsedEventArgs e)
        {
            Request.Send(heartRes);
        }

        #endregion
    }

    public class ApiResponse
    {
        public string Content { get; set; }
    }
}
