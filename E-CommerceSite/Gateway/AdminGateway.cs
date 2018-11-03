using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using E_CommerceSite.Models;

namespace E_CommerceSite.Gateway
{
    public class AdminGateway
    {
        private SqlConnection con = new SqlConnection(
            WebConfigurationManager.ConnectionStrings["EcommerceDB"].ConnectionString);

        public int SaveCategory(Category category)
        {
            string query = @"INSERT INTO [dbo].[Catagory]
           ([CatagoryName])
     VALUES('" + category.CategoryName + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int rowAffected = cmd.ExecuteNonQuery();
            con.Close();
            return rowAffected;
        }

        public bool IsCategoryNameExists(string categoryname)
        {

            bool isExists = false;

            string query = "SELECT * FROM [dbo].[Catagory] WHERE (CatagoryName= @CatagoryName) ";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.Parameters.AddWithValue("@CatagoryName", categoryname);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                isExists = true;
            }

            reader.Close();
            con.Close();
            return isExists;

        }
    }
}