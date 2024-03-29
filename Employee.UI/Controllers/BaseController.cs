﻿using Employee.UI.Abstract;
using Employee.UI.Implementation;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace Employee.UI.Controllers
{
    public class BaseController : Controller
    {
        protected IUserService userService;
        protected ILoginService loginService;
        protected IStateService stateService;
      
        protected ICityService cityService;

        protected string AadhaarRootPath = Path.Combine(HttpRuntime.AppDomainAppPath, "Upload\\Aadhaar");
        protected string PanRootPath = Path.Combine(HttpRuntime.AppDomainAppPath, "Upload\\PAN");

        public BaseController()
        {
            userService = new UserService();
            loginService = new LoginService();
            stateService = new StateService();
            cityService = new CityService();

            if (!Directory.Exists(AadhaarRootPath))
            {
                Directory.CreateDirectory(AadhaarRootPath);
            }
            if (!Directory.Exists(PanRootPath))
            {
                Directory.CreateDirectory(PanRootPath);
            }
        }
    }
}