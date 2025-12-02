using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Xml.Linq;
using ClassLibrary;

namespace WebApplication1
{
    public partial class Default : Page
    {
        string MemberXmlPath
        {
            get { return Server.MapPath("~/App_Data/Member.xml"); }
        }

        string StaffXmlPath
        {
            get { return Server.MapPath("~/App_Data/Staff.xml"); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var saved = CookieSessionHelper.GetCookie(Request, "nickname");
                if (!string.IsNullOrEmpty(saved))
                {
                    lblNick.Text = "Welcome back, " + saved;
                }
            }
        }

        void ClearMessages()
        {
            lblSignUpMsg.Text = "";
            lblLoginMsg.Text = "";
            lblChangeMsg.Text = "";
            lblStaffLoginMsg.Text = "";
        }

        XDocument LoadMemberDoc()
        {
            if (!File.Exists(MemberXmlPath))
            {
                var docNew = new XDocument(
                    new XElement("Members")
                );
                docNew.Save(MemberXmlPath);
                return docNew;
            }

            return XDocument.Load(MemberXmlPath);
        }

        XElement FindUser(XDocument doc, string username)
        {
            return doc.Root
                .Elements("Member")
                .FirstOrDefault(x =>
                    (string)x.Element("Username") == username);
        }

        void SaveMemberDoc(XDocument doc)
        {
            doc.Save(MemberXmlPath);
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

            CookieSessionHelper.SetCookie(Response, "nickname", nick, 7);
            CookieSessionHelper.SetSession(Session, "nickname", nick);

            lblNick.Text = "Saved nickname: " + nick;
        }

        protected void btnHash_Click(object sender, EventArgs e)
        {
            var input = txtHashInput.Text;
            txtHashOutput.Text = SecurityTools.HashString(input);
        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            ClearMessages();

            var user = txtSignupUser.Text.Trim();
            var pass = txtSignupPass.Text;
            var confirm = txtSignupConfirm.Text;

            if (string.IsNullOrWhiteSpace(user) ||
                string.IsNullOrWhiteSpace(pass) ||
                string.IsNullOrWhiteSpace(confirm))
            {
                lblSignUpMsg.ForeColor = Color.Red;
                lblSignUpMsg.Text = "Fill all fields for sign-up.";
                return;
            }

            if (pass != confirm)
            {
                lblSignUpMsg.ForeColor = Color.Red;
                lblSignUpMsg.Text = "Passwords do not match.";
                return;
            }

            var doc = LoadMemberDoc();
            var existing = FindUser(doc, user);
            if (existing != null)
            {
                lblSignUpMsg.ForeColor = Color.Red;
                lblSignUpMsg.Text = "User already exists.";
                return;
            }

            var hash = SecurityTools.HashString(pass);

            var member = new XElement("Member",
                new XElement("Username", user),
                new XElement("PasswordHash", hash),
                new XElement("Role", "Member")
            );

            doc.Root.Add(member);
            SaveMemberDoc(doc);

            lblSignUpMsg.ForeColor = Color.Green;
            lblSignUpMsg.Text = "Member account created.";
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            ClearMessages();

            var user = txtLoginUser.Text.Trim();
            var pass = txtLoginPass.Text;

            if (string.IsNullOrWhiteSpace(user) ||
                string.IsNullOrWhiteSpace(pass))
            {
                lblLoginMsg.ForeColor = Color.Red;
                lblLoginMsg.Text = "Enter username and password.";
                return;
            }

            var doc = LoadMemberDoc();
            var existing = FindUser(doc, user);
            if (existing == null)
            {
                lblLoginMsg.ForeColor = Color.Red;
                lblLoginMsg.Text = "Invalid login.";
                return;
            }

            var hash = SecurityTools.HashString(pass);
            var stored = (string)existing.Element("PasswordHash");

            if (!string.Equals(hash, stored, StringComparison.Ordinal))
            {
                lblLoginMsg.ForeColor = Color.Red;
                lblLoginMsg.Text = "Invalid login.";
                return;
            }

            FormsAuthentication.SetAuthCookie(user, false);
            lblLoginMsg.ForeColor = Color.Green;
            lblLoginMsg.Text = "Logged in as " + user + ".";
        }

