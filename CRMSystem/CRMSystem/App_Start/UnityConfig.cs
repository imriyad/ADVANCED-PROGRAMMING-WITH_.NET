using System.Web.Http;
using Unity;
using Unity.WebApi;

using CRMSystem.BLL.Dependency; // your BLL dependency registration helper

namespace CRMSystem.App_Start
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // Register all dependencies via BLL helper
            DependencyInjection.RegisterServices(container);

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}
