using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;
using System.Data.Entity;

namespace DAL
{
   public class EmployeeDb
    {
       private PYEmployeeEntities db;

       public EmployeeDb()
       {
           db = new PYEmployeeEntities();
       }

       public IEnumerable<tbl_Employees> GetAll()
       {
           return db.tbl_Employees.ToList();
       }

       public tbl_Employees GetById(int id)
       {
           return db.tbl_Employees.SingleOrDefault(x=>x.ID==id);
       }

       public void Insert(tbl_Employees emp)
       {
           db.tbl_Employees.Add(emp);
           Save();
       }

       public void Delete(tbl_Employees  Employee)
       {
           tbl_Employees emp = db.tbl_Employees.FirstOrDefault(x=>x.ID==Employee.ID);
           db.tbl_Employees.Remove(emp);
           Save();
       }
       public void Update(tbl_Employees emp)
       {
           db.Entry(emp).State = EntityState.Modified;
           Save();
       }
       public void Save()
       {
           db.SaveChanges();
       }
    }
}
