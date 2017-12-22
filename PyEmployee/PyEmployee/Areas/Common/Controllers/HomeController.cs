using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ifind.Areas.Common
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        // GET: Common/Home
        string Lang = "";
        public HomeController()
        {
        }
        public ActionResult Index()
        {
            #region Lang
            try
            {
                if (Session["Lang"].ToString() != null || Session["Lang"].ToString() !="")
                {
                    Lang = Session["Lang"].ToString();
                    if (Lang == "Ar")

                        return View("");
                    else
                        return View("Index");
                }
                else
                {
                    Session["Lang"] = "En";
                    return View();
                }
            }
            catch (Exception)
            {
                return View();
            }
#endregion
        }
    }
}