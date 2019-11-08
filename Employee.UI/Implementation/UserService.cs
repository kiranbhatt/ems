using Employee.UI.Abstract;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Employee.UI.Implementation
{
    public class UserService : BaseService,IUserService
    {
        public bool DeleteUsers(List<int> userIds)
        {

            var stringsArray = userIds.Select(i => i.ToString()).ToArray();
            var values = string.Join(",", stringsArray);

            var chars = values.ToCharArray();

            string users = "";
            foreach (var item in chars)
            {
                if (item != ',')
                {
                    users = users + "'" + item + "',";
                 
                }
            }

            users = users.Remove(users.LastIndexOf(','));

            bool result = ExecuteNonQuery("Delete from [User] where UserId IN (" + users + ")", CommandType.Text);
            return result;

        }
    }
}