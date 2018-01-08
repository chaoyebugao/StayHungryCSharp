using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOCFramework.Dao.Repository
{
    public class UserRepositoryA : IUserRepository
    {
        public string Get()
        {
            return "[User]键值注册调用A[Repo]";
        }
    }
}
