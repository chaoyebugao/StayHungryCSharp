using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOCFramework.Dao.Repository
{
    public class UserRepositoryB : IUserRepository
    {
        string param1;

        public UserRepositoryB(string param1, string param2)
        {
            this.param1 = param1;
        }

        public string Get()
        {
            return $"[User]键值注册调用B，Ctor param1:{ param1}[Repo]";
        }
    }
}
