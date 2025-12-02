using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace WebApplication1
{
    public partial class TryIt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private ServiceReference3.Service1Client CreateClient()
        {
            ServiceReference3.Service1Client s = new ServiceReference3.Service1Client();
            return s;
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            txtFilterOut.Text = "";
            try
            {
                var client = CreateClient();
                var cleaned = client.WordFilter(txtFilterIn.Text ?? "");
                txtFilterOut.Text = cleaned;
                fStatus.InnerText = "OK";
                fStatus.Attributes["class"] = "small ok";
            }
            catch (Exception ex)
            {
                fStatus.InnerText = "ERROR: " + ex.Message;
                fStatus.Attributes["class"] = "small err";
            }
        }

        protected void btnCountText_Click(object sender, EventArgs e)
        {
            txtCountTextOut.Text = "";
            try
            {
                var client = CreateClient();
                txtCountTextOut.Text = client.WordCountText(txtCountTextIn.Text ?? "");
            }
            catch (Exception ex)
            {
                txtCountTextOut.Text = "ERROR: " + ex.Message;
            }
        }

        protected void btnCountUrl_Click(object sender, EventArgs e)
        {
            txtCountUrlOut.Text = "";
            try
            {
                var client = CreateClient();
                txtCountUrlOut.Text = client.WordCountFromUrl(txtCountUrlIn.Text ?? "");
            }
            catch (Exception ex)
            {
                txtCountUrlOut.Text = "ERROR: " + ex.Message;
            }
        }

        protected void btnTop_Click(object sender, EventArgs e)
        {
            repTop.DataSource = null;
            repTop.DataBind();

            try
            {
                var client = CreateClient();
                var words = client.Top10ContentWords(txtTopUrlIn.Text ?? "");
                repTop.DataSource = words ?? new string[0];
                repTop.DataBind();
            }
            catch (Exception ex)
            {
                repTop.DataSource = new[] { "ERROR: " + ex.Message };
                repTop.DataBind();
            }
        }
    }
}