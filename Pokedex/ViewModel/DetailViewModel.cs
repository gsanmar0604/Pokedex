using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Pokedex.Models;
using Pokedex.Services;

namespace Pokedex.ViewModels;

[QueryProperty(nameof(PokemonId), nameof(PokemonId))]
public partial class DetailViewModel : BaseViewModel
{
    private readonly IPokeApiService _pokeApiService;

    [ObservableProperty]
    private Pokemon pokemon;

    [ObservableProperty]
    private int pokemonId;

    public DetailViewModel(IPokeApiService pokeApiService)
    {
        _pokeApiService = pokeApiService;
        Title = "Detalle Pokémon";
    }

    partial void OnPokemonIdChanged(int value)
    {
        if (value > 0)
        {
            LoadPokemonDetailsCommand.Execute(null);
        }
    }

    [RelayCommand]
    private async Task LoadPokemonDetailsAsync()
    {
        if (IsBusy) return;

        try
        {
            IsBusy = true;
            Pokemon = await _pokeApiService.GetPokemonByIdAsync(PokemonId);
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Error", $"Error al cargar detalles: {ex.Message}", "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }
}