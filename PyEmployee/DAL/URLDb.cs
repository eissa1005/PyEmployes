using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;
using System.Data.Entity;

namespace DAL
{
  public class URLDb
    {
      private LinkHubDbEntities objdb;
      public URLDb()
      {
          objdb = new LinkHubDbEntities();
      }

      public IEnumerable<tbl_Url> GetAll()
      {
          return objdb.tbl_Url.ToList();
      }

      public tbl_Url GetById(int id)
      {
          return objdb.tbl_Url.Find(id);
      }

      public void Insert(tbl_Url tblurl)
      {
          objdb.tbl_Url.Add(tblurl);
          Save();
      }

      public void Update(tbl_Url URL)
      {

          objdb.Entry(URL).State = EntityState.Modified;
          objdb.SaveChanges();
      }

      public void Delete(int id)
      {
          tbl_Url Url = objdb.tbl_Url.Find(id);
          objdb.tbl_Url.Remove(Url);
          objdb.SaveChanges();
      }
      public void Save()
      {
          objdb.SaveChanges();
      }

    }
}
