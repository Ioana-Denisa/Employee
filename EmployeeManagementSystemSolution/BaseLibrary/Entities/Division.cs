using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BaseLibrary.Entities
{
    public class Division
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }=string.Empty;
        [JsonIgnore]

        public List<Department>? Departments { get; set; }
    }
}
