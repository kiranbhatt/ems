using Employee.UI.Abstract;
using Employee.UI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Security;
using System.Web.Script.Serialization;
using System.Security.Principal;
using System.Configuration;
using System.Data;

namespace Employee.UI.Implementation
{
    public class LoginService : BaseService, ILoginService
    {
        public bool Authenticate(LoginViewModel model)
        {
            DataTable dtResult = ExecuteReader("select * from [User] where Email= '" + model.Email + "' and Password='" + model.Password + "'", CommandType.Text);

            if (dtResult.Rows.Count > 0)
            {
                return true;
            }

            return false;
        }
    }
}