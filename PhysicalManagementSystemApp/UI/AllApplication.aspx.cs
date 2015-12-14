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
    public partial class AllApplication : System.Web.UI.Page
    {
        AllApplicationManager manager = new AllApplicationManager();
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {

                PopulateGridView();
            }



        }

        BookingHistoryByCat category = new BookingHistoryByCat();

        public void PopulateGridView()
        {
            List<Model.Application> gridList = manager.ViewAllAppliction();
            bool isFull = gridList.Any();

            if (isFull)
            {

                AllAppGridView.DataSource = manager.ViewAllAppliction();
                AllAppGridView.DataBind();


                int sl = 1;

                for (int i = 0; i < AllAppGridView.Rows.Count; i++)
                {

                    Label l = (Label) AllAppGridView.Rows[i].FindControl("Label1");

                    l.Text = sl.ToString();
                    sl++;

                }
            }
            else
            {
                nulMsgLabel.Text = "There is no applications";
            }
        }

       

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {

        }



        protected void appGridView_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            //detailLabel.Visible = true;
            //int r = e.NewSelectedIndex;
            //Label l = (Label)AllAppGridView.Rows[r].FindControl("Label4");

            //detailLabel.Text = l.Text;

        }

        protected void AllAppGridView_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            detailLabel.Visible = true;
            int r = e.NewSelectedIndex;
            Label l = (Label)AllAppGridView.Rows[r].FindControl("Label3");
            headerLabel.Text = "Application Details";
            detailLabel.Text = l.Text;
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            detailLabel.Visible = true;
        }

       

    }
}