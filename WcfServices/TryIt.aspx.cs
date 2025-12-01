using System;
using System.ServiceModel;
using WcfServices;

namespace WcfServices
{
    public partial class TryIt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var baseUrl = Request.Url.GetLeftPart(UriPartial.Authority);
            var svcUrl = new Uri(new Uri(baseUrl), ResolveUrl("~/Service1.svc")).ToString();
            litSvcUrl.Text = $"<a href=\"{svcUrl}\">{svcUrl}</a>";
            litWsdlUrl.Text = $"<a href=\"{svcUrl}?wsdl\">{svcUrl}?wsdl</a>";

            if (!IsPostBack)
            {
                txtCountUrlIn.Text = "https://example.com";
                txtTopUrlIn.Text = "https://example.com";
            }
        }

        // Creates a real HTTP client for IService1 using BasicHttpBinding
        private IService1 CreateClient()
        {
            var baseUrl = Request.Url.GetLeftPart(UriPartial.Authority);
            var svcUrl = new Uri(new Uri(baseUrl), ResolveUrl("~/Service1.svc"));

            var binding = new BasicHttpBinding
            {
                MaxReceivedMessageSize = 10 * 1024 * 1024, // allow big pages
                ReaderQuotas =
                {
                    MaxStringContentLength = 10 * 1024 * 1024
                }
            };

            var address = new EndpointAddress(svcUrl);
            var factory = new ChannelFactory<IService1>(binding, address);
            return factory.CreateChannel();
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