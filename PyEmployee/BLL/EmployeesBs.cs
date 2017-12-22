using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BOL;
namespace BLL
{
  public class EmployeesBs
    {
       
        private EmployeeDb obj;

        public EmployeesBs()
        {
            obj = new EmployeeDb();
        }

        public IEnumerable<tbl_Employees> GetAll()
        {
            return obj.GetAll();
        }

        public tbl_Employees GetById(int id)
        {
            return obj.GetById(id);
        }

        public void Insert(tbl_Employees emp)
        {
            obj.Insert(emp);
        }

        public void Update(tbl_Employees emp)
        {
            obj.Update(emp);
        }

        public void Delete(tbl_Employees Employee)
        {
            obj.Delete(Employee);
        }
    }
    
}
