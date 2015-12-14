using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PhysicalManagementSystemApp.BLL;

namespace PhysicalManagementSystemApp.UI
{
    public partial class Login : System.Web.UI.Page
    {
        LoginManager manager=new LoginManager();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            string userName = UserNamTextBox.Text;
            string password = PassTextBox.Text;
            if (manager.Login(userName, password))
            {
                Session["UserName"] = userName;
                Session["Password"] = password;
                Response.Redirect("Home.aspx");
            }
            else
                errorLabel.Text = "User Name or password is invalid !";

        }
    }
}