using System.Web.Mvc;
using BLL.IService;
using BLL.Service;
using DAL.UnitOfWork;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Mvc;

namespace Infrastructure
{
    public static class Bootstrapper
    {
        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            return container;
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        }

        private static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<ITemplateService, TemplateService>();
            container.RegisterType<IUnitOfWork, UnitOfWork>(new PerRequestLifetimeManager());
            //container.RegisterType(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        }
    }
}