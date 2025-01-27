using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibrary.DTOs
{
    public class EmployeeGrouping2
    {
        [Required,Range(1,99999,ErrorMessage ="You must select specialization")]
        public int SpecializationID {  get; set; }
        [Required, Range(1, 99999, ErrorMessage = "You must select town")]
        public int TownID { get; set; }
        //[Required, Range(1, 99999, ErrorMessage = "You must select user")]
        //public int UserID { get; set; }

    }
}
