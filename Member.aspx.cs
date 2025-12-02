using System;
using System.Linq;
using System.Web.UI;
using System.Xml.Linq;
using ClassLibrary;
using WebApplication1;

namespace WebApplication1
{
    public partial class Member : Page
    {
        private string MemberXmlPath
        {
            get { return Server.MapPath("~/App_Data/Member.xml"); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlMemberArea.Visible = false;

                var sessionName = Session["memberName"] as string;
                if (!string.IsNullOrEmpty(sessionName))
                {
                    ShowMemberArea(sessionName);
                    return;
                }

                var cookieName = CookieSessionHelper.GetCookie(Request, "memberName");
                if (!string.IsNullOrEmpty(cookieName))
                {
                    txtLoginUser.Text = cookieName;
                }
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            lblRegisterStatus.Text = "";

            var user = txtNewUser.Text.Trim();
            var pass1 = txtNewPass.Text;
            var pass2 = txtNewPass2.Text;

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass1) || string.IsNullOrEmpty(pass2))
            {
                lblRegisterStatus.Text = "Please fill in all fields.";
                return;
            }

            if (pass1 != pass2)
            {
                lblRegisterStatus.Text = "Passwords do not match.";
                return;
            }

            XDocument doc;
            try
            {
                doc = XDocument.Load(MemberXmlPath);
            }
            catch
            {
                doc = new XDocument(new XElement("Members"));
            }

            var exists = doc.Root
                            .Elements("Member")
                            .Any(m => (string)m.Element("UserName") == user);

            if (exists)
            {
                lblRegisterStatus.Text = "Username already exists.";
                return;
            }

            var hash = SecurityTools.HashString(pass1);

            doc.Root.Add(
                new XElement("Member",
                    new XElement("UserName", user),
                    new XElement("PasswordHash", hash)
                )
            );

            doc.Save(MemberXmlPath);

            lblRegisterStatus.ForeColor = System.Drawing.Color.Green;
            lblRegisterStatus.Text = "Registration successful. You can now log in.";
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            lblLoginStatus.Text = "";

            var user = txtLoginUser.Text.Trim();
            var pass = txtLoginPass.Text;

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                lblLoginStatus.Text = "Enter username and password.";
                return;
            }

            XDocument doc;
            try
            {
                doc = XDocument.Load(MemberXmlPath);
            }
            catch
            {
                lblLoginStatus.Text = "No members file found.";
                return;
            }

            var hash = SecurityTools.HashString(pass);

            var match = doc.Root
                           .Elements("Member")
                           .FirstOrDefault(m =>
                               (string)m.Element("UserName") == user &&
                               (string)m.Element("PasswordHash") == hash);

            if (match == null)
            {
                lblLoginStatus.Text = "Invalid username or password.";
                return;
            }

            Session["memberName"] = user;
            CookieSessionHelper.SetCookie(Response, "memberName", user, 7);

            ShowMemberArea(user);

            lblLoginStatus.ForeColor = System.Drawing.Color.Green;
            lblLoginStatus.Text = "Login successful.";
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session["memberName"] = null;
            CookieSessionHelper.SetCookie(Response, "memberName", "", -1);

            pnlMemberArea.Visible = false;
            lblWelcome.Text = "";
            lblLoginStatus.Text = "You have been logged out.";
        }

        private void ShowMemberArea(string userName)
        {
            pnlMemberArea.Visible = true;
            lblWelcome.Text = "Welcome, " + userName;
        }
    }
}