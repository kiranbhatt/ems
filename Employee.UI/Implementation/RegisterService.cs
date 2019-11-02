using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Employee.UI.Abstract;
using System.Data;
using Employee.UI.ViewModel;

namespace Employee.UI.Implementation
{
    public class RegisterService : IRegisterService
    {

        public bool Register(RegisterViewModel model)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data source=DESKTOP-OU6QMCI\\SQLEXPRESS;initial catalog=EMS;integrated security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_SaveUser", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@UserName", model.UserName));
                cmd.Parameters.Add(new SqlParameter("@Email", model.Email));
                cmd.Parameters.Add(new SqlParameter("@Password", model.Password));
                cmd.Parameters.Add(new SqlParameter("@DateOfBirth", model.DateOfBirth));
                cmd.Parameters.Add(new SqlParameter("@PrimaryPhone", model.PrimaryPhone));
                cmd.Parameters.Add(new SqlParameter("@SecondaryPhone", model.SecondaryPhone));
                cmd.Parameters.Add(new SqlParameter("@CurrentState", model.CurrentState));
                cmd.Parameters.Add(new SqlParameter("@CurrentCity", model.CurrentCity));
                cmd.Parameters.Add(new SqlParameter("@CurrentAddress", model.CurrentAddress));
                cmd.Parameters.Add(new SqlParameter("@IsAddressSame",model.IsAddressSame));
                cmd.Parameters.Add(new SqlParameter("@PermanentState", model.PermanentState));
                cmd.Parameters.Add(new SqlParameter("@PermanentCity", model.PermanentCity));
                cmd.Parameters.Add(new SqlParameter("@PermanentAddress", model.PermanentAddress));
                cmd.Parameters.Add(new SqlParameter("@AadhaarNumber", model.AadhaarNumber));
                cmd.Parameters.Add(new SqlParameter("@PanCardNumber", model.PanCardNumber));
                cmd.Parameters.Add(new SqlParameter("@UploadAadhaar", model.PostedFile.FileName));
                cmd.ExecuteNonQuery();

                con.Close();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}