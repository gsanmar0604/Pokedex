using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Models
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public int BaseExperience { get; set; }
        public List<string> Types { get; set; }
        public List<string> Abilities { get; set; }
        public Dictionary<string, int> Stats { get; set; }
        public string ImageUrl { get; set; }
        public string OfficialArtwork { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Color { get; set; }
        public string FormattedHeight => $"{Height / 10.0:F1} m";
        public string FormattedWeight => $"{Weight / 10.0:F1} kg";
        public string TypesDisplay => string.Join(", ", Types);
    }
}
