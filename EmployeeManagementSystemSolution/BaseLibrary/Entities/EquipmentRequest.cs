
namespace BaseLibrary.Entities
{
    public class EquipmentRequest
    {
        public int ID {  get; set; }
        public int UserID {  get; set; }
        public int EquipmentID {  get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime ResponseDate { get; set; }
        public int Quantity {  get; set; }
        public StatusReguest Status {  get; set; }



        public User user { get; set; }
        public Equipment equipment { get; set; }
    }
}
