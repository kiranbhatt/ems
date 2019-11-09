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
    public class UserListService : BaseService, IUserListViewModel
    {
        public List<UserListViewModel> UserList()
        {
            List<UserListViewModel> userLists = new List<UserListViewModel>();

            using (DataTable dtResult = ExecuteReader("select * from [User] order by 1 desc", CommandType.Text))
            {
                if (dtResult.Rows.Count > 0)
                {
                    for (int i = 0; i < dtResult.Rows.Count; i++)
                    {
                        UserListViewModel userModel = new UserListViewModel
                        {
                            UserId = Convert.ToInt32(dtResult.Rows[i]["UserId"]),
                            UserName = Convert.ToString(dtResult.Rows[i]["UserName"]),
                            Email = Convert.ToString(dtResult.Rows[i]["Email"]),
                            PrimaryPhone = Convert.ToString(dtResult.Rows[i]["PrimaryPhone"]),
                            AadhaarNumber = dtResult.Rows[i]["AadhaarNumber"] == DBNull.Value ? 0 : Convert.ToInt64(dtResult.Rows[i]["AadhaarNumber"]),
                            PanCardNumber = dtResult.Rows[i]["PanCardNumber"] == DBNull.Value ? "N/A" : Convert.ToString(dtResult.Rows[i]["PanCardNumber"]),
                            IsActive = dtResult.Rows[i]["IsActive"] == DBNull.Value ? false : Convert.ToBoolean(dtResult.Rows[i]["IsActive"])
                        };
                        userLists.Add(userModel);
                    }
                }
            }
            return userLists;
        }
    }
}
