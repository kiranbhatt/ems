using Employee.UI.Abstract;
using Employee.UI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace Employee.UI.Implementation
{
    public class UserListService : IUserListViewModel
    {
        public List<UserListViewModel> UserList()
        {
            List<UserListViewModel> userLists = new List<UserListViewModel>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from [User] order by 1 desc", con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                UserListViewModel userModel = new UserListViewModel();
                userModel.UserId = Convert.ToInt32(dr["UserId"]);
                userModel.UserName = Convert.ToString(dr["UserName"]);
                userModel.Email = Convert.ToString(dr["Email"]);
                userModel.PrimaryPhone = Convert.ToString(dr["PrimaryPhone"]);
                userModel.AadhaarNumber = dr["AadhaarNumber"] == DBNull.Value ? 0 : Convert.ToInt64(dr["AadhaarNumber"]);
                userModel.PanCardNumber = dr["PanCardNumber"] == DBNull.Value ? "N/A" : Convert.ToString(dr["PanCardNumber"]);
                userModel.IsActive = dr["IsActive"] == DBNull.Value ? false : Convert.ToBoolean(dr["IsActive"]);
                userLists.Add(userModel);
            }
            con.Close();
            return userLists;
        }
    }
}