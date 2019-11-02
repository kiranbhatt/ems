using Employee.UI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.UI.Abstract
{
    interface ICityService
    {
        List<CityViewModel> CityList(int stateId);
    }
}
