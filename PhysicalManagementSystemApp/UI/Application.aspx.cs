using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using PhysicalManagementSystemApp.BLL;
using PhysicalManagementSystemApp.Model;


namespace PhysicalManagementSystemApp.UI
{
    public partial class Application : System.Web.UI.Page
    {
        private Label faciLabel;
        ApplicationManager manager = new ApplicationManager();
        BookingManager bManager = new BookingManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            CountApp();


            if (!IsPostBack)
            {
                CountApp();
                string appid = "Choose";
                PopulateAppID();

                PopulateGridView(appid);
            }



        }
        protected void PopulateAppID()
        {
            string connection = ConfigurationManager.ConnectionStrings["PhysicalFacilityConDB"].ConnectionString;
            SqlConnection conn = new SqlConnection(connection);
            string query = "Select distinct appid From Application_Det Where Status='New'";
            SqlCommand command = new SqlCommand(query, conn);

            SqlDataReader dr;

            conn.Open();
            dr = command.ExecuteReader();

            DropDownList1.Items.Add("Choose");
            while (dr.Read())
            {
                DropDownList1.Items.Add(dr.GetValue(0).ToString());
            }
            conn.Close();
        }

        BookingHistoryByCat category = new BookingHistoryByCat();

        public void PopulateGridView(string appid)
        {

            List<Model.Application> gridList = manager.GetAllAppliction(appid);
            bool isFull = gridList.Any();

            if (isFull)
            {

                appGridView.DataSource = manager.GetAllAppliction(appid);
                appGridView.DataBind();


                int sl = 1;

                for (int i = 0; i < appGridView.Rows.Count; i++)
                {

                    Label l = (Label)appGridView.Rows[i].FindControl("Label2");

                    l.Text = sl.ToString();
                    sl++;


                }
            }
            else
            {
                nullMsgLabel.Text = "There is no new application";
                remarkTextBox.Visible = false;
                ApprButton.Visible = false;
                rejectButton.Visible = false;
                remarkLabel.Text = "";

            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {

        }



        protected void appGridView_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            detailsLabel.Visible = true;
            int r = e.NewSelectedIndex;
            Label l = (Label)appGridView.Rows[r].FindControl("Label4");
            headerlabel.Visible = true;
            headerlabel.Text = "Application Details";
            detailsLabel.Text = l.Text;

        }

        protected void catDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

        }

        //protected void ApprButton_Click(object sender, EventArgs e)
        //{
        //    Model.Application newApplication=new Model.Application();



        //    countLabel.Text=Convert.ToString(bManager.CountNewApp());
        //    newApplication.Status = "Approved";//Application Status

        //    newApplication.AppId = Label7.Text;
        //    newApplication.BookingStatus = "Pending";//Booking Status
        //    newApplication.UserName = Convert.ToString(Session["UserName"]);
        //    newApplication.prrocessingTime= DateTime.Now;
        //    newApplication.Remark = remarkTextBox.Text;
        //    newApplication.FaciId = facilityLabel.Text;
        //    int test=  manager.UpdateStatus(newApplication);
        //    if (test > 0)
        //    {
        //        notificLabel.Text = "Application Approved succesfully";
        //    }
        //    else
        //    {
        //        notificLabel.Text = "Application Approving failed";
        //    }


        //    PopulateGridView(); 


        //}

        protected void appRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            //foreach (GridViewRow oldrow in appGridView.Rows)
            //{
            //    ((RadioButton)oldrow.FindControl("appRadioButton")).Checked = false;
            //}
            //RadioButton rb = (RadioButton)sender;
            //GridViewRow row = (GridViewRow)rb.NamingContainer;
            //((RadioButton)row.FindControl("appRadioButton")).Checked = true;
            //int rowindex = row.RowIndex;
            //for (int i = 0; i < appGridView.Rows.Count; i++)
            //{
            //    RadioButton r = (RadioButton)appGridView.Rows[i].FindControl("appRadioButton");
            //    if (r.Checked == true)
            //    {
            //        Label l = (Label)appGridView.Rows[i].FindControl("Label3");
            //        //Session["AppId"] = l.Text;


            //        Label7.Text = l.Text;
            //        Label label = (Label)appGridView.Rows[i].FindControl("facIDLabel");
            //        facilityLabel.Text = label.Text;



