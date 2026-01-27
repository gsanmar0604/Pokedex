using Pokedex.Views;

namespace Pokedex
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("detail", typeof(DetailPage));
        }

    }
}
