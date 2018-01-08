using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Grace.DependencyInjection;
using IOCFramework.Dao.Repository;
using IOCFramework.Dao.Service;
using Microsoft.AspNetCore.Mvc;
using WebApplicationUseGrace.Models;

namespace WebApplicationUseGrace.Controllers
{
    public class HomeController : Controller
    {
        //IExportLocatorScope可以获取从InjectionScope和LifeTimeScope注入的类型实例
        IExportLocatorScope locator;
        
        IAccountRepository accountRepo;
        IAccountService accountSvc;
        IUserRepository userRepo;
        IUserService userSvc;

        public HomeController(IExportLocatorScope locator, IAccountRepository accountRepo, IAccountService accountSvc, IUserService userSvc)
        {
            this.locator = locator;
            //获取简单注册实例
            this.accountRepo = accountRepo;
            this.accountSvc = accountSvc;
            //获取指定键值的实例
            this.userRepo = this.locator.Locate<IUserRepository>(withKey: "A");
            this.userSvc = userSvc;

        }

        public IActionResult Index()
        {
            return Json(new
            {
                accountRepoGet = accountRepo.Get(),
                accountSvcGet = accountSvc.Get(),
                userRepoGet = userRepo.Get(),
                userSvcGet = userSvc.Get(),
            });
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
