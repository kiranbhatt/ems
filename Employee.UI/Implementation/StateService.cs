using Employee.UI.Abstract;
using Employee.UI.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Configuration;

namespace Employee.UI.Implementation
{
    public class StateService : IStateService
    {
        public List<StateViewModel> StateList()
        {
            List<StateViewModel> states = new List<StateViewModel>();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from StateMaster", con);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    StateViewModel stateObj = new StateViewModel();

                    stateObj.Id = Convert.ToInt32(dr[0]);
                    stateObj.Name = Convert.ToString(dr[1]);

                    states.Add(stateObj);
                }
                con.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return states;

        }
    }
}