using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2.Data
{
    /// <summary>
    /// 链接字符串
    /// </summary>
    public class ConnectionStrings
    {
        /// <summary>
        /// 支付中心
        /// </summary>
        public const string DT_Payment = "server=127.0.0.1;User Id=root;password=123123hs;Database=dt_payment;SslMode=None";

        /// <summary>
        /// 订单中心
        /// </summary>
        public const string DT_Order = "server=127.0.0.1;User Id=root;password=123123hs;Database=dt_order;SslMode=None";
    }
}
