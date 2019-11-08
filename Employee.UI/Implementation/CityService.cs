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
    public class CityService : ICityService
    {
        public List<CityViewModel> CityList(int stateId)
        {
            List<CityViewModel> city = new List<CityViewModel>();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from CityMaster where StateID=" + stateId, con);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    CityViewModel cityObj = new CityViewModel();

                    cityObj.Id = Convert.ToInt32(dr[0]);
                    cityObj.Name = Convert.ToString(dr[1]);

                    city.Add(cityObj);
                }
                con.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return city;

        }
    }
}
