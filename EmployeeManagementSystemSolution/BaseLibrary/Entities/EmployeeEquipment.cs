

namespace BaseLibrary.Entities
{
    public class EmployeeEquipment
    {
        public int ID {  get; set; }
        public int UserID {  get; set; }
        public int EquipmentID {  get; set; }
        public int Quantity {  get; set; }

        public Equipment Equipment { get; set; }

    }
}
