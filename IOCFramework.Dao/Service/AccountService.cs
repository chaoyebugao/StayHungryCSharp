using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IOCFramework.Dao.Repository;

namespace IOCFramework.Dao.Service
{
    public class AccountService : IAccountService
    {
        IAccountRepository _accountRepository;
        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public string Get()
        {
            return _accountRepository.Get() + "[Service]";
        }
    }
}
