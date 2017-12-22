using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ifind.Areas.Admin.Controllers
{
    [Authorize(Roles = "A")]
    public class ListEmployeesController : DataBase
    {
        // GET: Admin/ListEmployees
        private tbl_User user;
        private PYEmployeeEntities db;
        string Lang = "";
        public ListEmployeesController()
        {
            db = new PYEmployeeEntities();
            user = new tbl_User();
        }

        public ActionResult Index(string SortOrder, string SortBy, string Pages)
        {
            var Employees = objBs.EmployeesBs.GetAll();

            #region SortBy
            ViewBag.SortOrder = SortOrder;
            ViewBag.SortBy = SortBy;
            switch (SortBy)
            {
                case "EmployeeId":
                    switch (SortOrder)
                    {
                        case "ASC":

                            Employees = Employees.OrderBy(x => x.EmployeeId).ToList();
                            break;

                        case "Desc":
                            Employees = Employees.OrderByDescending(x => x.EmployeeId).ToList();
                            break;
                    }
                    break;

                case "Employee_Name":
                    switch (SortOrder)
                    {
                        case "ASC":

                            Employees = Employees.OrderBy(x => x.Employee_Name).ToList();
                            break;

                        case "Desc":

                            Employees = Employees.OrderByDescending(x => x.Employee_Name).ToList();
                            break;
                    }
                    break;

                case "Guarantor":
                    switch (SortOrder)
                    {
                        case "ASC":
                            Employees = Employees.OrderBy(x => x.Guarantor).ToList();
                            break;

                        case "Desc":
                            Employees = Employees.OrderByDescending(x => x.Guarantor).ToList();
                            break;
                    }
                    break;
                case "HireDate":
                    switch (SortOrder)
                    {
                        case "ASC":
                            Employees = Employees.OrderBy(x => x.HireDate).ToList();
                            break;

                        case "Desc":
                            Employees = Employees.OrderByDescending(x => x.HireDate).ToList();
                            break;
                    }
                    break;

                default:
                    Employees = Employees.OrderByDescending(x => x.HireDate).ToList();
                    break;
            }
            #endregion

            #region  Pages
            ViewBag.TotalPages = Math.Ceiling(objBs.EmployeesBs.GetAll().Count() / 6.0);
            int page = int.Parse(Pages == null ? "1" : Pages);
            ViewBag.Pages = page;
            Employees = Employees.Skip((page - 1)).Take(6).ToList();
            #endregion

            #region Lang
            try
            {
                if (Session["Lang"] != null && Session["Lang"].ToString() != "")
                {
                    string Lang = Session["Lang"].ToString();
                    if (Lang == "Ar")
                        return View("ListEmployees_AR", Employees);
                    else
                        return View(Employees);
                }
                else
                {
                    return View(Employees);
                }
            }
            catch (Exception) { }
            #endregion

            return View(Employees);
        }


        public ActionResult Edit(int id)
        {
            tbl_Employees emp = objBs.EmployeesBs.GetById(id);

            #region Lang
            if (Session["Lang"] != null && Session["Lang"].ToString() != "")
            {
                string Lang = Session["Lang"].ToString();


                if (Lang == "Ar")
                {
                    return View("Edit_AR", emp);

                }

                else
                {
                    return View(emp);
                }
            }
            else
            {
                return View(emp);
            }
            #endregion
        }


        [HttpPost]
        public ActionResult Edit(HttpPostedFileBase file, tbl_Employees Employe, string Old, int id)
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

                        file.SaveAs(path);
                        // Update This Record
            #endregion

                        #region Edit & Message
                        objBs.EmployeesBs.Update(Employe);
                        TempData["msg"] = "Employee " + Employe.Employee_Name + " Edited Successfully";
                        return RedirectToAction("Index", "ListEmployees", new { Areas = "Admin" });
                    }
                    catch (Exception ex)
                    {
                        TempData["msg"] = "Edit is Failed" + ex.Message;
                        return View();
                    }
                }
                return View();


            }
            else
            {
                TempData["msg"] = "Image Not Loaded  Please Try ,Again";
                return View();
            }
                        #endregion
        }



        // Action Delete
        [HttpPost]
        [ValidateInput(true)]
        public ActionResult Delete(int id)
        {
            #region Action Delete
            if (ModelState.IsValid)
            {
                try
                {
                    tbl_Employees Employee = objBs.EmployeesBs.GetById(id);
                    objBs.EmployeesBs.Delete(Employee);
                    TempData["msg"] = "Employee " + Employee.Employee_Name + " Delete Successfully";
                    return RedirectToAction("Index", "ListEmployees", new { Areas = "Admin" });
                }
                catch (Exception Ex)
                {
                    TempData["msg"] = "Employees Delete Falid" + Ex.Message;
                    return RedirectToAction("Index", "ListEmployees", new { Areas = "Admin" });
                }
            }
            else
            {
                TempData["msg"] = "Employees Delete Falid";
                return RedirectToAction("Index", "ListEmployees", new { Areas = "Admin" });
            }
            #endregion


        }

        [HttpGet]
        public JsonResult Get()
        {

            db.Configuration.ProxyCreationEnabled = false;
            var Emp = db.tbl_Employees.ToList();
            return Json(Emp, JsonRequestBehavior.AllowGet);
           
        }


        public JsonResult Condition(string EmployeeId, string Employee_Name)
        {
            #region //Search
            var Emp = objBs.EmployeesBs.GetAll().ToList();

            ViewBag.EmployeeId = EmployeeId;
            ViewBag.EmployeeName = Employee_Name;

            if (!(string.IsNullOrEmpty(EmployeeId)))
                Emp = Emp.Where(x => x.Employee_Name.StartsWith(EmployeeId)).ToList();


            else if (!(string.IsNullOrEmpty(Employee_Name)))
                Emp = Emp.Where(x => x.Employee_Name.StartsWith(Employee_Name)).ToList();
            else
                Emp = objBs.EmployeesBs.GetAll().ToList();
            db.Configuration.ProxyCreationEnabled = false;
            return Json(Emp, JsonRequestBehavior.AllowGet);
            #endregion
        }
    }
}