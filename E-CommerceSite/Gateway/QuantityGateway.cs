using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using E_CommerceSite.Models;

namespace E_CommerceSite.Gateway
{
    public class QuantityGateway
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
        public List<Item> GetItemBySubCategoryId(int id)
        {

            try
            {
                string query = @"SELECT * FROM [dbo].[Item] where SubCatagoryId='" + @id + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<Item> aList = new List<Item>();
                while (reader.Read())
                {
                    Item aCategory = new Item();
                    aCategory.ItemId = (int)reader["ItemId"];
                    aCategory.ItemName = reader["ItemName"].ToString();

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
        public int SaveQuantity(ProductQuantity productQuantity)
        {

            try
            {
                string query = @"INSERT INTO [dbo].[Quantity]
           ([ItemId]
           ,[Quantity]
           ,[DateOfEntry])
     VALUES('" + productQuantity.ItemId + "','" + productQuantity.Quantity + "','" + productQuantity.DateOfEntry + "')";
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
    }
}