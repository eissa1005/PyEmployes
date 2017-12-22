using Microsoft.Web.WebPages.OAuth;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ifind
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public class OAuthConfig
        {
            public static void RegisterProviders()
            {
                OAuthWebSecurity.RegisterGoogleClient();
                OAuthWebSecurity.RegisterFacebookClient(appId: ConfigurationManager.AppSettings["appId"], appSecret: ConfigurationManager.AppSettings["appSecret"]);
            }
        }

        //to disable cache for whole the site

        //public class DisableCache : ActionFilterAttribute
        //{
        //    public override void OnResultExecuting(ResultExecutingContext filterContext)
        //    {
        //        filterContext.HttpContext.Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
        //        filterContext.HttpContext.Response.Cache.SetValidUntilExpires(false);
        //        filterContext.HttpContext.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
        //        filterContext.HttpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //        filterContext.HttpContext.Response.Cache.SetNoStore();
        //    }
        //}

        //public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        //{
        //    filters.Add(new DisableCache());
        //}


        //or
        //protected void Application_BeginRequest()
        //{
        //    Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //    Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
        //    Response.Cache.SetNoStore();
        //}

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            GlobalFilters.Filters.Add(new AuthorizeAttribute());
            OAuthConfig.RegisterProviders();
            
        }
    }
}
