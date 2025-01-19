
using System.ComponentModel.DataAnnotations;

namespace BaseLibrary.Entities
{
    public class Town
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public int CityID { get; set; }
        public List<Employee>? Employees { get; set; }
        public County? City { get; set; }
    }
}
