using Pokedex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Services
{
    public interface IPokeApiService
    {
        Task<List<Pokemon>> GetPokemonsAsync(int limit = 20, int offset = 0);
        Task<Pokemon> GetPokemonByIdAsync(int id);
        Task<Pokemon> GetPokemonByNameAsync(string name);
    }
}
