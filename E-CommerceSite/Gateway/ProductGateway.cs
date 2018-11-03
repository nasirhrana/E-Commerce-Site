using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using E_CommerceSite.Models;

namespace E_CommerceSite.Gateway
{
    public class ProductGateway
    {
        private SqlConnection con = new SqlConnection(
            WebConfigurationManager.ConnectionStrings["EcommerceDB"].ConnectionString);
        public List<Category> GetAllCategory()
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
            con.Close();
            return aList;
        }
        public List<SubCategory> GetSubCategoryByCategoryId(int id)
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
            con.Close();
            return aList;
        }
        public List<Item> GetItemBySubCategoryId(int id)
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
            con.Close();
            return aList;
        }
        public List<ProductSize> GetProductSizeBySubCategoryId(int id)
        {
            string query = @"SELECT * FROM [dbo].[ProductSize] where SubCatagoryId='" + @id + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<ProductSize> aList = new List<ProductSize>();
            while (reader.Read())
            {
                ProductSize aCategory = new ProductSize();
                aCategory.ProductSizeId = (int)reader["ProductSizeId"];
                aCategory.ProductSizeName = reader["ProductSize"].ToString();

                aList.Add(aCategory);
            }
            reader.Close();
            con.Close();
            return aList;
        }
        public int PublishProduct(Product product)
        {
            string query = @"INSERT INTO [dbo].[Product]
           ([ItemId]
           ,[Image]
           ,[Description]
           ,[ProductSizeId]
           ,[Prize]
           ,[Discount]
           ,[Colour]
           ,[DateOfPublish]
           ,[Status])
     VALUES('" + product.ItemId + "','" + product.UploadFile + "','" + product.Description + "','" + product.ProductSizeId + "','" + product.Prize + "','" + product.Discount + "','" + product.Colour + "','" + product.DateOfPublish + "','" + product.Status + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int rowAffected = cmd.ExecuteNonQuery();
            con.Close();
            return rowAffected;
        }
    }
}