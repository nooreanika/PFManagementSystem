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
    
    public partial class New_application : System.Web.UI.Page
    {
        SqlDataAdapter da;
        SqlDataReader dr;
        SqlCommand cmd;
        DataSet ds;
        DataTable dt;
        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=PhysicalFacilitiesDB;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
                int Max_empno = 1001;
                cmd = new SqlCommand("select max(AppID) from Application", con);
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    Max_empno = int.Parse(dr.GetValue(0).ToString());
                    Max_empno++;
                }
                dr.Close();
                con.Close();
                TextBox1.Text = Max_empno.ToString();
                if (CheckBox9.Checked == true)
                {
                    TextBox7.Visible = true;
                }

            



        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {

            TextBox2.Text = Calendar1.SelectedDate.ToShortDateString();

            Calendar1.Visible = false;
            Session["sd"] = Calendar1.SelectedDate;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Calendar1.Visible = true;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Calendar2.Visible = true;
        }

        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {

            TextBox3.Text = Calendar2.SelectedDate.ToShortDateString();
            Calendar2.Visible = false;
            Session["ed"] = Calendar2.SelectedDate;
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void Getdata()
        {
            string cat = "Lab";
            

            da = new SqlDataAdapter("SELECT FaciID from Facilities where Category='" + cat + "'", con);

            ds = new DataSet();// completely empty.dataadapet data nie ashbe
            da.Fill(ds, "Localp");//fill connection dey db er sthe,then selsct cmmnd chalay thn fill kore dataset ta oi adpet die

            Session["ds"] = ds;
            SqlCommandBuilder cbd = new SqlCommandBuilder(da);
            Session["da"] = da;
        }
        protected void GetData1()
        {

            string fac = "Auditorium";
            da = new SqlDataAdapter("SELECT FaciID from Facilities where Category='" + fac + "'", con);

            ds = new DataSet();// completely empty.dataadapet data nie ashbe
            da.Fill(ds, "aud");//fill connection dey db er sthe,then selsct cmmnd chalay thn fill kore dataset ta oi adpet die

            Session["ds"] = ds;
            SqlCommandBuilder cbd = new SqlCommandBuilder(da);
            Session["da"] = da;
        }
        protected void GetData2()
        {

            string fac = "Class";
            cmd=new SqlCommand("SELECT FaciID from Facilities where Category='" + fac + "'", con);
            con.Open();
            dr=cmd.ExecuteReader();
            
            GridView4.DataSource = dr;
            GridView4.DataBind();
            dr.Close();
            con.Close();
        }
        protected void GetData3()
        {

            string fac = "Conference Hall";
            cmd = new SqlCommand("SELECT FaciID from Facilities where Category='" + fac + "'", con);
            con.Open();
            dr = cmd.ExecuteReader();

            GridView5.DataSource = dr;
            GridView5.DataBind();
            dr.Close();
            con.Close();
        }
        protected void BindData1()
        {
            DataTable dt = ((DataSet)Session["ds"]).Tables[0];
            GridView3.DataSource = ds.Tables[0];
            GridView3.DataBind();
        }
        protected void BindData()
        {
            DataTable dt = ((DataSet)Session["ds"]).Tables[0];
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
        }
        protected void showaud(){

           string fac = "Aud";

            DateTime sd1 = (DateTime)Session["sd"];
            DateTime ed1 = (DateTime)Session["ed"];


            cmd = new SqlCommand("SELECT distinct FaciID,TimeSlot from Application where (@sd between startDate and enddate and @ed between startdate and enddate)  or (@ed>=enddate and @sd<=startdate ) and FaciID like '" + fac + "%'", con);

            // ds = new DataSet();// completely empty.dataadapet data nie ashbe
            // da.Fill(ds, "time");//fill connection dey db er sthe,then selsct cmmnd chalay thn fill kore dataset ta oi adpet die
            cmd.Parameters.Add("@sd", SqlDbType.DateTime);
            cmd.Parameters["@sd"].Value = sd1;
            cmd.Parameters.Add("@ed", SqlDbType.DateTime);
            cmd.Parameters["@ed"].Value = ed1;
            dt = new DataTable();
           // SqlDataReader dr;
            con.Open();
            dr = cmd.ExecuteReader();

            dt.Load(dr);
            con.Close();
            GridView2.DataSource = dt;
            GridView2.DataBind();

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                string fid = dt.Rows[i][0].ToString();
                string slot = dt.Rows[i][1].ToString();
                for (int j = 0; j < GridView3.Rows.Count; j++)
                {
                    CheckBox mch = (CheckBox)GridView3.Rows[j].FindControl("CheckBox12");
                    CheckBox ech = (CheckBox)GridView3.Rows[j].FindControl("CheckBox13");
                    Label l = (Label)GridView3.Rows[j].FindControl("Label15");
                    if (fid == l.Text)
                    {
                        if (slot == "Morning")
                        {
                            mch.Visible = false;

                        }
                        else if (slot == "Evening")
                        {
                            ech.Visible = false;

                        }
                        else if (slot == "Day")
                        {
                            mch.Visible = false;
                            ech.Visible = false;

                        }

                    }
                
                }
            }

        }
        protected void showclas()
        {

            string fac = "Cla";

            DateTime sd1 = (DateTime)Session["sd"];
            DateTime ed1 = (DateTime)Session["ed"];


            cmd = new SqlCommand("SELECT distinct FaciID,TimeSlot from Application where (@sd between startDate and enddate and @ed between startdate and enddate) or (@ed>=enddate and @sd<=startdate )  and FaciID like '" + fac + "%'", con);

            // ds = new DataSet();// completely empty.dataadapet data nie ashbe
            // da.Fill(ds, "time");//fill connection dey db er sthe,then selsct cmmnd chalay thn fill kore dataset ta oi adpet die
            cmd.Parameters.Add("@sd", SqlDbType.DateTime);
            cmd.Parameters["@sd"].Value = sd1;
            cmd.Parameters.Add("@ed", SqlDbType.DateTime);
            cmd.Parameters["@ed"].Value = ed1;
            dt = new DataTable();
            // SqlDataReader dr;
            con.Open();
            dr = cmd.ExecuteReader();

            dt.Load(dr);
            con.Close();
            GridView2.DataSource = dt;
            GridView2.DataBind();

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                string fid = dt.Rows[i][0].ToString();
                string slot = dt.Rows[i][1].ToString();
                for (int j = 0; j < GridView4.Rows.Count; j++)
                {
                    CheckBox mch = (CheckBox)GridView4.Rows[j].FindControl("CheckBox15");
                    CheckBox ech = (CheckBox)GridView4.Rows[j].FindControl("CheckBox17");
                    Label l = (Label)GridView4.Rows[j].FindControl("Label16");
                    if (fid == l.Text)
                    {
                        if (slot == "Morning")
                        {
                            mch.Visible = false;

                        }
                        else if (slot == "Evening")
                        {
                            ech.Visible = false;

                        }
                        else if (slot == "Day")
                        {
                            mch.Visible = false;
                            ech.Visible = false;

                        }

                    }

                }
            }

        }

        protected void showcon()
        {

            string fac = "Con";

            DateTime sd1 = (DateTime)Session["sd"];
            DateTime ed1 = (DateTime)Session["ed"];


            cmd = new SqlCommand("SELECT distinct FaciID,TimeSlot from Application where (@sd between startDate and enddate and @ed between startdate and enddate)  or (@ed>=enddate and @sd<=startdate ) and FaciID like '" + fac + "%'", con);

            // ds = new DataSet();// completely empty.dataadapet data nie ashbe
            // da.Fill(ds, "time");//fill connection dey db er sthe,then selsct cmmnd chalay thn fill kore dataset ta oi adpet die
            cmd.Parameters.Add("@sd", SqlDbType.DateTime);
            cmd.Parameters["@sd"].Value = sd1;
            cmd.Parameters.Add("@ed", SqlDbType.DateTime);
            cmd.Parameters["@ed"].Value = ed1;
            dt = new DataTable();
            // SqlDataReader dr;
            con.Open();
            dr = cmd.ExecuteReader();

            dt.Load(dr);
            con.Close();
            GridView2.DataSource = dt;
            GridView2.DataBind();

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                string fid = dt.Rows[i][0].ToString();
                string slot = dt.Rows[i][1].ToString();
                for (int j = 0; j < GridView5.Rows.Count; j++)
                {
                    CheckBox mch = (CheckBox)GridView5.Rows[j].FindControl("CheckBox18");
                    CheckBox ech = (CheckBox)GridView5.Rows[j].FindControl("CheckBox19");
                    Label l = (Label)GridView5.Rows[j].FindControl("Label17");
                    if (fid == l.Text)
                    {
                        if (slot == "Morning")
                        {
                            mch.Visible = false;

                        }
                        else if (slot == "Evening")
                        {
                            ech.Visible = false;

                        }
                        else if (slot == "Day")
                        {
                            mch.Visible = false;
                            ech.Visible = false;

                        }

                    }

                }
            }

        }

        protected void Show()
        {
            DateTime sd1 = (DateTime)Session["sd"];
            DateTime ed1 = (DateTime)Session["ed"];
            string fcat = "La";
            
            cmd = new SqlCommand("SELECT distinct FaciID,TimeSlot from Application where ((@sd between startDate and enddate) or (@ed between startdate and enddate) or (@ed>=enddate and @sd<=startdate ))  and FaciID like '" + fcat + "%'", con);

            // ds = new DataSet();// completely empty.dataadapet data nie ashbe
            // da.Fill(ds, "time");//fill connection dey db er sthe,then selsct cmmnd chalay thn fill kore dataset ta oi adpet die
            cmd.Parameters.Add("@sd", SqlDbType.DateTime);
            cmd.Parameters["@sd"].Value = sd1;
            cmd.Parameters.Add("@ed", SqlDbType.DateTime);
            cmd.Parameters["@ed"].Value = ed1;
            dt = new DataTable();
            SqlDataReader dr;
            con.Open();
            dr = cmd.ExecuteReader();

            dt.Load(dr);
            con.Close();
            GridView2.DataSource = dt;
            GridView2.DataBind();

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                string fid = dt.Rows[i][0].ToString();
                string slot = dt.Rows[i][1].ToString();
                for (int j = 0; j < GridView1.Rows.Count; j++)
                {
                    CheckBox mch = (CheckBox)GridView1.Rows[j].FindControl("CheckBox10");
                    CheckBox ech = (CheckBox)GridView1.Rows[j].FindControl("CheckBox11");
                    Label l = (Label)GridView1.Rows[j].FindControl("Label18");
                    if (fid == l.Text)
                    {
                        if (slot == "Morning")
                        {
                            mch.Visible = false;

                        }
                        else if (slot == "Evening")
                        {
                            ech.Visible = false;

                        }
                        else if (slot == "Day")
                        {
                            mch.Visible = false;
                            ech.Visible = false;

                        }

                    }
                }
            }

        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            GridView1.Visible = true;
            Getdata();
            BindData();
            Show();

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void CheckBox5_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string ID = TextBox1.Text;
            DateTime sd1 = (DateTime)Session["sd"];
            DateTime ed1 = (DateTime)Session["ed"];
           // string cat = DropDownList1.SelectedItem.ToString();
            string sub = TextBox4.Text;
            string org = TextBox5.Text;
            string detail = TextBox6.Text;
            string logi = "";
            if (CheckBox4.Checked == true)
                logi = logi + "Mike";
            if (CheckBox5.Checked == true)
                logi = logi + " Projector";
            if (CheckBox6.Checked == true)
                logi = logi + " Speaker,";
            if (CheckBox7.Checked == true)
                logi = logi + " Multiplug,";
            if (CheckBox9.Checked == true)
            {
                string r = TextBox7.Text;
                logi = logi + r;
            }



            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                string app = "New";
                CheckBox mch = (CheckBox)GridView1.Rows[i].FindControl("CheckBox10");
                CheckBox ech = (CheckBox)GridView1.Rows[i].FindControl("CheckBox11");
                //CheckBox ch1 = (CheckBox)GridView1.Rows[i].FindControl("CheckBox3");

                Label f = (Label)GridView1.Rows[i].FindControl("Label18");
                
                string fid = f.Text;
                string slot = "";

                if (mch.Checked && ech.Checked)
                {
                    slot = "Day";
                }
                else if (mch.Checked)
                {

                    slot = "Morning";

                }
                else if (ech.Checked)
                {

                    slot = "Evening";

                }

                if (slot != "")
                {
                    cmd = new SqlCommand("insert into Application (AppID,FaciID,ASubject,OrgName,AppDetails,Logistic,TimeSlot,StartDate,EndDate,Status) values(@id,@fid,@sub,@org,@details,@logi,@slot,@sd,@ed,'" + app + "')", con);
                    //cmd = new SqlCommand("select distinct PType from Productss", con);
                    cmd.Parameters.AddWithValue("@id", ID);
                    cmd.Parameters.AddWithValue("@fid", fid);
                    cmd.Parameters.AddWithValue("@sub", sub);
                    cmd.Parameters.AddWithValue("@org", org);
                    cmd.Parameters.AddWithValue("@details", detail);
                    cmd.Parameters.AddWithValue("@logi", logi);
                    cmd.Parameters.AddWithValue("@slot", slot);
                    cmd.Parameters.Add("@sd", SqlDbType.DateTime);
                    cmd.Parameters["@sd"].Value = sd1;
                    cmd.Parameters.Add("@ed", SqlDbType.DateTime);
                    cmd.Parameters["@ed"].Value = ed1;


                    con.Open();
                    cmd.ExecuteNonQuery();



                    con.Close();
                    Label8.Text = "added";
                }
            }
            for (int i = 0; i < GridView3.Rows.Count; i++)
            {
                string app = "New";
                CheckBox mch = (CheckBox)GridView3.Rows[i].FindControl("CheckBox12");
                CheckBox ech = (CheckBox)GridView3.Rows[i].FindControl("CheckBox13");
                //CheckBox ch1 = (CheckBox)GridView1.Rows[i].FindControl("CheckBox3");

                Label f = (Label)GridView3.Rows[i].FindControl("Label15");

                string fid = f.Text;
                string slot = "";

                if (mch.Checked && ech.Checked)
                {
                    slot = "Day";
                }
                else if (mch.Checked)
                {

                    slot = "Morning";

                }
                else if (ech.Checked)
                {

                    slot = "Evening";

                }

                if (slot != "")
                {
                    cmd = new SqlCommand("insert into Application (AppID,FaciID,ASubject,OrgName,AppDetails,Logistic,TimeSlot,StartDate,EndDate,Status) values(@id,@fid,@sub,@org,@details,@logi,@slot,@sd,@ed,'" + app + "')", con);
                    //cmd = new SqlCommand("select distinct PType from Productss", con);
                    cmd.Parameters.AddWithValue("@id", ID);
                    cmd.Parameters.AddWithValue("@fid", fid);
                    cmd.Parameters.AddWithValue("@sub", sub);
                    cmd.Parameters.AddWithValue("@org", org);
                    cmd.Parameters.AddWithValue("@details", detail);
                    cmd.Parameters.AddWithValue("@logi", logi);
                    cmd.Parameters.AddWithValue("@slot", slot);
                    cmd.Parameters.Add("@sd", SqlDbType.DateTime);
                    cmd.Parameters["@sd"].Value = sd1;
                    cmd.Parameters.Add("@ed", SqlDbType.DateTime);
                    cmd.Parameters["@ed"].Value = ed1;


                    con.Open();
                    cmd.ExecuteNonQuery();



                    con.Close();
                    Label8.Text = "added";
                }
            }
            for (int i = 0; i < GridView4.Rows.Count; i++)
            {
                string app = "New";
                CheckBox mch = (CheckBox)GridView4.Rows[i].FindControl("CheckBox15");
                CheckBox ech = (CheckBox)GridView4.Rows[i].FindControl("CheckBox17");
                //CheckBox ch1 = (CheckBox)GridView1.Rows[i].FindControl("CheckBox3");

                Label f = (Label)GridView4.Rows[i].FindControl("Label16");

                string fid = f.Text;
                string slot = "";

                if (mch.Checked && ech.Checked)
                {
                    slot = "Day";
                }
                else if (mch.Checked)
                {

                    slot = "Morning";

                }
                else if (ech.Checked)
                {

                    slot = "Evening";

                }

                if (slot != "")
                {
                    cmd = new SqlCommand("insert into Application (AppID,FaciID,ASubject,OrgName,AppDetails,Logistic,TimeSlot,StartDate,EndDate,Status) values(@id,@fid,@sub,@org,@details,@logi,@slot,@sd,@ed,'" + app +"')", con);
                    //cmd = new SqlCommand("select distinct PType from Productss", con);
                    cmd.Parameters.AddWithValue("@id", ID);
                    cmd.Parameters.AddWithValue("@fid", fid);
                    cmd.Parameters.AddWithValue("@sub", sub);
                    cmd.Parameters.AddWithValue("@org", org);
                    cmd.Parameters.AddWithValue("@details", detail);
                    cmd.Parameters.AddWithValue("@logi", logi);
                    cmd.Parameters.AddWithValue("@slot", slot);
                    cmd.Parameters.Add("@sd", SqlDbType.DateTime);
                    cmd.Parameters["@sd"].Value = sd1;
                    cmd.Parameters.Add("@ed", SqlDbType.DateTime);
                    cmd.Parameters["@ed"].Value = ed1;


                    con.Open();
                    cmd.ExecuteNonQuery();



                    con.Close();
                    Label8.Text = "added";
                }
            }
            for (int i = 0; i < GridView5.Rows.Count; i++)
            {
                string app = "New";
                CheckBox mch = (CheckBox)GridView5.Rows[i].FindControl("CheckBox18");
                CheckBox ech = (CheckBox)GridView5.Rows[i].FindControl("CheckBox19");
                //CheckBox ch1 = (CheckBox)GridView1.Rows[i].FindControl("CheckBox3");

                Label f = (Label)GridView5.Rows[i].FindControl("Label17");

                string fid = f.Text;
                string slot = "";

                if (mch.Checked && ech.Checked)
                {
                    slot = "Day";
                }
                else if (mch.Checked)
                {

                    slot = "Morning";

                }
                else if (ech.Checked)
                {

                    slot = "Evening";

                }

                if (slot != "")
                {
                    cmd = new SqlCommand("insert into Application (AppID,FaciID,ASubject,OrgName,AppDetails,Logistic,TimeSlot,StartDate,EndDate,Status) values(@id,@fid,@sub,@org,@details,@logi,@slot,@sd,@ed,'" + app + "')", con);
                    //cmd = new SqlCommand("select distinct PType from Productss", con);
                    cmd.Parameters.AddWithValue("@id", ID);
                    cmd.Parameters.AddWithValue("@fid", fid);
                    cmd.Parameters.AddWithValue("@sub", sub);
                    cmd.Parameters.AddWithValue("@org", org);
                    cmd.Parameters.AddWithValue("@details", detail);
                    cmd.Parameters.AddWithValue("@logi", logi);
                    cmd.Parameters.AddWithValue("@slot", slot);
                    cmd.Parameters.Add("@sd", SqlDbType.DateTime);
                    cmd.Parameters["@sd"].Value = sd1;
                    cmd.Parameters.Add("@ed", SqlDbType.DateTime);
                    cmd.Parameters["@ed"].Value = ed1;


                    con.Open();
                    cmd.ExecuteNonQuery();



                    con.Close();
                    Label8.Text = "added";
                }
            }

        }



        protected void DropDownList1_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Panel3.Visible = true;
            Label12.Text = TextBox4.Text;
           // Label9.Text = DropDownList1.SelectedItem.ToString();
            Label10.Text = TextBox2.Text;
            Label11.Text = TextBox3.Text;
            Label13.Text = Label9.Text;
            //string no = "";

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                //CheckBox mch = (CheckBox)GridView1.Rows[i].FindControl("CheckBox10");
                //CheckBox ech = (CheckBox)GridView1.Rows[i].FindControl("CheckBox11");

                //if (mch.Checked && ech.Checked)
                //{
                //    Label fid = (Label)GridView1.Rows[i].FindControl("Label1");
                //    no = no + fid.Text;
                //    Label14.Text = no;

                //}
                //else if (mch.Checked)
                //{

                //    Label fid = (Label)GridView1.Rows[i].FindControl("Label1");
                //   // no = no + fid.Text;
                //    Label14.Text = no;

                //}
                //else if (ech.Checked)
                //{
                //    Label fid = (Label)GridView1.Rows[i].FindControl("Label1");
                //    no = no + fid.Text;
                //    Label14.Text = no;

                //}


            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            GetData1();
            BindData1();
            showaud();
        }
        protected void Button7_Click(object sender, EventArgs e)
        {
            GetData2();
            showclas();
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
           
        }

        protected void Button9_Click1(object sender, EventArgs e)
        {
            Getdata();
            BindData();
            Show();
        }

        protected void Button8_Click1(object sender, EventArgs e)
        {
            
        }

        protected void Button10_Click(object sender, EventArgs e)
        {
            GetData3();
            showcon();
        }
    }
}
