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
    public partial class Booking : System.Web.UI.Page
    {
        BookingManager manager=new BookingManager();
        Model.Application newApplication=new Model.Application();
        Model.Booking newBooking=new Model.Booking();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulatePreBookingGridview();
            }
        }
    

        protected void showButton_Click(object sender, EventArgs e)
        {
            newApplication.AppId = IdLabel.Text;
            if (Session["AppId"] != null)

                PopulateApplicationGridView();

            else
                IdLabel.Text = "Please select Application ID";




        }

        protected void preBookingGridView_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
           // int r = e.NewSelectedIndex;
           // Label l = (Label)preBookingGridView.Rows[r].FindControl("idLabel");
           
            
           //IdLabel.Text = l.Text;
        }

        protected void preBookingGridView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void selectRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow oldrow in preBookingGridView.Rows)
            {
                ((RadioButton)oldrow.FindControl("selectRadioButton")).Checked = false;
            }
            RadioButton rb = (RadioButton)sender;
            GridViewRow row = (GridViewRow)rb.NamingContainer;
            ((RadioButton)row.FindControl("selectRadioButton")).Checked = true;
            int rowindex = row.RowIndex;
            for (int i = 0; i < preBookingGridView.Rows.Count; i++)
            {
                RadioButton r = (RadioButton)preBookingGridView.Rows[i].FindControl("selectRadioButton");
                if (r.Checked == true)
                {
                    Label l = (Label)preBookingGridView.Rows[i].FindControl("idLabel");
                    newApplication.AppId= l.Text;
                    Session["AppId"] = l.Text;
                    break;
                }
            }
        }

        protected void displayButton_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow oldrow in appDetailsGridView.Rows)
            {
                CheckBox check = (CheckBox) oldrow.FindControl("addCheckBox");
                if (check != null && check.Checked)
                {
                      
                      newBooking.FaciID= oldrow.Cells[0].Text;
                      newBooking.TimeSlot = oldrow.Cells[3].Text;
                      newBooking.AppID = Session["AppId"].ToString();
                      string key = "B";

                      newBooking.BookID = key + GenerateBookingId(0, 999999);
                      newBooking.UserName = Session["UserName"].ToString();
                      newBooking.BookDate = DateTime.Now;
                      newBooking.BookStatus = "Booked";
                      int insert= manager.StoreBookingInformation(newBooking);              
                        

                     
                    
                }
            }
            PopulateApplicationGridView();
            PopulatePreBookingGridview();



        }
        public int GenerateBookingId(int min, int max)
        {
      
            Random randoms = new Random();
            return randoms.Next(min, max);

        }

        public void PopulateApplicationGridView()
        {
            string appid1 = Session["AppID"].ToString();
            appDetailsGridView.DataSource = manager.GetApplicationDetails(appid1);
            appDetailsGridView.DataBind();
            
        }

        public void PopulatePreBookingGridview()
        {
            if (manager.GetAllPendingApplication() != null)
            {
                preBookingGridView.DataSource = manager.GetAllPendingApplication();
                preBookingGridView.DataBind();
            }
            else
            {
                nullMsgLabel.Text = "There is no pending application";
            }
        }
    }
}