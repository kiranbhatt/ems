using Employee.UI.ViewModel;
using System.Collections.Generic;
using System.IO;
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

            List<StateViewModel> states = stateService.StateList();

            ViewBag.StateList = states;

            return View();
        }


        [HttpGet]
        public ActionResult CitiesByStateId(int stateId = 0)
        {

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
            if (ModelState.IsValid)
            {
                if (model.AadhaarFile != null)
                {
                    string userAadhaarPath = string.Concat(AadhaarRootPath+ "\\", model.UserName);

                    if (!Directory.Exists(userAadhaarPath))
                    {
                        Directory.CreateDirectory(userAadhaarPath);
                    }

                    string fileName = "AAD_" + model.AadhaarNumber + Path.GetExtension(model.AadhaarFile.FileName);
                    model.AadhaarFile.SaveAs(userAadhaarPath + "\\" + fileName);

                    model.AadhaarFileName = fileName;
                }


                bool result = registerService.Register(model);

                if (result == true)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }
    }
}
