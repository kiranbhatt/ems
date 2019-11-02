using Employee.UI.Abstract;
using Employee.UI.Implementation;
using Employee.UI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Employee.UI.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                ILoginService loginService = new LoginService();
                bool result = loginService.Authenticate(model);

                if (result == true)
                {
                    return RedirectToAction("Index", "Home");
                }

            }
            return View();
        }
    }
}