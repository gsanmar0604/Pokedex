using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Pokedex.Models.Api
{
    public class PokemonSprites
    {
        [JsonPropertyName("front_default")]
        public string? Front_Default { get; set; }
        [JsonPropertyName("front_shiny")]
        public string? Front_Shiny { get; set; }
        [JsonPropertyName("back_default")]
        public string? Back_Default { get; set; }
        public PokemonSpritesOther? Other { get; set; }
    }
}
