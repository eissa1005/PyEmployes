using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;
using System.Data.Entity;

namespace DAL
{
   public class UserDb
    {
        private PYEmployeeEntities db;

        public UserDb()
        {
            db = new PYEmployeeEntities();
        }

        public IEnumerable<tbl_User> GetAll()
        {
            return db.tbl_User.ToList();
        }

        public tbl_User GetById(int id)
        {
            return db.tbl_User.Find(id);
        }

        public void Insert(tbl_User user)
        {
            db.tbl_User.Add(user);
            Save();
        }

        public void Delete(int Id)
        {
            tbl_User User = db.tbl_User.Find(Id);
            db.tbl_User.Remove(User);
            Save();
        }
        public void Update(tbl_User User)
        {
            db.Entry(User).State = EntityState.Modified;
            Save();
        }
        public void Save()
        {
            db.SaveChanges();
        }

    }
}
