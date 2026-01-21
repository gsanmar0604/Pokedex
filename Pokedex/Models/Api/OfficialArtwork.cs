using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Pokedex.Models.Api
{
    public class OfficialArtwork
    {
        [JsonPropertyName("front_default")]
        public string? Front_Default { get; set; }
        [JsonPropertyName("front_shiny")]
        public string? Front_Shiny { get; set; }
    }
}
