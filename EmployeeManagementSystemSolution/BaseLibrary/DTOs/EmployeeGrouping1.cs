using System.ComponentModel.DataAnnotations;

namespace BaseLibrary.DTOs
{
    public class EmployeeGrouping1
    {
        [Required]
        public string Fullname { get; set; } = string.Empty;
        [Required]
        public string PhoneNumber { get; set; } = string.Empty;
        [Required]
        public DateTime? HireDate { get; set; }
        [Required]
        public string Address { get; set; } = string.Empty;

    }
}
