using Employee.UI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Employee.UI.Abstract;
using System.Configuration;

namespace Employee.UI.Implementation
{
    public class CityService :BaseService, ICityService
    {
        public List<CityViewModel> CityList(int stateId)
        {
            List<CityViewModel> city = new List<CityViewModel>();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString);
            try
            {
                using (DataTable dtResult = ExecuteReader("select * from CityMaster where StateID=" + stateId, CommandType.Text))
                {
                    if (dtResult!=null&&  dtResult.Rows.Count>0)
                    {
                        for (int i = 0; i < dtResult.Rows.Count; i++)
                        {
                            CityViewModel cityObj = new CityViewModel();

                            cityObj.Id = Convert.ToInt32(dtResult.Rows[i]["Id"]);
                            cityObj.Name = Convert.ToString(dtResult.Rows[i]["Name"]);

                            city.Add(cityObj);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
         return city;

        }
    }
}
