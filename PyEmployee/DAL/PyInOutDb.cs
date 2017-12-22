using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;
using System.Data.Entity;

namespace DAL
{
   public class PyInOutDb
    {
       private PYEmployeeEntities db;
       public PyInOutDb()
       {
           db = new PYEmployeeEntities();
       }

       public IEnumerable<tbl_PyInOut> GetAll()
       {
           return db.tbl_PyInOut.ToList();
       }

       public tbl_PyInOut GetById(int id)
       {
           return db.tbl_PyInOut.Find(id);
       }

       public void Insert(tbl_PyInOut PyInOut)
       {
           db.tbl_PyInOut.Add(PyInOut);
           Save();
       }

       public void Delete(int Id)
       {
           tbl_PyInOut PyInOut = db.tbl_PyInOut.Find(Id);
           db.tbl_PyInOut.Remove(PyInOut);
           Save();
       }
       public void Update(tbl_PyInOut PyInOut)
       {
           db.Entry(PyInOut).State = EntityState.Modified;
           Save();
       }
       public void Save()
       {
           db.SaveChanges();
       }

    }
}
