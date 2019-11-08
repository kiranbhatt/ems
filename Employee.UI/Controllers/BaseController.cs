using Employee.UI.Abstract;
using Employee.UI.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Employee.UI.Controllers
{
    public class BaseController : Controller
    {
        protected IUserListViewModel userListService;

        public BaseController()
        {
            userListService= new UserListService();
        }
       
    }
}