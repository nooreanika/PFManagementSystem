using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using PhysicalManagementSystemApp.Model;

namespace PhysicalManagementSystemApp.DAL
{
    public class ApplicationGateway
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["PhysicalFacilityConDB"].ConnectionString;


        public List<Application> GetAllApplication(string appid)
        {

            List<Application> appList = new List<Application>();
            SqlConnection connection = new SqlConnection(connectionString);
             string query="";
             if (appid.Trim() == "Choose")
                 query = "Select appid,ASubject,OrgName,AppDetails,TimeSlot,StartDate,EndDate,CatName,Status,FaciId From Application_Det Where Status='New'";
             else
                 query = "Select appid,ASubject,OrgName,AppDetails,TimeSlot,StartDate,EndDate,CatName,Status,FaciId From Application_Det Where Status='New' and appid='" + appid + "'";
            SqlCommand command = new SqlCommand(query, connection);

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
                app.CatName = reader.GetValue(7).ToString();
                app.Status = reader.GetValue(8).ToString();
                app.FaciId = reader.GetValue(9).ToString();

                appList.Add(app);

            }
            connection.Close();
            return appList;

        }
        public string ShowDetails(string appID)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "select AppDetails from Application where AppID=@id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", appID);

            SqlDataReader reader;
            connection.Open();
            reader = command.ExecuteReader();
            string details = String.Empty;
            while (reader.Read())
            {

                details = reader.GetValue(0).ToString();


            }
            connection.Close();
            return details;




        }
        public List<Application> ViewAllApplication()
        {

            List<Application> appList = new List<Application>();
            SqlConnection connection = new SqlConnection(connectionString);

            string query =
                "Select appid,ASubject,OrgName,AppDetails,TimeSlot,StartDate,EndDate,CatName,Status From Application_Det ";
            SqlCommand command = new SqlCommand(query, connection);

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
                app.CatName = reader.GetValue(7).ToString();
                app.Status = reader.GetValue(8).ToString();

                appList.Add(app);

            }
            connection.Close();
            return appList;

        }
       
        public int UpdateStatus(Model.Application newApplication)
        {

            SqlConnection connection = new SqlConnection(connectionString);
            string query = string.Format("update Application set Status=@st,UserName=@usn,BookingStatus=@bss,ProcessDate=@pd," +
                                         "Reason=@rsn" +
                                         " where appId=@apid and FaciID=@fid");
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@st", newApplication.Status);
            command.Parameters.AddWithValue("@apid", newApplication.AppId);
            command.Parameters.AddWithValue("@usn", newApplication.UserName);
            command.Parameters.AddWithValue("@bss",newApplication.BookingStatus );
            command.Parameters.AddWithValue("@pd", newApplication.prrocessingTime);
            command.Parameters.AddWithValue("@rsn",newApplication.Remark);
            command.Parameters.AddWithValue("@fid",newApplication.FaciId);





            //SqlDataReader reader;
            connection.Open();
            int test = command.ExecuteNonQuery();
            connection.Close();

            //int check = UpdateBookStatus(appid, bst);

            if (test > 0)
            {
                return test;
            }
            else
            {
                return 0;
            }


        }

        public int UpdateRejectStatus(Model.Application newApplication)
        {

            SqlConnection connection = new SqlConnection(connectionString);
            string query = string.Format("update Application set Status=@st,UserName=@usn,BookingStatus=@bss,ProcessDate=@pd," +
                                         "Reason=@rsn" +
                                         " where appId=@apid and FaciID=@fid");
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@st", newApplication.Status);
            command.Parameters.AddWithValue("@apid", newApplication.AppId);
            command.Parameters.AddWithValue("@usn", newApplication.UserName);
            command.Parameters.AddWithValue("@bss", newApplication.BookingStatus);
            command.Parameters.AddWithValue("@pd", newApplication.prrocessingTime);
            command.Parameters.AddWithValue("@rsn", newApplication.Remark);
            command.Parameters.AddWithValue("@fid", newApplication.FaciId);





            //SqlDataReader reader;
            connection.Open();
            int test = command.ExecuteNonQuery();
            connection.Close();

            //int check = UpdateBookStatus(appid, bst);

            if (test > 0)
            {
                return test;
            }
            else
            {
                return 0;
            }


        }

        //}
        //public int UpdateRejectStatus(string sta, string aid, string bookst)
        //{
        //    SqlConnection connection = new SqlConnection(connectionString);
        //    string query = string.Format("update Application set Status=@st where appId=@apid ");
        //    SqlCommand command = new SqlCommand(query, connection);
        //    command.Parameters.AddWithValue("@st", sta);
        //    command.Parameters.AddWithValue("@apid", aid);

        //    //SqlDataReader reader;
        //    connection.Open();
        //    int test = command.ExecuteNonQuery();

        //    connection.Close();
        //    int ch = UpdateRejectBookStatus(aid, bookst);

        //    if (test > 0 && ch > 0)
        //    {
        //        return ch;
        //    }
        //    else
        //    {
        //        return 0;
        //    }



        //}
        //public int UpdateRejectBookStatus(string aid, string bookst)
        //{
        //    SqlConnection connection = new SqlConnection(connectionString);
        //    string query = string.Format("update Booking set BookStatus=@bookst  where appId=@apid");
        //    SqlCommand command = new SqlCommand(query, connection);

        //    command.Parameters.AddWithValue("@bookst", bookst);
        //    command.Parameters.AddWithValue("@apid", aid);

        //    connection.Open();
        //    int ch = command.ExecuteNonQuery();
        //    connection.Close();
        //    if (ch > 0)
        //    {
        //        return ch;
        //    }
        //    else
        //    {
        //        return 0;
        //    }

        //}
    }
}