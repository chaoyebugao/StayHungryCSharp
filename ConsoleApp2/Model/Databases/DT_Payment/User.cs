using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2.Model.Databases.DT_Payment
{
    /// <summary>
    /// 数据库模型，用户
    /// </summary>
    public class User : BaseModel
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
    }
}