        protected void btnChangePwd_Click(object sender, EventArgs e)
        {
            ClearMessages();

            var user = txtChangeUser.Text.Trim();
            var oldPass = txtChangeOld.Text;
            var newPass = txtChangeNew.Text;
            var confirm = txtChangeConfirm.Text;

            if (string.IsNullOrWhiteSpace(user) ||
                string.IsNullOrWhiteSpace(oldPass) ||
                string.IsNullOrWhiteSpace(newPass) ||
                string.IsNullOrWhiteSpace(confirm))
            {
                lblChangeMsg.ForeColor = Color.Red;
                lblChangeMsg.Text = "Fill all fields for password change.";
                return;
            }

            if (newPass != confirm)
            {
                lblChangeMsg.ForeColor = Color.Red;
                lblChangeMsg.Text = "New passwords do not match.";
                return;
            }

            var doc = LoadMemberDoc();
            var existing = FindUser(doc, user);
            if (existing == null)
            {
                lblChangeMsg.ForeColor = Color.Red;
                lblChangeMsg.Text = "User not found.";
                return;
            }

            var oldHash = SecurityTools.HashString(oldPass);
            var stored = (string)existing.Element("PasswordHash");

            if (!string.Equals(oldHash, stored, StringComparison.Ordinal))
            {
                lblChangeMsg.ForeColor = Color.Red;
                lblChangeMsg.Text = "Old password is incorrect.";
                return;
            }

            var newHash = SecurityTools.HashString(newPass);
            existing.SetElementValue("PasswordHash", newHash);
            SaveMemberDoc(doc);

            lblChangeMsg.ForeColor = Color.Green;
            lblChangeMsg.Text = "Password changed.";
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            ClearMessages();
            FormsAuthentication.SignOut();
            lblLoginMsg.ForeColor = Color.Green;
            lblLoginMsg.Text = "You are logged out.";
        }

        XDocument LoadStaffDoc()
        {
            if (!File.Exists(StaffXmlPath))
            {
                var docNew = new XDocument(
                    new XElement("StaffMembers")
                );
                docNew.Save(StaffXmlPath);
                return docNew;
            }

            return XDocument.Load(StaffXmlPath);
        }

        XElement FindStaff(XDocument doc, string username)
        {
            return doc.Root
                .Elements("Staff")
                .FirstOrDefault(x =>
                    (string)x.Element("UserName") == username);
        }

        protected void btnStaffLogin_Click(object sender, EventArgs e)
        {
            ClearMessages();

            var user = txtStaffUser.Text.Trim();
            var pass = txtStaffPass.Text;

            if (string.IsNullOrWhiteSpace(user) ||
                string.IsNullOrWhiteSpace(pass))
            {
                lblStaffLoginMsg.ForeColor = Color.Red;
                lblStaffLoginMsg.Text = "Enter username and password.";
                return;
            }

            var doc = LoadStaffDoc();
            var existing = FindStaff(doc, user);
            if (existing == null)
            {
                lblStaffLoginMsg.ForeColor = Color.Red;
                lblStaffLoginMsg.Text = "Invalid login.";
                return;
            }

            var hash = SecurityTools.HashString(pass);
            var stored = (string)existing.Element("PasswordHash");

            if (!string.Equals(hash, stored, StringComparison.Ordinal))
            {
                lblStaffLoginMsg.ForeColor = Color.Red;
                lblStaffLoginMsg.Text = "Invalid login.";
                return;
            }

            FormsAuthentication.SetAuthCookie(user, false);
            lblStaffLoginMsg.ForeColor = Color.Green;
            lblStaffLoginMsg.Text = "Logged in as " + user + ".";
        }

        protected void btnStaffLogout_Click(object sender, EventArgs e)
        {
            ClearMessages();
            FormsAuthentication.SignOut();
            lblStaffLoginMsg.ForeColor = Color.Green;
            lblStaffLoginMsg.Text = "You are logged out.";
        }
    }
}