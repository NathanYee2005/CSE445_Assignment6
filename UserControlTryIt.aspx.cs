using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class UserControlTryIt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                string username = LoginControl.UserName;
                if (username == "") username = "No Username Entered.";
                string password = LoginControl.Password;
                if (password == "") password = "No Password Entered.";

                outputUser.Text = "You entered the Username: " + username;
                outputPass.Text = "You entered the Password: " + password;
            }
        }
    }
}