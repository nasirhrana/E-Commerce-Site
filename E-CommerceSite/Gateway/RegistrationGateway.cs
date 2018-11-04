using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using E_CommerceSite.Models;

namespace E_CommerceSite.Gateway
{
    public class RegistrationGateway
    {

        private SqlConnection con = new SqlConnection(
            WebConfigurationManager.ConnectionStrings["EcommerceDB"].ConnectionString);
        public int Registration(Registration registration)
        {
            
            try
            {
                string query = @"INSERT INTO [dbo].[User]
           ([UserTypeId]
           ,[UserName]
           ,[UserEmail]
           ,[UserContactNo]
           ,[UserAddress]
           ,[Gender]
           ,[DateOfBirth]
           ,[TimeOfRegistration]
           ,[Password])
     VALUES('" + registration.UserTypeId + "','" + registration.UserName + "','" + registration.UserEmail + "'," +
                               "'" + registration.UserContactNo + "','" + registration.UserAddress + "'" +
                               ",'" + registration.Gender + "','" + registration.DateOfBirth + "'," +
                               "'" + registration.TimeOfRegistration + "','" + registration.Password + "')";
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

        public bool IsEmailExists(Registration registration)
        {

            try
            {
                bool isExists = false;

                string query = "SELECT * FROM [dbo].[User] WHERE (UserEmail= @UserEmail and UserTypeId=@UserTypeId) ";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.AddWithValue("@UserEmail", registration.UserEmail);
                cmd.Parameters.AddWithValue("@UserTypeId", registration.UserTypeId);
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