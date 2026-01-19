using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Models.Api
{
    public class FlavorTextEntry
    {
        public string Flavor_Text { get; set; }
        public NamedApiResource Language { get; set; }
        public NamedApiResource Version { get; set; }
    }
}
