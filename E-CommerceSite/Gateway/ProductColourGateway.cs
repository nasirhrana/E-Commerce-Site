using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using E_CommerceSite.Models;

namespace E_CommerceSite.Gateway
{
    public class ProductColourGateway
    {
        private SqlConnection con = new SqlConnection(
            WebConfigurationManager.ConnectionStrings["EcommerceDB"].ConnectionString);
        public int SaveColour(ProductColour productColour)
        {
            string query = @"INSERT INTO [dbo].[ProductColour]
           ([ProductColour])
     VALUES('" + productColour.ProductColourName + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int rowAffected = cmd.ExecuteNonQuery();
            con.Close();
            return rowAffected;
        }

        public bool IsColourExists(string colourname)
        {

            bool isExists = false;

            string query = "SELECT * FROM [dbo].[ProductColour] WHERE (ProductColour= @ProductColour) ";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.Parameters.AddWithValue("@ProductColour", colourname);
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