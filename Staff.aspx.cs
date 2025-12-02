using System;
using System.IO;
using System.Linq;
using System.Web.Security;
using System.Web.UI;
using System.Xml.Linq;

namespace WebApplication1
{
    public partial class Staff : System.Web.UI.Page
    {
        string StaffXmlPath
        {
            get { return Server.MapPath("~/App_Data/Staff.xml"); }
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

        protected void Page_Load(object sender, EventArgs e)
        {

            var doc = LoadStaffDoc();
            if (!User.Identity.IsAuthenticated || null == FindStaff(doc, User.Identity.Name))
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