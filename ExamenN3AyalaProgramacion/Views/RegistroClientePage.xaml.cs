using ExamenN3AyalaProgramacion.Interfaces;
using ExamenN3AyalaProgramacion.ViewModels;

namespace ExamenN3AyalaProgramacion.Views;

public partial class RegistroClientePage : ContentPage
{
    public RegistroClientePage(IClienteInterface clienteService)
    {
        InitializeComponent();
        BindingContext = new ClienteViewModel(clienteService);
    }
}