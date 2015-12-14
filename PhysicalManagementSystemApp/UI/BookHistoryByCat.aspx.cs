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
    public partial class BookHistoryByCat : System.Web.UI.Page
    {
        BookingManager manager=new BookingManager();
        BookingHistoryByCat category=new BookingHistoryByCat();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                categoryDropDownList.Items.Add("Select");
                PopulateDropdownList();
            }

        }

        public void PopulateDropdownList()
        {
         
            categoryDropDownList.DataSource = manager.PopulateDropDownlist();
            categoryDropDownList.DataTextField = "Category";
            categoryDropDownList.DataValueField = "Category";
            categoryDropDownList.DataBind();
        }

        protected void categoryDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            PopulateNameDropDownList();
           
        }

        public void PopulateNameDropDownList()
        {
        
             category.Category = categoryDropDownList.SelectedItem.ToString();

            nameDropDownList.DataSource = manager.PopulateNameDropDownlist(category.Category);
            nameDropDownList.DataTextField = "CatName";
            nameDropDownList.DataValueField = "CatName";
            nameDropDownList.DataBind();
        }

        protected void nameDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            detailsGridView.Visible = true;
           
            detailsGridView.Columns[2].Visible = false;
            detailsGridView.Columns[3].Visible = false;
            PopulateGridView();

        }

        public void PopulateGridView()
        {
            category.CatName = nameDropDownList.SelectedItem.ToString();
            category.Category = categoryDropDownList.SelectedItem.ToString();

            detailsGridView.DataSource = manager.PopulateGridview(category.Category, category.CatName);
            detailsGridView.DataBind();


        }

        protected void allLinkButton_Click(object sender, EventArgs e)
        {
            categoryDropDownList.SelectedIndex = 0;
            nameDropDownList.SelectedIndex = -1;
           // CategoryLabel.Visible = true;
            detailsGridView.Columns[2].Visible = true;
            detailsGridView.Columns[3].Visible = true;
            detailsGridView.DataSource = manager.PopulateGridviewByAll();
            detailsGridView.DataBind();
        }

    }
}