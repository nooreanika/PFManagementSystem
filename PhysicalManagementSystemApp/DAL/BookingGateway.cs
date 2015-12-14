using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using PhysicalManagementSystemApp.Model;

namespace PhysicalManagementSystemApp.DAL
{
    public class BookingGateway
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["PhysicalFacilityConDB"].ConnectionString;

        public List<BookingHistoryByCat> PopulateDropDownlist()
        {
            List<BookingHistoryByCat> categoryList=new List<BookingHistoryByCat>();
            SqlConnection connection =new SqlConnection(connectionString);
            string query = "Select distinct Category From Facilities";
            SqlCommand command=new SqlCommand(query,connection);
            SqlDataReader reader;
            connection.Open();
            reader = command.ExecuteReader();
            BookingHistoryByCat category = new BookingHistoryByCat();
            category.Category = "Select";
            categoryList.Add(category);
            while (reader.Read())
            {
                category=new BookingHistoryByCat();
                category.Category = reader["Category"].ToString();
                categoryList.Add(category);

            }
            connection.Close();
            return categoryList;
        }
        public List<BookingHistoryByCat> PopulateNameDropDownlist(string categ)
        {
            List<BookingHistoryByCat> categoryList = new List<BookingHistoryByCat>();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = string.Format("Select distinct CatName From Facilities where Category='{0}'",categ);
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader;
            BookingHistoryByCat category = new BookingHistoryByCat();
            category.CatName = "Select";
            categoryList.Add(category);
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                category=new BookingHistoryByCat();
                category.CatName = reader["CatName"].ToString();
                categoryList.Add(category);

            }
            connection.Close();
            return categoryList;
        }

       

        public List<BookingHistoryByCat> PopulateGridviewByAll()
        {
            List<BookingHistoryByCat> categoryList = new List<BookingHistoryByCat>();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = string.Format("select BookDate,Category,CatName,ASubject,StartDate," +
                                         "EndDate,TimeSlot  ,logistic,orgname   " +
                                         "from Booking_Det");
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader;
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                BookingHistoryByCat category = new BookingHistoryByCat();
                
                category.BookingDate = reader.GetValue(0).ToString();
                category.Category = reader.GetValue(1).ToString();
                category.CatName = reader.GetValue(2).ToString();
                category.Subject = reader.GetValue(3).ToString();
                category.StartDate = reader.GetValue(4).ToString();
                category.EndDate = reader.GetValue(5).ToString();
                category.TimeSlot = reader.GetValue(6).ToString();
                category.Logistic = reader.GetValue(7).ToString();
                category.OrgName = reader.GetValue(8).ToString();
                categoryList.Add(category);

            }
            connection.Close();
            return categoryList;
             
        

}
        public List<BookingHistoryByCat> PopulateGridview(string catg, string catName)
        {
            List<BookingHistoryByCat> categoryList = new List<BookingHistoryByCat>();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = string.Format("select BookDate,ASubject,OrgName,StartDate," +
                                         "EndDate,TimeSlot ,logistic " +
                                         "from Booking_Det where" +
                                         " Category='{0}' and CatName='{1}'",
                catg, catName);
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader;
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                BookingHistoryByCat category = new BookingHistoryByCat();
                category.BookingDate = reader.GetValue(0).ToString();
                category.Subject = reader.GetValue(1).ToString();
                category.OrgName = reader.GetValue(2).ToString();
                category.StartDate = reader.GetValue(3).ToString();
                category.EndDate = reader.GetValue(4).ToString();
                category.TimeSlot = reader.GetValue(5).ToString();
                category.Logistic = reader.GetValue(6).ToString();
            
                categoryList.Add(category);

            }
            connection.Close();
            return categoryList;



        }

        public int CountNewApp()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("select count(*) from countApp", connection);
            connection.Open();
            int count = (Int32) command.ExecuteScalar();
             connection.Close();
            return count;

        }
        public List<Application> GetAllPendingApplication()
        {

            List<Application> appList = new List<Application>();
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "Select distinct appid,ASubject,OrgName,Reason,UserName,ProcessDate From Application_Det Where BookingStatus='Pending' and Status='Approved'";
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
                app.Remark = reader.GetValue(3).ToString();
                app.UserName = reader.GetValue(4).ToString();
                app.prrocessingTime =(DateTime) reader.GetValue(5);


                appList.Add(app);

            }
            connection.Close();
            return appList;

        }
        public List<Application> GetApplicationDetails(string appId)
        {

            List<Application> appList = new List<Application>();
            SqlConnection connection = new SqlConnection(connectionString);

            string query = string.Format("Select  FaciID,Category,CatName,TimeSlot,StartDate,EndDate,UserName From Application_Det Where BookingStatus='Pending' and Status='Approved' and AppID='{0}' and BookingStatus<>'Booked'",appId);
            
            SqlCommand command = new SqlCommand(query, connection);
            

            SqlDataReader reader;
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Application app = new Application();
                app.FaciId = reader.GetValue(0).ToString();
                app.Category = reader.GetValue(1).ToString();
                app.CatName = reader.GetValue(2).ToString();
                app.TimeSlot= reader.GetValue(3).ToString();
                app.StartDate = reader.GetValue(4).ToString();
                app.EndDate = reader.GetValue(5).ToString();
                app.UserName = reader.GetValue(6).ToString();
                appList.Add(app);
            }
            connection.Close();
            return appList;

        }

        public int StoreBookingInformation(Booking booking)
        {
            SqlConnection connection=new SqlConnection(connectionString);
            string query = string.Format("insert into Booking(Bookid,appid,faciid,timeslot,bookstatus,username,bookdate) Values('{0}','{1}','{2}','{3}','{4}','{5}',@bd)",
               booking.BookID,booking.AppID,booking.FaciID,booking.TimeSlot,booking.BookDate,booking.BookStatus,booking.UserName);
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@bd", SqlDbType.Date);
            command.Parameters["@bd"].Value = booking.BookDate;
            connection.Open();
            int x = command.ExecuteNonQuery();
           
            SqlCommand cmd = new SqlCommand("Update application set BookingStatus='Booked' where appid=@ap  and faciid=@fd", connection);
            cmd.Parameters.AddWithValue("@ap", booking.AppID);
            cmd.Parameters.AddWithValue("@fd", booking.BookID);
            cmd.ExecuteNonQuery();
            connection.Close();
            if (x > 0)
            {
                return x;
            }
            else
            {
                return 0;
            }


        }

        public int UpdateBookingStatus(string bookingStatus)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = string.Format("Update Application Set BookingStatus='{0}'", bookingStatus);
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int x = command.ExecuteNonQuery();
            connection.Close();
            if (x > 0)
            {
               
                return x;
            }
            else
            {
                return 0;
            }



        }

       

    }
       
}