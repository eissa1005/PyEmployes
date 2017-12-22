using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;

namespace BLL
{
    public class BaseBs
    {
        public UserBs UserBs { set; get; }
        public EmployeesBs EmployeesBs { set; get; }
        public PyInOutBs PyInOutBs { set; get; }

        public BaseBs()
        {
            UserBs = new UserBs();
            EmployeesBs = new EmployeesBs();
            PyInOutBs = new PyInOutBs();

        }

    }
}
