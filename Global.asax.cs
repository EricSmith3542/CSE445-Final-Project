using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace CSE445Project5
{
    public class Global : System.Web.HttpApplication
    {

        static string viewpagepath;
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            //RouteConfig.RegisterRoutes(RouteTable.Routes);
            //BundleConfig.RegisterBundles(BundleTable.Bundles);
            // viewpagepath= Server.MapPath("http://webstrar45.fulton.asu.edu/Page5/Default.aspx");
            viewpagepath = Server.MapPath("~/Folder/Default.aspx");

        }

        void Application_BeginRequest(object sender, EventArgs e)
        {
            string viewed = Request.PhysicalPath;
            if (viewed == viewpagepath)
            {

                Response.Write("You have already viewed this Page");
                Response.End();
            }
        }


        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}