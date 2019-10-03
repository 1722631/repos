using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Rastaclats.Admin
{
    public partial class upload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string ProductID = Request.QueryString["ProductID"];
            string filename = ProductID + ".jpg";

            Image1.ImageUrl = "~/Image/" + filename;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string ProductID = Request.QueryString["ProductID"];

            string filename = ProductID + ".jpg";
            string saveLocation = Server.MapPath("~/Image/" + filename);

            FileUpload1.SaveAs(saveLocation);
        }
    }
}