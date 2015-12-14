using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PhysicalManagementSystemApp.BLL;
using PhysicalManagementSystemApp.Model;

namespace PhysicalManagementSystemApp.UI
{
    public partial class Organization : System.Web.UI.Page
    {
        OrganizationManager aManager ;
        protected void Page_Load(object sender, EventArgs e)
        {
            aManager = new OrganizationManager();
            if(!IsPostBack)
            {
                PopulateGridView();
            }
            
        }

          public void PopulateGridView()
        {
            List<Model.Organization> gridList = aManager.GetData();
            orgGridView.DataSource = aManager.GetData();
           orgGridView.DataBind();
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateGridView();
            
        }

        protected void addLinkButton_Click(object sender, EventArgs e)
        {
            Panel1.Visible = true;
           
        }

        protected void nameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        protected void saveButton_Click(object sender, EventArgs e)
        {

            string nam = nameTextBox.Text;
            string email = emailTextBox.Text;
            if(aManager.SaveOrganization(nam, email)== true)
            {
                Label3.Text = "save successfully";
                PopulateGridView();

            }
            else
            {
                Label3.Text = "save failed";

            }
            //nameTextBox.Text = "";
            //emailTextBox.Text = "";

        }

        protected void resetButton_Click(object sender, EventArgs e)
        {
            nameTextBox.Text = "";
            emailTextBox.Text = "";
        }

        protected void backButton_Click(object sender, EventArgs e)
        {
            //Response.Redirect["Organization.aspx"];
            Panel1.Visible = false;
        }

        protected void orgGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            

            int row = e.RowIndex;
            Label l1 = (Label)orgGridView.Rows[e.RowIndex].FindControl("Label1");
          if( aManager.DeleteData(l1.Text)==true)
          {
              Label3.Text = "deleted successfully";
              PopulateGridView();

          }
            else
          {
              Label3.Text = "deleting failed";

          }

            

        
           
        }

        protected void orgGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
          

            OrganizationManager aManager = new OrganizationManager();
            Label l1 = (Label)orgGridView.Rows[e.RowIndex].FindControl("Label1");
            TextBox l2 = (TextBox)orgGridView.Rows[e.RowIndex].FindControl("TextBox2");

            //aManager.UpdateData(l1.Text, l2.Text);
            if (aManager.UpdateData(l1.Text, l2.Text)==true)
            {
                Label3.Text = "updated successfully..";
             
                orgGridView.EditIndex = -1;

                PopulateGridView();

            }
            else
            {
                Label3.Text = "updating failed..";

            }
          

        }

        protected void orgGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            //GetData();
            aManager.GetData();
            orgGridView.EditIndex = -1;
            PopulateGridView();
        }

        protected void orgGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int row = e.NewEditIndex;
            aManager.GetData();
            orgGridView.EditIndex = row;
            PopulateGridView();
        }

   
    }
}