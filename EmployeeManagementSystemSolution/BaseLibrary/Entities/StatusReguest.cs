

using System.ComponentModel.DataAnnotations;

namespace BaseLibrary.Entities
{
    public class StatusReguest
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
