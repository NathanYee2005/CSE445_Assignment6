using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace WebApplication1
{
    public partial class ServiceTryIt : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void upload_Click(object sender, EventArgs e)
        {
            if (FileUpload.HasFile && FileUpload.FileName.Contains(".txt"))
            {
                string fileName = Path.GetFileName(FileUpload.FileName);

                string serverPath = Server.MapPath("~/App_Data/" + fileName);
                FileUpload.SaveAs(serverPath);

                status.Text = "Uploaded successfully: " + fileName;

                ServiceReference1.Service1Client countService = new ServiceReference1.Service1Client();
                string text = File.ReadAllText(serverPath);
                string count = countService.WordCount(text);
                output.Text = count;
            }
            else
            {
                status.Text = "Invalid File Selected";
            }
        }
    }
}