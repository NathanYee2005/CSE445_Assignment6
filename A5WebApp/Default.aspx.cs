using System;
using System.Web.UI;
using ClassLibrary;          // SecurityTools in your DLL

namespace A5WebApp
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // If we already saved a nickname, show it
                var saved = CookieSessionHelper.GetCookie(Request, "nickname");
                if (!string.IsNullOrEmpty(saved))
                {
                    lblNick.Text = "Welcome back, " + saved;
                }
            }
        }

        protected void btnMember_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Member.aspx");
        }

        protected void btnStaff_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Staff.aspx");
        }

        protected void btnSaveNick_Click(object sender, EventArgs e)
        {
            var nick = txtNick.Text.Trim();
            if (nick.Length == 0)
            {
                lblNick.Text = "Enter a nickname first.";
                return;
            }

            // store in cookie + session for Assignment 5 local component demo
            CookieSessionHelper.SetCookie(Response, "nickname", nick, 7);
            CookieSessionHelper.SetSession(Session, "nickname", nick);

            lblNick.Text = "Saved nickname: " + nick;
        }

        protected void btnHash_Click(object sender, EventArgs e)
        {
            var input = txtHashInput.Text;
            txtHashOutput.Text = SecurityTools.HashString(input);
        }
    }
}