

using System.Text.Json.Serialization;

namespace BaseLibrary.Entities
{
    public class City
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public int CountryID {  get; set; }

        public Country? Country { get; set; }
        [JsonIgnore]
        public List<Town>?  Towns { get; set; }
    }
}
