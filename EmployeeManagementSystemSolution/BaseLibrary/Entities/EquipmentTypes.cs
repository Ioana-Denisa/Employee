using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace BaseLibrary.Entities
{
    public class EquipmentTypes
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [JsonIgnore]

        public List<Equipment>? Equipments { get; set; }
    }
}
