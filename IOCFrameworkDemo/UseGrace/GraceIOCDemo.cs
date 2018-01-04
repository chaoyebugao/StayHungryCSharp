using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grace.DependencyInjection;
using Grace.DependencyInjection.Attributes;

namespace IOCFrameworkDemo.UseGrace
{
    //项目地址：https://github.com/ipjohnson/Grace
    class GraceIOCDemo
    {
        public static void Exec()
        {
            var container = new DependencyInjectionContainer();

            container.Configure(m =>
            {
                //这里演示如何简单注册同一个接口对应其实现
                m.Export<AccountRepository>().As<IAccountRepository>();
                m.Export<AccountService>().As<IAccountService>();

                //这里演示如何使用键值注册同一个接口的多个实现
                m.Export<UserRepositoryA>().AsKeyed<IUserRepository>("A");
                m.Export<UserRepositoryB>().AsKeyed<IUserRepository>("B").WithCtorParam<string>(() => { return "kkkkk"; });
                //这里演示依赖倒置而使用构造器带键值注入
                m.Export<UserService>().As<IUserService>().WithCtorParam<IUserRepository>().LocateWithKey("B");
            });

            //获取实例
            var accountRepo = container.Locate<IAccountRepository>();
            Console.WriteLine(accountRepo.Get());

            var accountSvc = container.Locate<IAccountService>();
            Console.WriteLine(accountSvc.Get());

            Console.WriteLine();

            //获取指定键值的实例
            var userRepo = container.Locate<IUserRepository>(withKey: "A");
            Console.WriteLine(userRepo.Get());

            var userSvc = container.Locate<IUserService>();
            Console.WriteLine(userSvc.Get());

        }


    }

    interface IAccountRepository
    {
        string Get();
    }

    class AccountRepository : IAccountRepository
    {
        public string Get()
        {
            return "[Grace]简单注册调用[Repo]";
        }
    }

    interface IAccountService
    {
        string Get();
    }

    class AccountService : IAccountService
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

    interface IUserRepository
    {
        string Get();
    }

    class UserRepositoryA : IUserRepository
    {
        public string Get()
        {
            return "[Grace]键值注册调用A" + "[Repo]";
        }
    }

    partial class UserRepositoryB : IUserRepository
    {
        public UserRepositoryB(string param1, string param2)
        {
            Console.WriteLine($"Ctor param1:{param1}");
        }

        public string Get()
        {
            return "[Grace]键值注册调用B" + "[Repo]";
        }
    }

    interface IUserService
    {
        string Get();
    }

    class UserService : IUserService
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
