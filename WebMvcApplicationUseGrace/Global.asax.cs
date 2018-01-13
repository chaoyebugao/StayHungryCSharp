using Grace.MVC.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebMvcApplicationUseGrace.DependencyInjection;

namespace WebMvcApplicationUseGrace
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //获取注册容器
            var graceIocContainer = DependencyInjectionScope.GetContainer();
            //MVC指定Grace的工厂为控制器实例工厂
            ControllerBuilder.Current.SetControllerFactory(new DisposalScopeControllerActivator(graceIocContainer));
        }
    }
}
