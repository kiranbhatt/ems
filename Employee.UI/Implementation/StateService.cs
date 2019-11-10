using Employee.UI.Abstract;
using Employee.UI.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;

namespace Employee.UI.Implementation
{
    public class StateService : BaseService, IStateService
    {
        public List<StateViewModel> StateList()
        {
            List<StateViewModel> states = new List<StateViewModel>();

            using (DataTable dtResult = ExecuteReader("select * from StateMaster", CommandType.Text))
            {
                if (dtResult != null && dtResult.Rows.Count > 0)
                {
                    for (int i = 0; i < dtResult.Rows.Count; i++)
                    {
                        StateViewModel stateObj = new StateViewModel();

                        stateObj.Id = Convert.ToInt32(dtResult.Rows[i]["Id"]);
                        stateObj.Name = Convert.ToString(dtResult.Rows[i]["Name"]);

                        states.Add(stateObj);
                    }
                }
            }
            return states;
        }
    }
}