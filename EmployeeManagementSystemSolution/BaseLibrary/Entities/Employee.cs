

using System.ComponentModel.DataAnnotations;

namespace BaseLibrary.Entities
{
    public class Employee
    {
        public int ID {  get; set; }
        [Required]
        public string Fullname {  get; set; }=string.Empty;
        [Required, DataType(DataType.PhoneNumber)]
        public string PhoneNumber {  get; set; } = string.Empty;
        [Required]
        public DateTime? HireDate { get; set; }
        [Required]
        public string Address {  get; set; }= string.Empty;
        public int SpecializationID {  get; set; }
        public int UserID {  get; set; }
        public int TownID {  get; set; }

        public Specialization? Specialization { get; set; }
        public User? User { get; set; }
        public Town? Town { get; set; }
    }
}
