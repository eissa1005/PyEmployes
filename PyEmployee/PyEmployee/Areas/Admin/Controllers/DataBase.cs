using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using DAL;
using BOL;

namespace ifind.Areas.Admin.Controllers
{
    public class DataBase:Controller
    {
        public BaseBs objBs{set;get;}
        public DataBase()
        {
            objBs = new BaseBs();
        }
    }
}