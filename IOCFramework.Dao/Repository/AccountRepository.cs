using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOCFramework.Dao.Repository
{
    public class AccountRepository : IAccountRepository
    {
        public string Get()
        {
            return "[Account]简单注册调用[Repo]";
        }
    }
}
