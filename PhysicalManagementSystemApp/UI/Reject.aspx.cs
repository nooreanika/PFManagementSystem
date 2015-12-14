using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using PhysicalManagementSystemApp.BLL;

namespace PhysicalManagementSystemApp.UI
{
    public partial class Reject : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            detailsLabel.Visible = false;
            PopulateGridView();
        }
        public void PopulateGridView()
        {
            RejectManager manager = new RejectManager();
            List<Model.Application> gridList = manager.ShowReject();
            bool isFull = gridList.Any();

           
            if (isFull)
            {
                RejectGridView.DataSource = manager.ShowReject();
                RejectGridView.DataBind();


                int sl = 1;

                for (int i = 0; i < RejectGridView.Rows.Count; i++)
                {

                    Label l = (Label) RejectGridView.Rows[i].FindControl("Label1");

                    l.Text = sl.ToString();
                    sl++;

                }
                sl = 0;
            }
            else
            {
                nulMsgLabel.Text = "There is no rejected application";
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //protected void RejectGridView_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        //{

        //    string detail = detailTextBox.Text;
        //    int r = e.NewSelectedIndex;
        //    Label l = (Label)RejectGridView.Rows[r].FindControl("Label1");
        //}
        protected void RejectGridView_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            detailsLabel.Visible = true;
            int r = e.NewSelectedIndex;
            Label l = (Label)RejectGridView.Rows[r].FindControl("Label3");
            headerLabelLabel.Text = "Application Details";
            detailsLabel.Text = l.Text;

        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            detailsLabel.Visible = true;
        }
    }
}