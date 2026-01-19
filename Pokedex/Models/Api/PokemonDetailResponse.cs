using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Models.Api
{
    public class PokemonDetailResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public int Base_Experience { get; set; }
        public List<PokemonType> Types { get; set; }
        public List<PokemonAbility> Abilities { get; set; }
        public List<PokemonStat> Stats { get; set; }
        public PokemonSprites Sprites { get; set; }
        public PokemonSpecies Species { get; set; }
    }
}
