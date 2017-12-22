using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using BOL;
using DAL;
using ifind.Areas.Admin.Controllers;

namespace ifind.Areas.Security.Controllers
{

    [AllowAnonymous]
    public class RegisterController : DataBase
    {
        // GET: Security/Register
        public ActionResult Index()
        {
            #region Lang
            try
            {
                if (Session["Lang"].ToString() != null || Session["Lang"].ToString() != "")
                {
                    string Lang = Session["Lang"].ToString();


                    if (Lang == "Ar")
                    {
                        return View("Register_AR");

                    }

                    else
                    {
                        return View();
                    }
                }
                else
                {
                    return View();
                }
            }
            catch (Exception)
            {

            }
            #endregion
          
            return View();
        }

       
        [HttpPost]
        public ActionResult Create(tbl_User User)
        {
            #region Create
            try
            {
                if (ModelState.IsValid)
                {
                    User.Role = "U";
                    objBs.UserBs.Insert(User);
                    TempData["msg"] = "Register is Successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = "Register is Faild" + ex.Message;
                return RedirectToAction("Index");
            }
            #endregion
        }
    }
}