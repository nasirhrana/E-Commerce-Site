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


            try
            {
                string query = @"INSERT INTO [dbo].[Catagory]
           ([CatagoryName])
     VALUES('" + category.CategoryName + "')";
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

        public bool IsCategoryNameExists(string categoryname)
        {

            try
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
        public int SaveSubCategory(SubCategory subCategory)
        {
            try
            {
                string query = @"INSERT INTO [dbo].[SubCatagory]
           ([CatagoryId]
           ,[SubCatagoryName])
     VALUES('" + subCategory.CategoryId + "','" + subCategory.SubCategoryName + "')";
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

        public bool IsSubCategoryNameExists(string subCategoryName)
        {
            try
            {
                bool isExists = false;

                string query = "SELECT * FROM [dbo].[SubCatagory] WHERE (SubCatagoryName= @SubCatagoryName) ";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.AddWithValue("@SubCatagoryName", subCategoryName);
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

                return null;
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

        public int SaveItem(Item item)
        {

            try
            {
                string query = @"INSERT INTO [dbo].[Item]
           ([SubCatagoryId]
           ,[ItemName])
     VALUES('" + item.SubCategoryId + "','" + item.ItemName + "')";
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
        public bool IsItemNameExists(string itemName)
        {

            try
            {
                bool isExists = false;

                string query = "SELECT * FROM [dbo].[Item] WHERE (ItemName= @ItemName) ";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.AddWithValue("@ItemName", itemName);
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