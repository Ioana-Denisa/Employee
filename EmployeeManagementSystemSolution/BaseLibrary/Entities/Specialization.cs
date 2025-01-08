

namespace BaseLibrary.Entities
{
    public class Specialization
    {
        public int ID {  get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int EquipmentID {  get; set; }


        public Equipment equipment { get; set; }
    }
}
