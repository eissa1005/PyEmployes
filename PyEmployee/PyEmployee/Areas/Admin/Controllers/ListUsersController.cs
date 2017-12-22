using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using BOL;
using BLL;



namespace ifind.Areas.Admin.Controllers
{
    [Authorize(Roles = "A")]

    public class ListUsersController : DataBase
    {
        // GET: Admin/ListUsers
        string Lang = "";

        public ActionResult Index(string SortOrder, string SortBy, string Pages)
        {

            var Users = objBs.UserBs.GetAll();
            ViewBag.SortOrder = SortOrder;
            ViewBag.SortBy = SortBy;

            #region SortBy
            switch (SortBy)
            {

                case "UserName":
                    switch (SortOrder)
                    {
                        case "ASC":
                            Users = Users.OrderBy(x => x.UserName).ToList();
                            break;

                        case "Desc":
                            Users = Users.OrderByDescending(x => x.UserName).ToList();
                            break;
                    }
                    break;

                case "Role":
                    switch (SortOrder)
                    {
                        case "ASC":
                            Users = Users.OrderBy(x => x.Role).ToList();
                            break;

                        case "Desc":
                            Users = Users.OrderByDescending(x => x.Role).ToList();
                            break;
                    }
                    break;

                default:
                    Users = Users.OrderByDescending(x => x.UserName).ToList();
                    break;
            }
            #endregion

            #region Pages
            ViewBag.TotalPages = Math.Ceiling(objBs.UserBs.GetAll().Count() / 6.0);
            int page = int.Parse(Pages == null ? "1" : Pages);
            ViewBag.Pages = page;
            Users = Users.Skip((page - 1)).Take(6).ToList();
            #endregion

            #region Lang
            try
            {
                if (Session["Lang"] != null && Session["Lang"].ToString() != "")
                {
                    string Lang = Session["Lang"].ToString();


                    if (Lang == "Ar")
                    {
                        return View("ListUser_AR", Users);

                    }

                    else
                    {
                        return View(Users);
                    }
                }
                else
                {
                    return View(Users);
                }
            }
            catch (Exception)
            {
                return View(Users);
            }
            #endregion
        
        }
    }
}