using Newtonsoft.Json;

namespace Core.Entities
{
    public class SchoolAddress
    {
        [JsonProperty("address_line_1")]
        public string LineOne { get; set; }

        [JsonProperty("address_line_2")]
        public string LineTwo { get; set; }

        [JsonProperty("address_town")]
        public string Town { get; set; }

        [JsonProperty("address_postcode")]
        public string Postcode { get; set; }

        [JsonProperty("address_country")]
        public SchoolCountry Country { get; set; }

        public class SchoolCountry
        {
            [JsonProperty("code")]
            public string Code { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }
        }
    }
}