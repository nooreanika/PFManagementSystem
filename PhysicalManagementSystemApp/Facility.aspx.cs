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
    public partial class Facility : System.Web.UI.Page
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
                GetData();
                BindData();

            }
        }
        protected void GetData()
        {
            da = new SqlDataAdapter("SELECT * from Facilities", con);

            ds = new DataSet();// completely empty.dataadapet data nie ashbe
            da.Fill(ds, "facility");//fill connection dey db er sthe,then selsct cmmnd chalay thn fill kore dataset ta oi adpet die

            Session["ds"] = ds;
            SqlCommandBuilder cbd = new SqlCommandBuilder(da);
            Session["da"] = da;
        }
        protected void BindData()
        {
            DataTable dt = ((DataSet)Session["ds"]).Tables[0];
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Add_facility.aspx");
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int row = e.RowIndex;
            DataTable dt = ((DataSet)Session["ds"]).Tables[0];
            SqlDataAdapter da = (SqlDataAdapter)Session["da"];

            TextBox cd = (TextBox)GridView1.Rows[row].FindControl("TextBox2");
            string catDetail = cd.Text;
            dt.Rows[row][3] = catDetail;

            TextBox ap = (TextBox)GridView1.Rows[row].FindControl("TextBox3");
            string actPrice = ap.Text;
            dt.Rows[row][4] = actPrice;

            da.Update(dt);
            GetData();
            GridView1.EditIndex = -1;
            BindData();
            
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            DataSet ds = (DataSet)Session["ds"];
            DataTable dt = ds.Tables[0];
            GridView1.DataSource = dt;
            GridView1.EditIndex = e.NewEditIndex;
            GridView1.DataBind();
            //int row = e.NewEditIndex;
            //GetData();
            //GridView1.EditIndex = row;
            //BindData();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GetData();
            GridView1.EditIndex = -1;
            BindData();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}