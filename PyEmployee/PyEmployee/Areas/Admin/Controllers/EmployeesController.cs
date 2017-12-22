using BOL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ifind.Areas.Admin.Controllers
{
    [Authorize(Roles = "A")]
    public class EmployeesController : DataBase
    {
        string Lang = "";

        // GET: Admin/Employees

        public ActionResult Index(string Lang)
        {
            #region Lang
            try
            {
                if (Session["Lang"] != null && Session["Lang"].ToString() != "")
                {
                    Lang = Session["Lang"].ToString();
                    if (Lang == "Ar")
                        return View("Employees_Ar");
                    else
                        return View("Index");
                }
                else
                    return View();
            }
            catch (Exception) { }
            #endregion

            return View();
        }


        [HttpPost]
        public ActionResult Create(HttpPostedFileBase file, tbl_Employees Employe)
        {
            #region File Images
            if (file != null && file.ContentLength > 0)
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        var imageType = file.ContentType;
                        string[] typeParameters = imageType.Split('/');
                        string photoExtention = typeParameters[1];
                        var EmployeeName = Employe.Employee_Name;
                        var EmployeeId = Employe.EmployeeId;

                        string path = Path.Combine(Server.MapPath("~/Images/PhotoEmployee/"), "_" + EmployeeName + "_" + EmployeeId + "." + photoExtention);
                        string RelativePath = path.Replace(Request.ServerVariables["APPL_PHYSICAL_PATH"], String.Empty);
                        Employe.EmplyeeImg = RelativePath;
            #endregion

                        #region Create
                        objBs.EmployeesBs.Insert(Employe);
                        file.SaveAs(path);

                        TempData["msg"] = "Employee Added Successfully";
                    }
                    catch (Exception ex)
                    {
                        TempData["msg"] = "ERROR:" + ex.Message.ToString();
                    }
                }
                return RedirectToAction("Index", "ListEmployees");
            }
            else
            {
                TempData["msg"] = "You have not specified a file.";
            }
            return RedirectToAction("Index", "Employees");
                        #endregion

        }
    }
}