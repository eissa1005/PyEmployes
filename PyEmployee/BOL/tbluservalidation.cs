using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BOL
{
    public class UniqueEmailAttribute:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
              
                PYEmployeeEntities db = new PYEmployeeEntities();
                string UserNameValue = value.ToString();
                int count = db.tbl_User.Where(x => x.UserName == UserNameValue).ToList().Count();
                if (count != 0)
                    return new ValidationResult(" user name is already exists");
            }
            return ValidationResult.Success;

        }
    }
   
   public class tbluservalidation
    {
       [Required]
       
       [UniqueEmail]
        public string UserName { get; set; }

       [Required]
        public string Password { get; set; }
       [Compare("Password")]
       public string ConfirmPassword { get; set; }

    }

    [MetadataType(typeof(tbluservalidation))]
   public partial class tbl_User
    {
        public string ConfirmPassword { get; set; }
    }
}
