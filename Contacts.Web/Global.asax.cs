using Ninject;
using Ninject.Web.Common.WebHost;
using System.Reflection;
using Contacts.AppService;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Contacts.Domain;
using Contacts.Domain.Interfaces.Repository;
using Contacts.Data;

namespace Contacts.Web
{
    public class MvcApplication : NinjectHttpApplication
    {
        protected override void OnApplicationStarted()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected override IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());

            kernel.Bind<INaturalPersonAppService>().To<NaturalPersonAppService>();
            kernel.Bind<ILegalPersonAppService>().To<LegalPersonAppService>();

            kernel.Bind<INaturalPersonService>().To<NaturalPersonService>();
            kernel.Bind<ILegalPersonService>().To<LegalPersonService>();

            kernel.Bind<INaturalPersonRepository>().To<NaturalPersonRepository>();
            kernel.Bind<ILegalPersonRepository>().To<LegalPersonRepository>();

            return kernel;
        }
    }
}
