using MedicalAppointmentSystem.BussinessLogic.ScheduleDoctor;
using MedicalAppointmentSystem.Entities;
using MedicalAppointmentSystem.Entities.Model;
using MedicalAppointmentSystem.Repository;

[assembly: WebActivator.PostApplicationStartMethod(typeof(MedicalAppointmentSystem.App_Start.SimpleInjectorWebApiInitializer), "Initialize")]

namespace MedicalAppointmentSystem.App_Start
{
    using System.Web.Http;
    using SimpleInjector;
    using SimpleInjector.Integration.WebApi;
    
    public static class SimpleInjectorWebApiInitializer
    {
        /// <summary>Initialize the container and register it as Web API Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new SimpleInjector.Lifestyles.AsyncScopedLifestyle();


            InitializeContainer(container);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
       
            container.Verify();
            
            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
        }
     
        private static void InitializeContainer(Container container)
        {
            container.Register<ApplicationContext>(Lifestyle.Scoped);
            container.Register<IRepository<Schedule>, GenericRepository<Schedule>>(Lifestyle.Scoped);
            container.Register<IRepository<ScheduleDoctor>, GenericRepository<ScheduleDoctor>>(Lifestyle.Scoped);
            container.Register<IScheduleDoctorLogic, ScheduleDoctorLogic>(Lifestyle.Scoped);
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
        }
    }
}