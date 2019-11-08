using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.UI.Abstract
{
    public interface IUserService
    {
        bool DeleteUsers(List<int> userIds);
    }
}
