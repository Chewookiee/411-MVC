using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using FoamMVC.BLL.CRUD.StagedItemsOperations;
using FoamMVC.CloverReader;
using FoamMVC.DTOs;
using Newtonsoft.Json;
using RestSharp;

namespace FoamMVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

           CloverClient.Run();
        }
    }
}
