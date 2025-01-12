﻿

using System.ComponentModel.DataAnnotations;

namespace BaseLibrary.Entities
{
    public class Department
    {
        public int ID {  get; set; }
        [Required]
        public string Name { get; set; }=string.Empty;
        public int GeneralDepartmentID {  get; set; }
        public GeneralDepartment? GeneralDepartment { get; set; }
        public List<Specialization>? Specializations { get; set; }

    }
}
