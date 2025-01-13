

using System.ComponentModel.DataAnnotations;

namespace BaseLibrary.Entities
{
    public class Equipment
    {
        public int ID {  get; set; }
        [Required]
        public string Name { get; set; }=string.Empty;
        public int Quantity {  get; set; }
        public int Size {  get; set; }
        public int SpecializationID {  get; set; }
        public Specialization? Specialization { get; set; }
    }
}
