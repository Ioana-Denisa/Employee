﻿

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BaseLibrary.Entities
{
    public class Specialization
    {
        public int ID {  get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public int EquipmentID {  get; set; }
        public int DepartmentID {  get; set; }

        public Department? Department { get; set; }
        public Equipment? Equipment { get; set; }
        [JsonIgnore]

        public List<Employee>? Employees { get; set; }
    }
}
