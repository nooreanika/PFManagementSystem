using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using PhysicalManagementSystemApp.Model;

namespace PhysicalManagementSystemApp.DAL
{
    public class RejectGateway
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["PhysicalFacilityConDB"].ConnectionString;

        public List<Application> ShowReject()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select appid,ASubject,OrgName,AppDetails,TimeSlot,StartDate,EndDate,Status,CatName From Booking_Det where status='Rejected'";
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
                app.CatName = reader.GetValue(8).ToString();
                app.Status = reader.GetValue(7).ToString();

                appList.Add(app);
            }

            reader.Close();
            connection.Close();

            return (appList);
        }
    }
}