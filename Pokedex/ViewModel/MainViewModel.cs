using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using Pokedex.Models;
using Pokedex.Services;

namespace Pokedex.ViewModels;

public partial class MainViewModel : BaseViewModel
{
    private readonly IPokeApiService _pokeApiService;

    [ObservableProperty]
    private ObservableCollection<Pokemon> pokemons;

    [ObservableProperty]
    private Pokemon selectedPokemon;

    [ObservableProperty]
    private bool isRefreshing;

    public MainViewModel(IPokeApiService pokeApiService)
    {
        _pokeApiService = pokeApiService;
        Title = "Pokédex";
        Pokemons = new ObservableCollection<Pokemon>();
    }

    [RelayCommand]
    private async Task LoadPokemonsAsync()
    {
        if (IsBusy) return;

        try
        {
            IsBusy = true;
            var pokemons = await _pokeApiService.GetPokemonsAsync(50, 0);

            Pokemons.Clear();
            foreach (var pokemon in pokemons)
            {
                Pokemons.Add(pokemon);
            }
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Error", $"Error al cargar Pokémon: {ex.Message}", "OK");
        }
        finally
        {
            IsBusy = false;
            IsRefreshing = false;
        }
    }

    [RelayCommand]
    private async Task GoToDetailAsync(Pokemon pokemon)
    {
        if (pokemon == null) return;

        await Shell.Current.GoToAsync($"detail", true,
            new Dictionary<string, object>
            {
                { "Pokemon", pokemon }
            });
    }

    [RelayCommand]
    private async Task RefreshAsync()
    {
        IsRefreshing = true;
        await LoadPokemonsAsync();
    }
}