using System.Web.Http;
using RouteParameter = System.Web.Http.RouteParameter;

namespace Sifon.UK.Website
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(config =>
            {
                config.MapHttpAttributeRoutes();

                config.Routes.MapHttpRoute(name: "DefaultApi",
                    routeTemplate: "api/{controller}/{id}", defaults: new { id = RouteParameter.Optional }
                );
            });
        }
    }
}
