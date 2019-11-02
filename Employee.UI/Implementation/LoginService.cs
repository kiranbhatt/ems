using Employee.UI.Abstract;
using Employee.UI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Employee.UI.Implementation
{
    public class LoginService : ILoginService
    {
        public bool Authenticate(LoginViewModel model)
        {
            SqlConnection con = new SqlConnection("Data source=DESKTOP-OU6QMCI\\SQLEXPRESS;initial catalog=EMS;integrated security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from User where Email= '" + model.Email + "' and Password='" + model.Password + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                return true;
            }
            con.Close();

            return false;
        }
    }
}