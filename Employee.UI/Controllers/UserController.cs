using Employee.UI.Abstract;
using Employee.UI.Implementation;
using Employee.UI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

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
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
        model.Email, DateTime.Now, DateTime.Now.AddMinutes(30),
        true, "admin", FormsAuthentication.FormsCookiePath);

                    var encryptedTicket = FormsAuthentication.Encrypt(ticket);
                    var isSsl = Request.IsSecureConnection; // if we are running in SSL mode then make the cookie secure only

                    var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket)
                    {
                        HttpOnly = true, // always set this to true!
                        Secure = isSsl,
                    };

                    Response.Cookies.Set(cookie);

                    return Redirect("/Home/Index");

                    //string returnUrl = Request.QueryString["ReturnUrl"];
                    //if (returnUrl == null)
                    //{
                    //    returnUrl = "/Home";
                    //    return Redirect(returnUrl);
                    //}
                    //else
                    //{
                    //    return Redirect(returnUrl);
                    //}
                }

            }
            return View();
        }
    }
}