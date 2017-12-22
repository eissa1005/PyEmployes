using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BOL;

namespace BLL
{
    public class UserBs
    {
        private UserDb obj;

        public UserBs()
        {
            obj = new UserDb();
        }

        public IEnumerable<tbl_User> GetAll()
        {
            return obj.GetAll();
        }

        public tbl_User GetById(int id)
        {
            return obj.GetById(id);
        }

        public void Insert(tbl_User user)
        {
            obj.Insert(user);
        }

        public void Update(tbl_User user)
        {
            obj.Update(user);
        }

        public void Delete(int id)
        {
            obj.Delete(id);
        }
    }
}
