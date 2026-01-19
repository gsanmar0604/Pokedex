using Pokedex.Models;
using Pokedex.Models.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Pokedex.Services
{
    public class PokeApiService : IPokeApiService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonOptions;

        public PokeApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://pokeapi.co/api/v2/");

            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        public async Task<List<Pokemon>> GetPokemonsAsync(int limit = 20, int offset = 0)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<PokemonListResponse>(
                    $"pokemon?limit={limit}&offset={offset}",
                    _jsonOptions);

                if (response?.Results == null)
                    return new List<Pokemon>();

                var tasks = response.Results.Select(async item =>
                {
                    var id = ExtractIdFromUrl(item.Url);
                    return await GetPokemonByIdAsync(id);
                });

                var pokemons = await Task.WhenAll(tasks);
                return pokemons.Where(p => p != null).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener pokémons: {ex.Message}");
                return new List<Pokemon>();
            }
        }

        public async Task<Pokemon> GetPokemonByIdAsync(int id)
        {
            try
            {
                var detailResponse = await _httpClient.GetFromJsonAsync<PokemonDetailResponse>(
                    $"pokemon/{id}",
                    _jsonOptions);

                if (detailResponse == null)
                    return null;

                var pokemon = MapToPokemon(detailResponse);

                try
                {
                    var speciesResponse = await _httpClient.GetFromJsonAsync<PokemonSpeciesResponse>(
                        $"pokemon-species/{id}",
                        _jsonOptions);

                    if (speciesResponse != null)
                    {
                        pokemon.Description = GetSpanishDescription(speciesResponse);
                        pokemon.Category = GetSpanishCategory(speciesResponse);
                        pokemon.Color = speciesResponse.Color?.Name ?? "unknown";
                    }
                }
                catch
                { }

                return pokemon;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener pokémon {id}: {ex.Message}");
                return null;
            }
        }

        public async Task<Pokemon> GetPokemonByNameAsync(string name)
        {
            try
            {
                var detailResponse = await _httpClient.GetFromJsonAsync<PokemonDetailResponse>(
                    $"pokemon/{name.ToLower()}",
                    _jsonOptions);

                if (detailResponse == null)
                    return null;

                return MapToPokemon(detailResponse);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener pokémon {name}: {ex.Message}");
                return null;
            }
        }

        private Pokemon MapToPokemon(PokemonDetailResponse detail)
        {
            return new Pokemon
            {
                Id = detail.Id,
                Name = detail.Name,
                DisplayName = CapitalizeFirstLetter(detail.Name),
                Height = detail.Height,
                Weight = detail.Weight,
                BaseExperience = detail.Base_Experience,
                Types = detail.Types?
                    .OrderBy(t => t.Slot)
                    .Select(t => CapitalizeFirstLetter(t.Type.Name))
                    .ToList() ?? new List<string>(),
                Abilities = detail.Abilities?
                    .Select(a => CapitalizeFirstLetter(a.Ability.Name.Replace("-", " ")))
                    .ToList() ?? new List<string>(),
                Stats = detail.Stats?.ToDictionary(
                    s => s.Stat.Name,
                    s => s.Base_Stat) ?? new Dictionary<string, int>(),
                ImageUrl = detail.Sprites?.Front_Default,
                OfficialArtwork = detail.Sprites?.Other?.Official_Artwork?.Front_Default
            };
        }

        private string GetSpanishDescription(PokemonSpeciesResponse species)
        {
            var spanishEntry = species.Flavor_Text_Entries?
                .FirstOrDefault(f => f.Language.Name == "es");

            if (spanishEntry != null)
            {
                return spanishEntry.Flavor_Text.Replace("\n", " ").Replace("\f", " ");
            }

            var englishEntry = species.Flavor_Text_Entries?
                .FirstOrDefault(f => f.Language.Name == "en");

            return englishEntry?.Flavor_Text.Replace("\n", " ").Replace("\f", " ") ?? "";
        }

        private string GetSpanishCategory(PokemonSpeciesResponse species)
        {
            var spanishGenus = species.Genera?
                .FirstOrDefault(g => g.Language.Name == "es");

            return spanishGenus?.Genus_Text ?? "";
        }

        private int ExtractIdFromUrl(string url)
        {
            var segments = url.TrimEnd('/').Split('/');
            return int.Parse(segments[^1]);
        }

        private string CapitalizeFirstLetter(string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            return char.ToUpper(text[0]) + text.Substring(1);
        }
    }
}
