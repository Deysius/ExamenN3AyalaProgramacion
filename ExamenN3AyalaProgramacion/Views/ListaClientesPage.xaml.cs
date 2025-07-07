using ExamenN3AyalaProgramacion.Interfaces;

namespace ExamenN3AyalaProgramacion.Views;

public partial class ListaClientesPage : ContentPage
{
    private readonly IClienteInterface servicio;

    public ListaClientesPage(IClienteInterface servicio)
    {
        InitializeComponent();
        this.servicio = servicio;
    }

    protected override async void OnAppearing()
    {
        await servicio.InicializarBaseDeDatosAsync();
        ClientesList.ItemsSource = await servicio.ObtenerClientesAsync();
    }
}