using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using MedicalAppointmentSystem.Entities.Model;
using MedicalAppointmentSystem.Repository;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;

namespace MedicalAppointmentSystem
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //var container = new Container();
            //container.Register<IRepository<Schedule>, GenericRepository<Schedule>>();
            //container.Register<IUnitOfWork, UnitOfWork>();
            //container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            //container.Verify();
            //GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}
