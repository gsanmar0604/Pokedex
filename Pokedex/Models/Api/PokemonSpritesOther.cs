using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Pokedex.Models.Api
{
    public class PokemonSpritesOther
    {
        [JsonPropertyName("official-artwork")]
        public OfficialArtwork? Official_Artwork { get; set; }
    }
}
