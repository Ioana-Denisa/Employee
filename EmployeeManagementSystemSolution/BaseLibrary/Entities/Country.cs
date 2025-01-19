

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BaseLibrary.Entities
{
    public class Country
    {
        public int ID {  get; set; }
        [Required]
        public string Name { get; set; }=string.Empty;
        [JsonIgnore]

        public List<County>? Counties { get; set; }
    }   
}