            //        break;
            //    }
            //}
        }

        protected void rejButton_Click(object sender, EventArgs e)
        {

        }

        protected void rejectButton_Click(object sender, EventArgs e)
        {
            Model.Application newApplication = new Model.Application();



            countLabel.Text = Convert.ToString(bManager.CountNewApp());
            newApplication.Status = "Rejected";//Application Status
            if (Session["AppId"] != null)
            {

                //notificLabel.Text = "successfully done";
                newApplication.AppId = Session["AppId"].ToString();
                newApplication.AppId = Label7.Text;
                newApplication.BookingStatus = "Rejected";//Booking Status
                newApplication.UserName = Convert.ToString(Session["UserName"]);
                newApplication.prrocessingTime = DateTime.Now;
                //changes happen here ..........empty validation & length...start//
                if (remarkTextBox.Text == "")
                {
                    nullMsgLabel.Visible = true;
                    nullMsgLabel.Text = "No Reason";
                    newApplication.Remark = nullMsgLabel.Text;
                }
                else if (remarkTextBox.Text.Length > 500)
                {
                    nullMsgLabel.Text = "Your word should be less than 500 characters";
                    newApplication.Remark = nullMsgLabel.Text;

                }
                else
                    newApplication.Remark = remarkTextBox.Text;
                //changes happen here ..........empty validation & length...end//
                newApplication.Remark = remarkTextBox.Text;
                newApplication.FaciId = facilityLabel.Text;
                int test = manager.UpdateStatus(newApplication);
                if (test > 0)
                {
                    notificLabel.Text = "Application Rejected succesfully";
                }
                else
                {
                    notificLabel.Text = "Application Rejecting failed";
                }
            }
            else
            {
                notificLabel.Text = "Please select 1 item";
            }

            PopulateGridView("Choose");
        }

        protected void dateTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        public void CountApp()
        {
            headerlabel.Visible = false;
            countLabel.Text = Convert.ToString(bManager.CountNewApp());

        }

        protected void ApprButtonButton_Click(object sender, EventArgs e)
        {

            Model.Application newApplication = new Model.Application();



            countLabel.Text = Convert.ToString(bManager.CountNewApp());
            newApplication.Status = "Approved";//Application Status
            //changes happen...validation checking radio button..start//
            
            if (Session["AppId"] !=null)
            {
               
                //notificLabel.Text = "successfully done";
                newApplication.AppId = Session["AppId"].ToString();
                newApplication.BookingStatus = "Pending";//Booking Status
                newApplication.UserName = Convert.ToString(Session["UserName"]);
                newApplication.prrocessingTime = DateTime.Now;
                //changes happen here ..........empty validation & length...start//
                if (remarkTextBox.Text == "")
                {
                    nullMsgLabel.Visible = true;
                    nullMsgLabel.Text = "No Reason";
                    newApplication.Remark = nullMsgLabel.Text;
                }
                else if (remarkTextBox.Text.Length > 500)
                {
                    nullMsgLabel.Text = "Your word should be less than 500 characters";
                    newApplication.Remark = nullMsgLabel.Text;

                }
                else
                    newApplication.Remark = remarkTextBox.Text;
                //changes happen here ..........empty validation & length...end//


                newApplication.Remark = remarkTextBox.Text;
                newApplication.FaciId = facilityLabel.Text;
                int test = manager.UpdateStatus(newApplication);
                if (test > 0)
                {
                    notificLabel.Text = "Application Approved succesfully";
                }
                else
                {
                    notificLabel.Text = "Application Approving failed";
                }

            }
            else
            {

                notificLabel.Text = "Please select 1 item";
            }



        

            //changes happen...validation checking radio button..end//

            PopulateGridView("Choose");
        
            
       
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string appid = "Choose";

            if (DropDownList1.Items.Count > 0)
                appid = DropDownList1.SelectedItem.ToString();
            PopulateGridView(appid);
        }

        protected void appRadioButton_CheckedChanged1(object sender, EventArgs e)
        {
            foreach (GridViewRow oldrow in appGridView.Rows)
            {
                ((RadioButton)oldrow.FindControl("appRadioButton")).Checked = false;
            }
            RadioButton rb = (RadioButton)sender;
            GridViewRow row = (GridViewRow)rb.NamingContainer;
            ((RadioButton)row.FindControl("appRadioButton")).Checked = true;

            //changes happen ....validation checking radio button..start..//

            if (((RadioButton)row.FindControl("appRadioButton")).Checked == true)
            {
                int rowindex = row.RowIndex;
                for (int i = 0; i < appGridView.Rows.Count; i++)
                {
                    RadioButton r = (RadioButton)appGridView.Rows[i].FindControl("appRadioButton");
                    if (r.Checked == true)
                    {
                        Label l = (Label)appGridView.Rows[i].FindControl("Label3");
                        Label7.Text = l.Text;
                        Session["AppId"] = Label7.Text;


                        Label label = (Label)appGridView.Rows[i].FindControl("facIDLabel");
                        facilityLabel.Text = label.Text;

                    
                        break;
                    }


                }
            }
            else
                Session["AppId"] = "";
            //changes happen ....validation checking radio button..end..//

        }

        protected void remarkTextBox_TextChanged(object sender, EventArgs e)
        {

        }

    }

}
