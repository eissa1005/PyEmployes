using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using BOL;
using DAL;
using System.Web.Security;

namespace ifind.Areas.Security.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {

        public ActionResult Index(string Lang)
        {
            #region Lang

            Session["Lang"] = Lang;

            if (Lang == "Ar")
            {
                return View("Login_Ar");
            }
            else
            {
                return View("Index");
            }
            #endregion
        }

        [HttpPost]
        public ActionResult SignIn(tbl_User user)
        {
            #region Login
            if (Membership.ValidateUser(user.UserName, user.Password))
            {
                
                FormsAuthentication.SetAuthCookie(user.UserName,true);
                TempData["msg"] = " Login is Successfully";
                return RedirectToAction("Index", "Home", new { Area = "Common" });
            }
            else
            {
                TempData["msg"] = " Login Falid  in UserName or Password";
                return RedirectToAction("Index", "Home", new { Area = "Common" });
            }
            #endregion
        }
        public ActionResult SignOut()
        {
            
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home", new { Area = "Common" });
        }
    }
}