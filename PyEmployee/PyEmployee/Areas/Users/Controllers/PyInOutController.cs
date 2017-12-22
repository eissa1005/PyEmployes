using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOL;
using DAL;
using BLL;

namespace ifind.Areas.Users.Controllers
{
    [AllowAnonymous]
    [Authorize(Roles = "A/U")]
    public class PyInOutController : BaseUser
    {
        // GET: Users/PyInOut
        PYEmployeeEntities db;
        string Lang = "";
        public PyInOutController()
        {
            db = new PYEmployeeEntities();
        }
        public ActionResult Index()
        {
            ViewBag.EmployeeId = new SelectList(db.tbl_Employees, "EmployeeId", "EmployeeId");
            #region Lang
            try
            {
                if (Session["Lang"] != null &&  Session["Lang"].ToString() != "")
                {
                    Lang = Session["Lang"].ToString();
                    if (Lang == "Ar")

                        return View("PyInOut_AR");
                    else
                        return View("Index");
                }
                else
                    return View();
            }
            catch (Exception ex)
            {
                TempData["msg"] = " Error Exception  " + ex.Message;
                return View();
            }
            #endregion
        }


        // Create Record Pyinout Employees
        [HttpPost]
        public ActionResult Create(tbl_PyInOut PyInOut)
        {
            ViewBag.EmployeeId = new SelectList(db.tbl_Employees, "EmployeeId", "EmployeeId");

            #region Create
            string Lang = "";
            try
            {
                if (ModelState.IsValid)
                {

                    if (Session["Lang"] != null && Session["Lang"].ToString() != "")
                    {
                        Lang = Session["Lang"].ToString();
                        if (Lang == "Ar")
                        {
                            if (PyInOut.DT == null)
                                PyInOut.DT = DateTime.Now;
                            objBs.PyInOutBs.Insert(PyInOut);
                            TempData["msg"] = " Record Transaction Pyinout is Successfully";
                            return View("PyInOut_AR");
                        }
                    }
                    else
                    {
                        Session["Lang"] = "En";
                        if (PyInOut.DT == null)
                            PyInOut.DT = DateTime.Now;
                        objBs.PyInOutBs.Insert(PyInOut);
                        TempData["msg"] = " Record Transaction Pyinout is Successfully";
                        return PartialView("Index");
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = " ADD Record is Falid";
                return View("Index");
            }

            #endregion
            return View("Index");
        }


        // Fill DropdwonList To later By Json 
        public JsonResult GetNameById(string id)
        {
            #region Json Method GetNameById
            db.Configuration.ProxyCreationEnabled = false;
            return Json(db.tbl_Employees.ToList().Where(x => x.EmployeeId == id), JsonRequestBehavior.AllowGet);
            #endregion
        }

    }

}