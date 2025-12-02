using System;
using System.IO;
using System.Linq;
using System.Web.Security;
using System.Web.UI;
using System.Xml.Linq;

namespace WebApplication1
{
    public partial class Member : Page
    {
        string MemberXmlPath
        {
            get { return Server.MapPath("~/App_Data/Member.xml"); }
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

        protected void Page_Load(object sender, EventArgs e)
        {
            var doc = LoadMemberDoc();
            if (!User.Identity.IsAuthenticated || null == FindUser(doc, User.Identity.Name))
            {
                Response.Redirect("Default.aspx");
                return;
            }

            if (!IsPostBack)
            {
                lblUser.Text = User.Identity.Name;
            }
        }

        protected void btnBackHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("Default.aspx");
        }
    }
}