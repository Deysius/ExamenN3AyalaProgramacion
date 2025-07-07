using System.Diagnostics;
using ExamenN3AyalaProgramacion.Interfaces;

namespace ExamenN3AyalaProgramacion.Views;

public partial class LogPage : ContentPage
{
    private readonly IClienteInterface servicio;

    public LogPage(IClienteInterface servicio)
    {
        InitializeComponent();
        this.servicio = servicio;
    }

    protected override async void OnAppearing()
    {
        LogList.ItemsSource = await servicio.ObtenerLogsAsync();
    }
}