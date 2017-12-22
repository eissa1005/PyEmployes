using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BOL
{
    class UniqueEmployeeIdAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                PYEmployeeEntities db = new PYEmployeeEntities();
                string EmployeeId = value.ToString();
                int count = db.tbl_Employees.Where(x => x.EmployeeId == EmployeeId).Count();
                if (count != 0)
                    return new ValidationResult("EmployeeId is already exists");
            }
            return ValidationResult.Success;
        }
    }


    public class tblEmployeevalidation
    {
        [UniqueEmployeeId]
        [Required(ErrorMessage = "this field is required ")]
        public string EmployeeId { get; set; }
        [Required(ErrorMessage = "this field is required")]
        public string Employee_Name { get; set; }

        public string Guarantor { get; set; }
        public string Mobile { get; set; }
        public string EmplyeeImg { get; set; }
       
        
        public Nullable<System.DateTime> HireDate { get; set; }

    }
    [MetadataType(typeof(tblEmployeevalidation))]
    public partial class tbl_Employees
    {

    }
}
