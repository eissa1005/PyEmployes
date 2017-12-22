using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BOL
{
    public class ValidtiontblInOut
    {
        //[DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = " Date Must be Equal Today ")]
        [CurrentDate]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> DT { get; set; }

        [Required(ErrorMessage="Please Enter Value Like 00:00")]
        [DataType(DataType.Time)]
        public TimeSpan Start_IN { get; set; }

        [Required(ErrorMessage = "Please Enter Value Like 00:00")]
        [DataType(DataType.Time)]
        public TimeSpan Out_IN { get; set; }

    }

    [MetadataType(typeof(ValidtiontblInOut))]
    public partial class tbl_PyInOut
    {

    }
}
