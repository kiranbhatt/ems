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
                List<UserListViewModel> lists = userService.List();
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
            bool result = userService.Delete(delArray);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpGet]
        public ActionResult Register()
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

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                UploadAadhar(model);

                UploadPanCard(model);

                bool result = userService.Register(model);

                if (result == true)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        private void UploadAadhar(RegisterViewModel model)
        {
            if (model.AadhaarFile != null)
            {
                string userAadhaarPath = string.Concat(AadhaarRootPath + "\\", model.UserName);

                if (!Directory.Exists(userAadhaarPath))
                {
                    Directory.CreateDirectory(userAadhaarPath);
                }

                string fileName = "AAD_" + model.AadhaarNumber + Path.GetExtension(model.AadhaarFile.FileName);
                model.AadhaarFile.SaveAs(userAadhaarPath + "\\" + fileName);

                model.AadhaarFileName = fileName;
            }
        }

        private void UploadPanCard(RegisterViewModel model)
        {
            if (model.UploadPanCard != null)
            {
                string userPanPath = string.Concat(PanRootPath + "\\", model.UserName);

                if (!Directory.Exists(userPanPath))
                {
                    Directory.CreateDirectory(userPanPath);
                }

                string fileName = "PAN_" + model.PanCardNumber + Path.GetExtension(model.UploadPanCard.FileName);
                model.UploadPanCard.SaveAs(userPanPath + "\\" + fileName);

                model.PanCardFileName = fileName;
            }
        }
    }
}
