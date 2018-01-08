using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grace.DependencyInjection;
using Grace.DependencyInjection.Attributes;
using IOCFramework.Dao.Repository;
using IOCFramework.Dao.Service;

namespace IOCFramework.Demo.UseGrace
{
    //项目地址：https://github.com/ipjohnson/Grace
    class GraceIOCDemo
    {
        public static void Exec()
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

            //获取简单注册实例
            var accountRepo = container.Locate<IAccountRepository>();
            Console.WriteLine(accountRepo.Get());//输出：[Account]简单注册调用[Repo]
            var accountSvc = container.Locate<IAccountService>();
            Console.WriteLine(accountSvc.Get());//输出：[Account]简单注册调用[Repo][Service]

            Console.WriteLine();

            //获取指定键值的实例
            var userRepo = container.Locate<IUserRepository>(withKey: "A");
            Console.WriteLine(userRepo.Get());//输出：[User]键值注册调用A[Repo]

            var userSvc = container.Locate<IUserService>();//输出：Ctor param1:kkkkk
            Console.WriteLine(userSvc.Get());//输出：[User]键值注册调用B[Repo][Service]
        }
    }

    


}
