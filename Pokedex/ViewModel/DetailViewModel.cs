using CommunityToolkit.Mvvm.ComponentModel;
using Pokedex.Models;

namespace Pokedex.ViewModels;

[QueryProperty(nameof(Pokemon), "Pokemon")]
public partial class DetailViewModel : BaseViewModel
{
    [ObservableProperty]
    private Pokemon pokemon;

    public DetailViewModel()
    {
        Title = "Detalle Pokémon";
    }
}