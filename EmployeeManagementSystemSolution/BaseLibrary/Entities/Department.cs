

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BaseLibrary.Entities
{
    public class Department
    {
        public int ID {  get; set; }
        [Required]
        public string Name { get; set; }=string.Empty;
        public int GeneralDepartmentID {  get; set; }
        public Division? GeneralDepartment { get; set; }
        [JsonIgnore]

        public List<Specialization>? Specializations { get; set; }

    }
}
