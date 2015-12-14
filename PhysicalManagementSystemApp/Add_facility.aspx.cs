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
    public partial class Add_facility : System.Web.UI.Page
    {
        SqlDataAdapter da;
        SqlDataReader dr;
        SqlCommand cmd;
        DataSet ds;
        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=PhysicalFacilitiesDB;Integrated Security=True");
       
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox7_TextChanged(object sender, EventArgs e)
        {
                    }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string facid=TextBox1.Text;
            string cat = DropDownList1.SelectedItem.ToString();
            string cn=TextBox3.Text;
            string detail=TextBox4.Text;
            float ap=float.Parse(TextBox5.Text);
            float dp=float.Parse(TextBox6.Text);


            SqlCommand cmd = new SqlCommand("insert into Facilities (FaciID,Category,CatName,CatDetails,Act_Price,Disc_Price) values(@facid,@cat,@cn,@detail,@ap,@dp)",con);
            cmd.Parameters.AddWithValue("@facid",facid);
            cmd.Parameters.AddWithValue("@cat",cat);
            cmd.Parameters.AddWithValue("@cn",cn);
            cmd.Parameters.AddWithValue("@detail",detail);
            cmd.Parameters.AddWithValue("@ap",ap);
            cmd.Parameters.AddWithValue("@dp",dp);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Label1.Text = "Added Successfully";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Facility.aspx");
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
       

       
        protected void GetData1()
        {


            da = new SqlDataAdapter("Select distinct CatDetails from Facilities", con);
            ds = new DataSet();// completely empty.dataadapet data nie ashbe
            da.Fill(ds, "facility");//fill connection dey db er sthe,then selsct cmmnd chalay thn fill kore dataset ta oi adpet die

            Session["ds"] = ds;
            SqlCommandBuilder scb = new SqlCommandBuilder(da);
            Session["da"] = da;


        }

        protected void BindData1()
        {
            // DataTable dt=((DataSet)Session["ds"]).Tables[0];
            DataSet ds = (DataSet)Session["ds"];
            DataTable dt = ds.Tables[0];
            GridView2.DataSource = ds.Tables[0];
            GridView2.DataBind();
        }


        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
             if (DropDownList1.SelectedIndex > 0)
        {

            string fac = DropDownList1.SelectedItem.ToString();
            con.Open();
            cmd = new SqlCommand("Select count(FaciID) from Facilities where Category='" + fac + "'", con);
           
            dr=cmd.ExecuteReader();
           while (dr.Read())
            {
                int x = int.Parse(dr.GetValue(0).ToString());
                x++;

                if (fac == "Auditorium")
                {
                    TextBox1.Text = "Audi" + x.ToString();
                    TextBox3.Text = "Auditorium" + x.ToString();
                }
                else if (fac == "Class")
                {
                    TextBox1.Text = "Clas" + x.ToString();
                    TextBox3.Text = "Class" + x.ToString();
                }
                else if (fac == "Lab")
                {
                    TextBox1.Text = "Lab" + x.ToString();
                    TextBox3.Text = "Lab" + x.ToString();
                }
                else if (fac == "Conference Hall")
                {
                    TextBox1.Text = "Con" + x.ToString();
                    TextBox3.Text = "Conference" + x.ToString();
                }

                //TextBox1.Text = dr.GetValue(0).ToString();
            }  
    }
        else
        {
            TextBox1.Text = null;
        }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            GetData1();
            BindData1();
        }

        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < GridView2.Rows.Count; i++)
            {
                //TextBox4.Text = "abv";
                RadioButton ch = (RadioButton)GridView2.Rows[i].FindControl("RadioButton1");
                if (ch.Checked == true)
                {
                    Label l = (Label)GridView2.Rows[i].FindControl("Label1");
                    TextBox4.Text = l.Text;
                    break;
                    
                }
            }
            
        }

        protected void RadioButton1_CheckedChanged1(object sender, EventArgs e)
        {
            foreach (GridViewRow oldrow in GridView2.Rows)
            {
                ((RadioButton)oldrow.FindControl("RadioButton1")).Checked = false;
            }
            RadioButton rb = (RadioButton)sender;
            GridViewRow row = (GridViewRow)rb.NamingContainer;
            ((RadioButton)row.FindControl("RadioButton1")).Checked = true;

            for (int i = 0; i < GridView2.Rows.Count; i++)
            {
                TextBox4.Text = "abv";
                RadioButton ch = (RadioButton)GridView2.Rows[i].FindControl("RadioButton1");
                if (ch.Checked == true)
                {

                    Label l = (Label)GridView2.Rows[i].FindControl("Label1");
                    
                    TextBox4.Text = l.Text;
                    break;
                    // flag = true;
                    // GridView2.DataSource;
                    // GridView2.DataBind();
                }
            }
            GridView2.Visible = false;
        }

        protected void TextBox5_TextChanged(object sender, EventArgs e)
        {
            float ac = float.Parse(TextBox5.Text);
            float dc = (ac / 2);
            TextBox6.Text = dc.ToString();
        }

    }
}