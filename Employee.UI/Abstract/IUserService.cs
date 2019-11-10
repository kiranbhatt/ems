using Employee.UI.ViewModel;
using System.Collections.Generic;

namespace Employee.UI.Abstract
{
    public interface IUserService
    {
        bool Delete(List<int> userIds);
        List<UserListViewModel> List();
        bool Register(RegisterViewModel model);
    }
}
