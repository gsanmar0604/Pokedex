using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Models.Api
{
    public class PokemonSpeciesResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<FlavorTextEntry> Flavor_Text_Entries { get; set; }
        public PokemonColor Color { get; set; }
        public List<Genus> Genera { get; set; }
    }
}
