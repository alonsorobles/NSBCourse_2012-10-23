﻿using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Web.Mvc;
using System.Web.Routing;
using NServiceBus;
using NServiceBus.Installation.Environments;

namespace MvcApplication1
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static IBus Bus { get; private set; }

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            // Use LocalDB for Entity Framework by default
            Database.DefaultConnectionFactory = new SqlConnectionFactory(@"Data Source=(localdb)\v11.0; Integrated Security=True; MultipleActiveResultSets=True");

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            Bus = Configure.With()
                .Log4Net()
                .DefaultBuilder()
                .RijndaelEncryptionService()
                .XmlSerializer("http://acme.com")
                .InMemoryFaultManagement()
                .MsmqTransport()
                .UnicastBus()
                .DoNotAutoSubscribe()
                .CreateBus()
                .Start(() => Configure.Instance.ForInstallationOn<Windows>().Install());
        }
    }
}