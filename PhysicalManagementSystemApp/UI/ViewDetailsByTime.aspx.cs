using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PhysicalManagementSystemApp.BLL;

namespace PhysicalManagementSystemApp.UI
{
    public partial class ViewDetailsByTime : System.Web.UI.Page
    {
        BookingManager manager=new BookingManager();
        private string connectionString = ConfigurationManager.ConnectionStrings["PhysicalFacilityConDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateTypeDropDownList();
            }
           

        }

        public void PopulateTypeDropDownList()
        {
            typeDropDownList.DataSource = manager.PopulateDropDownlist();
            typeDropDownList.DataTextField = "Category";
            typeDropDownList.DataValueField = "Category";
            typeDropDownList.DataBind();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string frmdt = fromTextBox.Text;
            string todt = toTextBox.Text;
            DateTime dt1=new DateTime();
            dt1 = DateTime.ParseExact(frmdt, "yyyy/MM/dd",null);
            DateTime dt2=new DateTime();
            dt2 = DateTime.ParseExact(todt, "yyyy/MM/dd", null);


            
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("select faciid, startdate,enddate from booking_det where ( @sd between startdate and enddate and @ed between startdate and enddate) or (@sd < startdate and @ed between startdate and enddate) or (@sd between startdate and enddate and @ed> enddate)  ",connection);
            cmd.Parameters.AddWithValue("@sd",dt1);
            cmd.Parameters.AddWithValue("@ed", dt2);
           
            SqlDataReader dr;
             connection .Open();
            dr = cmd.ExecuteReader();
            DataTable dt=new DataTable();
            dt.Load(dr);
            connection.Close();
            detailsGridView.DataSource = dt;
            detailsGridView.DataBind();

        }

    }
}