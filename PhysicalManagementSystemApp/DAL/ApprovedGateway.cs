using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using PhysicalManagementSystemApp.Model;

namespace PhysicalManagementSystemApp.DAL
{
    public class ApprovedGateway
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["PhysicalFacilityConDB"].ConnectionString;

        public List<Application> ApproveDetail()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select appid,ASubject,OrgName,AppDetails,TimeSlot,StartDate,EndDate,Status,CatName From Application_Det where status='Approved'";
            SqlCommand command = new SqlCommand(query, connection);
            List<Application> appList = new List<Application>();
            SqlDataReader reader;
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Application app = new Application();
                app.AppId = reader.GetValue(0).ToString();
                app.Asubject = reader.GetValue(1).ToString();
                app.OrgName = reader.GetValue(2).ToString();
                app.Appdetails = reader.GetValue(3).ToString();
                app.TimeSlot = reader.GetValue(4).ToString();
                app.StartDate = reader.GetValue(5).ToString();
                app.EndDate = reader.GetValue(6).ToString();
                app.Status = reader.GetValue(7).ToString();
                app.CatName = reader.GetValue(8).ToString();

                appList.Add(app);
            }


            return appList;


        }
    }
}