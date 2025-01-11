using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibrary.Entities
{
    public class EmployeeTypes
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public List<Employee>? Employees { get; set; }
    }
}
