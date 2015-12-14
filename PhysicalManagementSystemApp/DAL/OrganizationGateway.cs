using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using PhysicalManagementSystemApp.Model;
using System.Configuration;
namespace PhysicalManagementSystemApp.DAL
{
    public class OrganizationGateway
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["PhysicalFacilityConDB"].ConnectionString;
        public List<Organization> GetData()
        
        {
            List<Organization> orgList = new List<Organization>();

            SqlConnection connection = new SqlConnection(connectionString);
            string query = "select * from Organization ";
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Organization org = new Organization();
                org.Name = dr.GetValue(0).ToString();
                org.Email = dr.GetValue(1).ToString();
                orgList.Add(org);
            }
            connection.Close();
            return orgList;
        }
        public bool SaveOrganization(string nam,string email)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "insert into Organization ( Name,Email)values (@name,@email) ";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@name", nam);
            cmd.Parameters.AddWithValue("@email", email);
            connection.Open();
            int n=cmd.ExecuteNonQuery();
            connection.Close();

            if (n > 0)
            {
                return true;
            }
            else
                return false;
        }
        public bool DeleteData(string name)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "delete from Organization where Name=@name ";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@name", name);
            connection.Open();
            int n = cmd.ExecuteNonQuery();
            connection.Close();
            if (n > 0)
            {
                return true;
            }
            else
                return false;
           
        }
        public bool UpdateData(string name,string email)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "update Organization set Email=@email where Name=@name ";
            SqlCommand cmd = new SqlCommand(query, connection);
           
            cmd.Parameters.AddWithValue("@name",name);
            
            cmd.Parameters.AddWithValue("@email", email);
          

            connection.Open();
           int i= cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
                return true;
            else
                return false;

        }

    }
}