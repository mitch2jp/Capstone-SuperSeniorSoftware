using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab1
{
    public partial class UploadProjects : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnFileUpload_Click(object sender, EventArgs e)
        {
            try
            {
                if (fileUpload.HasFile == true)
                {
                    String strPath = Request.PhysicalApplicationPath + "Student_Files\\" + fileUpload.FileName;
                    fileUpload.SaveAs(strPath);
                    lblUploadStatus.Text = "File Uploaded Successfully!";
                }
                else
                {
                    lblUploadStatus.Text = "Something went wrong!";
                }
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }
    }
}