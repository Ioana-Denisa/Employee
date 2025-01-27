
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BaseLibrary.Entities
{
    public class Town
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public int CountyID { get; set; }
        [JsonIgnore]
        public List<Employee>? Employees { get; set; }
        public County? County { get; set; }
    }
}
