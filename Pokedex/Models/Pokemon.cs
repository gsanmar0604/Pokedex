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
        public string Name { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
        public int Height { get; set; }
        public int Weight { get; set; }
        public int BaseExperience { get; set; }
        public List<string> Types { get; set; } = [];
        public List<string> Abilities { get; set; } = [];
        public Dictionary<string, int> Stats { get; set; } = [];
        public required string ImageUrl { get; set; }
        public required string OfficialArtwork { get; set; }
        public required string Description { get; set; }
        public required string Category { get; set; }
        public required string Color { get; set; }
        public string FormattedHeight => $"{Height / 10.0:F1} m";
        public string FormattedWeight => $"{Weight / 10.0:F1} kg";
        public string TypesDisplay => string.Join(", ", Types);
    }
}
