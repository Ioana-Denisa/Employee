

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BaseLibrary.Entities
{
    public class Department
    {
        public int ID {  get; set; }
        [Required]
        public string Name { get; set; }=string.Empty;
        public int DivisionID {  get; set; }
        public Division? Division { get; set; }
        [JsonIgnore]

        public List<Specialization>? Specializations { get; set; }

    }
}
