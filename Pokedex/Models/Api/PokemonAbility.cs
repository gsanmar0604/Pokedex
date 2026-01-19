using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Models.Api
{
    public class PokemonAbility
    {
        public bool Is_Hidden { get; set; }
        public int Slot { get; set; }
        public NamedApiResource? Ability { get; set; }
    }
}
