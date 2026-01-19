using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Models.Api
{
    public class PokemonStat
    {
        public int Base_Stat { get; set; }
        public int Effort { get; set; }
        public NamedApiResource Stat { get; set; }
    }
}
