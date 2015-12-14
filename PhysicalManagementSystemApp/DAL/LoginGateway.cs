using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PhysicalManagementSystemApp.DAL
{
    public class LoginGateway
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["PhysicalFacilityConDB"].ConnectionString;

        public bool Login(string userName, string password)
        {
            bool isUserExists = false;

            SqlConnection connection = new SqlConnection(connectionString);
            string query = string.Format("SELECT * FROM Login Where Name='{0}' AND Password='{1}'", userName, password);

            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                isUserExists = true;



            }
            reader.Close();
            connection.Close();
            return isUserExists;

        }
    }
}