using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;

namespace DAL
{
    public class CategoryDb
    {
        private LinkHubDbEntities db;
        public CategoryDb()
        {
            db = new LinkHubDbEntities();
        }
        public IEnumerable<tbl_Category> GetAll()
        {
            return db.tbl_Category.ToList();
        }
        public tbl_Category GetById(int Id)
        {
            return db.tbl_Category.Find(Id);
        }
        public void Insert(tbl_Category category)
        {

            db.tbl_Category.Add(category);
            save();

        }
        public void Delete(int Id)
        {
            tbl_Category cat = db.tbl_Category.Find(Id);
            db.tbl_Category.Remove(cat);
            save();
        }
        public void Update(tbl_Category cat)
        {
            db.Entry(cat).State = EntityState.Modified;
            save();
        }
        public void save()
        {
            db.SaveChanges();
        }
    }
}
