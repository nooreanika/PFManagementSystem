using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace phy_fac_bard
{
    public partial class Booking_Update : System.Web.UI.Page
    {
        SqlDataAdapter da;
        SqlDataReader dr;
        SqlCommand cmd;
        DataSet ds;
        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=PhysicalFacilitiesDB;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string book = "Booked";
                cmd = new SqlCommand("select distinct AppID from Booking Where BookStatus='"+book+"'", con);
                //cmd = new SqlCommand("select distinct PType from Productss", con);
                con.Open();
                dr = cmd.ExecuteReader();
                DropDownList1.Items.Add("Select");
                // DropDownList3.Items.Add("Select");
                while (dr.Read())
                {
                    DropDownList1.Items.Add(dr.GetValue(0).ToString());
                }
                dr.Close();
                con.Close();
            }
           // Label3.Text=Session["UN"].ToString();
        }
        protected void GetData()
        {
            string book = "Booked";
            string app = DropDownList1.SelectedItem.ToString();
            da = new SqlDataAdapter("SELECT * from Booking where AppID='"+app+"'and BookStatus='"+book+"'", con);

            ds = new DataSet();// completely empty.dataadapet data nie ashbe
            da.Fill(ds, "canbook");//fill connection dey db er sthe,then selsct cmmnd chalay thn fill kore dataset ta oi adpet die

            Session["BookingCan"] = ds;
            SqlCommandBuilder cbd = new SqlCommandBuilder(da);
            Session["da"] = da;
        }
        protected void BindData()
        {
            DataTable dt = ((DataSet)Session["BookingCan"]).Tables[0];
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetData();
            BindData();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           // DataTable dt = ((DataTable)Session["BookingCan"]);
            
            
             
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                CheckBox ch = (CheckBox)GridView1.Rows[i].FindControl("CheckBox1");
                Label f = (Label)GridView1.Rows[i].FindControl("Label1");
                if (ch.Checked == true)
                {
                    string p = f.Text;
                    string bn=Session["UN"].ToString();
                    string check = "Cancel";
                    DateTime cd=DateTime.Now;
                    string app = DropDownList1.SelectedItem.ToString();
                    
                   // GridView1.Rows[][] 
                    string reason = TextBox1.Text;
                   
                    cmd = new SqlCommand("Update Booking Set CDate=@cd,username=@bu,Cusername=@cu,CReason=@reason,BookStatus=@check where AppID='"+app+"' and FaciID='"+p+"'",con);
                    cmd.Parameters.AddWithValue("@cd",cd);
                    cmd.Parameters.AddWithValue("@bu",bn);
                    cmd.Parameters.AddWithValue("@cu",bn);
                    cmd.Parameters.AddWithValue("@reason",reason);
                    cmd.Parameters.AddWithValue("@check",check);
                    //cmd.Parameters.AddWithValue("",);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Redirect("Booking.aspx");
                    
                }
                
            } 
        }
    }
}