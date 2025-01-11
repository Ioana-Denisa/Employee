using System.ComponentModel.DataAnnotations;


namespace BaseLibrary.Entities
{
    public class EquipmentTypes
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public List<Equipment>? Equipments { get; set; }
    }
}
