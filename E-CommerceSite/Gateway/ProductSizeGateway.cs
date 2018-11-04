using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using E_CommerceSite.Models;

namespace E_CommerceSite.Gateway
{
    public class ProductSizeGateway
    {
        private SqlConnection con = new SqlConnection(
            WebConfigurationManager.ConnectionStrings["EcommerceDB"].ConnectionString);
        public List<Category> GetAllCategory()
        {


            try
            {
                string query = @"SELECT * FROM [dbo].[Catagory]";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<Category> aList = new List<Category>();
                while (reader.Read())
                {
                    Category aCategory = new Category();
                    aCategory.CategoryId = (int)reader["CatagoryId"];
                    aCategory.CategoryName = reader["CatagoryName"].ToString();

                    aList.Add(aCategory);
                }
                reader.Close();
                
                return aList;
            }
            catch (Exception exception)
            {

                return null ;
            }
            finally
            {
                con.Close();
            }


            
        }
        public List<SubCategory> GetSubCategoryByCategoryId(int id)
        {


            try
            {
                string query = @"SELECT * FROM [dbo].[SubCatagory] where CatagoryId='" + @id + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<SubCategory> aList = new List<SubCategory>();
                while (reader.Read())
                {
                    SubCategory aCategory = new SubCategory();
                    aCategory.SubCategoryId = (int)reader["SubCatagoeyId"];
                    aCategory.SubCategoryName = reader["SubCatagoryName"].ToString();

                    aList.Add(aCategory);
                }
                reader.Close();
                
                return aList;
            }
            catch (Exception exception)
            {

                return null;
            }
            finally
            {
                con.Close();
            }


            
        }
        
        public int CreateProductSize(ProductSize productSize)
        {

            try
            {
                string query = @"INSERT INTO [dbo].[ProductSize]
           ([SubCatagoryId]
           ,[ProductSize])
     VALUES('" + productSize.SubCategoryId + "','" + productSize.ProductSizeName + "')";
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

        public bool IsProductSizeExists(string productSize)
        {

            try
            {
                bool isExists = false;

                string query = "SELECT * FROM [dbo].[ProductSize] WHERE (ProductSize= @ProductSize) ";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.AddWithValue("@ProductSize", productSize);
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