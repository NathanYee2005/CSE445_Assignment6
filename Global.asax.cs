using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace WebApplication1
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Error(object sender, EventArgs e)
        {
            // handle error
            Exception ex = Server.GetLastError().GetBaseException();
            Response.Write("Global Error: " + ex.Message);
            Server.ClearError();
        }
    }
}