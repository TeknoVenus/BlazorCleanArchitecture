using Newtonsoft.Json;

namespace Core.Entities
{
    public class School
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("establishment_number")]
        public string EstablishmentNumber { get; set; }

        [JsonProperty("phase_of_education")]
        public string EducationLevel { get; set; }

        [JsonProperty("address")]
        public SchoolAddress Address { get; set; }
    }
}