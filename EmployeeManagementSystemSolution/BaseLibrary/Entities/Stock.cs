

using System.Text.Json.Serialization;

namespace BaseLibrary.Entities
{
    public class Stock
    {
        public int ID { get; set; }
        public int EquipmentID { get; set; }
        public int TotalQuantity { get; set; }
        public int MinRequired { get; set; }

        [JsonIgnore]
        public List<Equipment>? Equipments { get; set; }
    }
}
