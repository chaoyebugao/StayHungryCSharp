using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IOCFramework.Dao.Repository;

namespace IOCFramework.Dao.Service
{
    public class UserService : IUserService
    {

        IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public string Get()
        {
            return _userRepository.Get() + "[Service]";
        }
    }
}
