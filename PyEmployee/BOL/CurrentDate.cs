using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BOL
{
   public class CurrentDate : ValidationAttribute
    {
       public override bool IsValid(object value)
       {
           DateTime dateTime = Convert.ToDateTime(value);
           if (dateTime <= DateTime.Now)
               return true;
           else
               return false;
       }

    }
}
