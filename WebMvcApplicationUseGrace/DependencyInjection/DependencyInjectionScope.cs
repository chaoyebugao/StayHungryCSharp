using Grace.DependencyInjection;
using IOCFramework.Dao.Repository;
using IOCFramework.Dao.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMvcApplicationUseGrace.DependencyInjection
{
    public class DependencyInjectionScope
    {
        public static DependencyInjectionContainer GetContainer()
        {
            //容器
            var container = new DependencyInjectionContainer();
            container.Configure(m =>
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

            return container;
        }
    }
}