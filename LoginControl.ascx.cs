using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class LoginControl : System.Web.UI.UserControl
    {
        public string BackColor
        {
            get { return MyTable.BgColor; }
            set { MyTable.BgColor = value; }
        }
        public string UserName
        {
            get { return MyUserName.Text; }
            set { MyUserName.Text = value; }
        }
        public string Password
        {
            get { return MyPassword.Text; }
            set { MyPassword.Text = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}