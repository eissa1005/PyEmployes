using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;
using DAL;

namespace BLL
{
  public class PyInOutBs
    {
      private PyInOutDb obj;
      public PyInOutBs()
      {
          obj = new PyInOutDb();
      }

      public IEnumerable<tbl_PyInOut> GetAll()
      {
          return obj.GetAll();
      }
      public tbl_PyInOut GetById(int id)
      {
          return obj.GetById(id);
      }

      public void Insert(tbl_PyInOut PyInOut )
      {
          obj.Insert(PyInOut);
      }

      public void Update(tbl_PyInOut PyInOut)
      {
          obj.Update(PyInOut);
      }

      public void Delete(int id)
      {
          obj.Delete(id);
      }

    }
}
