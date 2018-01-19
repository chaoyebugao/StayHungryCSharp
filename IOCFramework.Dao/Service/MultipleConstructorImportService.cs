using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOCFramework.Dao.Service
{
    public class MultipleConstructorImportService : IMultipleConstructorImportService
    {
        IUserService userSvc;
        IAccountService accountSvc;
        public MultipleConstructorImportService(IUserService userSvc)
        {
            this.userSvc = userSvc;

            Console.WriteLine($"构造函数1：userSvc:{this.userSvc != null}, accountSvc: {this.accountSvc != null}");
            //输出：构造函数1：userSvc:True, accountSvc: False
        }


        public MultipleConstructorImportService(IAccountService accountSvc, IUserService userSvc)
            : this(userSvc)
        {
            //this.userSvc = userSvc;
            this.accountSvc = accountSvc;

            Console.WriteLine($"构造函数2：userSvc:{this.userSvc != null}, accountSvc: {this.accountSvc != null}");
            //输出：构造函数2：userSvc:True, accountSvc: True
        }

    }
}
