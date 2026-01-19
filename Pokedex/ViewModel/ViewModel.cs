using CommunityToolkit.Mvvm.ComponentModel;

namespace Pokedex.ViewModels;

public partial class BaseViewModel : ObservableObject
{
    [ObservableProperty]
    private bool isBusy;

    [ObservableProperty]
    private string title;
}