using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Models.Api
{
    public class PokemonType
    {
        public int Slot { get; set; }
        public NamedApiResource Type { get; set; }
    }
}
