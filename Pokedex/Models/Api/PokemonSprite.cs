using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Models.Api
{
    public class PokemonSprites
    {
        public string Front_Default { get; set; }
        public string Front_Shiny { get; set; }
        public string Back_Default { get; set; }
        public PokemonSpritesOther Other { get; set; }
    }
}
