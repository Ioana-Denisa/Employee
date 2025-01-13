

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BaseLibrary.Entities
{
    public class Specialization
    {
        public int ID {  get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public int DepartmentID {  get; set; }

        public Department? Department { get; set; }
        [JsonIgnore]

        public List<Employee>? Employees { get; set; }
        [JsonIgnore]
        public List<Equipment>? Equipments { get; set; }
    }
}
