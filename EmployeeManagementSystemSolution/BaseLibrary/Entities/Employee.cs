

namespace BaseLibrary.Entities
{
    public class Employee
    {
        public int ID {  get; set; }
        public string? Fullname {  get; set; }
        public string? PhoneNumber {  get; set; }
        public DateTime? HireDate { get; set; }
        public int DepartmentID {  get; set; }
        public int SpecializationID {  get; set; }
        public int UserID {  get; set; }


        public Department department { get; set; }
        public Specialization specialization { get; set; }
        public User user { get; set; }
    }
}
