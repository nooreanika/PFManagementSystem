using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PhysicalManagementSystemApp.DAL;

namespace PhysicalManagementSystemApp.UI
{
    public partial class Approved : System.Web.UI.Page
    {
        ApprovedManager manager=new ApprovedManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            PopulatedGridView();
        }
        public void PopulatedGridView()
        {

            if (manager.ApproveDetail() !=null)
            {



                ApprovedGridView.DataSource = manager.ApproveDetail();
                ApprovedGridView.DataBind();
                int sl = 1;

                for (int i = 0; i < ApprovedGridView.Rows.Count; i++)
                {

                    Label l = (Label) ApprovedGridView.Rows[i].FindControl("Label1");

                    l.Text = sl.ToString();
                    sl++;

                }


                ApprovedGridView.Columns[9].Visible = false;
            }
            else
            {
                nulMsgLabel.Text = "There is no approved application";
            }

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            //detailTextBox.Visible = true;
        }

        protected void ApprovedGridView_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

            int r = e.NewSelectedIndex;
            Label l = (Label)ApprovedGridView.Rows[r].FindControl("Label2");
            headerLabel.Text = "Application Details";
            approveLabel.Text = l.Text;



        }
    }
}