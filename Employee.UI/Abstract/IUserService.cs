using System.Collections.Generic;

namespace Employee.UI.Abstract
{
    public interface IUserService
    {
        bool DeleteUsers(List<int> userIds);
    }
}
