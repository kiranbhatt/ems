using Employee.UI.Abstract;
using Employee.UI.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Employee.UI.Implementation
{
    public class UserService : BaseService, IUserService
    {
        public bool Delete(List<int> userIds)
        {

            var stringsArray = userIds.Select(i => i.ToString()).ToArray();
            var values = string.Join(",", stringsArray);

            var chars = values.Split(',');

            string users = "";
            foreach (var item in chars)
            {
                if (item != ",")
                {
                    users = users + "'" + item + "',";

                }
            }

            users = users.Remove(users.LastIndexOf(','));

            bool result = ExecuteNonQuery("Delete from [User] where UserId IN (" + users + ")", CommandType.Text);
            return result;

        }

        public List<UserListViewModel> List()
        {
            List<UserListViewModel> userLists = new List<UserListViewModel>();

            using (DataTable dtResult = ExecuteReader("select * from [User] order by 1 desc", CommandType.Text))
            {
                if (dtResult != null && dtResult.Rows.Count > 0)
                {
                    for (int i = 0; i < dtResult.Rows.Count; i++)
                    {
                        UserListViewModel userModel = new UserListViewModel
                        {
                            UserId = Convert.ToInt32(dtResult.Rows[i]["UserId"]),
                            UserName = Convert.ToString(dtResult.Rows[i]["UserName"]),
                            Email = Convert.ToString(dtResult.Rows[i]["Email"]),
                            PrimaryPhone = Convert.ToString(dtResult.Rows[i]["PrimaryPhone"]),
                            AadhaarUrl = dtResult.Rows[i]["UploadAadhaar"] == DBNull.Value ? string.Empty : Convert.ToString(dtResult.Rows[i]["UploadAadhaar"]),
                            PanUrl = dtResult.Rows[i]["PanCardNumber"] == DBNull.Value ? "N/A" : Convert.ToString(dtResult.Rows[i]["PanCardNumber"]),
                            IsActive = dtResult.Rows[i]["IsActive"] == DBNull.Value ? false : Convert.ToBoolean(dtResult.Rows[i]["IsActive"])
                        };
                        userLists.Add(userModel);
                    }
                }
            }
            return userLists;
        }

        public bool Register(RegisterViewModel model)
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString);
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
                cmd.Parameters.Add(new SqlParameter("@IsAddressSame", model.IsAddressSame));
                cmd.Parameters.Add(new SqlParameter("@PermanentState", model.PermanentState));
                cmd.Parameters.Add(new SqlParameter("@PermanentCity", model.PermanentCity));
                cmd.Parameters.Add(new SqlParameter("@PermanentAddress", model.PermanentAddress));
                cmd.Parameters.Add(new SqlParameter("@AadhaarNumber", model.AadhaarNumber));
                cmd.Parameters.Add(new SqlParameter("@PanCardNumber", model.PanCardNumber));
                cmd.Parameters.Add(new SqlParameter("@UploadAadhaar", model.AadhaarFileName));
                cmd.Parameters.Add(new SqlParameter("@UploadPanCard", model.PanCardFileName));
                cmd.Parameters.Add(new SqlParameter("@Role", "user"));
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