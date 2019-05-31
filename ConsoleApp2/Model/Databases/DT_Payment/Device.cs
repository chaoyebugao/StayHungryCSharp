using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2.Model.Databases.DT_Payment
{
    /// <summary>
    /// 设备
    /// </summary>
    public class Device : BaseModel
    {
        /// <summary>
        /// 设备Id
        /// </summary>
        public string DeviceId { get; set; }

        /// <summary>
        /// 设备名
        /// </summary>
        public string DeviceName { get; set; }
    }
}
