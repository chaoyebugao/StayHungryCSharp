using Grace.AspNetCore.MVC;
using Grace.DependencyInjection;
using IOCFramework.Dao.Repository;
using IOCFramework.Dao.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationUseGrace
{
    public partial class Startup
    {
        // 添加此方法
        public void ConfigureContainer(IInjectionScope scope)
        {
            scope.Configure(m =>
            {
                //这里演示如何简单注册同一个接口对应其实现
                m.Export<AccountRepository>().As<IAccountRepository>();
                m.Export<AccountService>().As<IAccountService>();

                //这里演示如何使用键值注册同一个接口的多个实现
                m.Export<UserRepositoryA>().AsKeyed<IUserRepository>("A");
                //这里同时演示使用带参数构造器来键值注册
                m.Export<UserRepositoryB>().AsKeyed<IUserRepository>("B").WithCtorParam<string>(() => { return "kkkkk"; });

                //这里演示依赖倒置而使用构造器带键值注入
                m.Export<UserService>().As<IUserService>().WithCtorParam<IUserRepository>().LocateWithKey("B");
            });

            scope.SetupMvc();//这一句需先添加Grace.AspNetCore.MVC
        }
    }
}
