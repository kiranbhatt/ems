using Employee.UI.Abstract;
using Employee.UI.Implementation;
using Employee.UI.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Employee.UI.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController() : base()
        {

        }

        //[Authorize(Roles = "admin")]
        public ActionResult Index(string ReturnUrl)
        {
            if (ReturnUrl != null)
            {
                Response.Redirect(ReturnUrl);
            }
            else
            {
                List<UserListViewModel> lists = userListService.UserList();
                return View(lists);
            }

            return View();
        }


        [HttpGet]
        public PartialViewResult _UserList()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult JsonGetStatesInfo(List<int> delArray)
        {
            IUserService userService = new UserService();
            bool result = userService.DeleteUsers(delArray);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            IStateService stateService = new StateService();
            List<StateViewModel> states = stateService.StateList();

            ViewBag.StateList = states;

            return View();
        }


        [HttpGet]
        public ActionResult CitiesByStateId(int stateId = 0)
        {
            ICityService cityService = new CityService();
            List<CityViewModel> city = cityService.CityList(stateId);
            return Json(city, JsonRequestBehavior.AllowGet);
        }


        //[HttpPost]
        //public ActionResult AadharUpload(HttpPostedFileBase file)
        //{
        //    if (file != null && file.ContentLength > 0)
        //        try
        //        {
        //            string path = Path.Combine(Server.MapPath("~/Images"),
        //                                       Path.GetFileName(file.FileName));
        //            file.SaveAs(path);
        //            ViewBag.Message = "File uploaded successfully";
        //        }
        //        catch (Exception ex)
        //        {
        //            ViewBag.Message = "ERROR:" + ex.Message.ToString();
        //        }
        //    else
        //    {
        //        ViewBag.Message = "You have not specified a file.";
        //    }
        //    return View();
        //}


        [HttpPost]
        public ActionResult Contact(RegisterViewModel model)
        {
            //        var errors = ModelState
            //.Where(x => x.Value.Errors.Count > 0)
            //.Select(x => new { x.Key, x.Value.Errors })
            //.ToArray();

            if (ModelState.IsValid)
            {
                string path = Server.MapPath("~/Uploads/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                if (model.PostedFile != null)
                {
                    string fileName = Path.GetFileName(model.PostedFile.FileName);
                    model.PostedFile.SaveAs(path + fileName);
                }

                IRegisterService RegisterService = new RegisterService();
                bool result = RegisterService.Register(model);

                if (result == true)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }
    }
}
