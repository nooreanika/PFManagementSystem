using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PhysicalManagementSystemApp.BLL;

namespace PhysicalManagementSystemApp.UI
{
    
    public partial class Home : System.Web.UI.Page
    {
        BookingManager manager=new BookingManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            welcomeLabel.Text ="Welcome "+ Session["UserName"].ToString();
            if (manager.CountNewApp() > 0)
            {
                notificationLabel.Text = Convert.ToString(manager.CountNewApp());
            }
            else
            {
                notificationLabel.Text = "0";
            }
        }

        protected void showAppLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Application.aspx");
        }
    }
}