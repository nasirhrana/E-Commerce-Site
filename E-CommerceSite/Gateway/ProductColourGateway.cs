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


            try
            {
                string query = @"INSERT INTO [dbo].[ProductColour]
           ([ProductColour])
     VALUES('" + productColour.ProductColourName + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                int rowAffected = cmd.ExecuteNonQuery();
               
                return rowAffected;
            }
            catch (Exception exception)
            {

                return 0;
            }
            finally
            {
                con.Close();
            }


            
        }

        public bool IsColourExists(string colourname)
        {


            try
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
               
                return isExists;
            }
            catch (Exception exception)
            {

                return false;
            }
            finally
            {
                con.Close();
            }



            

        }
    }
}