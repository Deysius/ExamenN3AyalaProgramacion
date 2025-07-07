using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ExamenN3AyalaProgramacion.Interfaces;
using ExamenN3AyalaProgramacion.Models;

namespace ExamenN3AyalaProgramacion.Models
{
    public class ClienteViewModel : INotifyPropertyChanged
    {
        private IClienteInterface servicio;

        public Cliente Cliente { get; set; } = new Cliente();
        public ICommand GuardarCommand { get; }

        public ClienteViewModel(IClienteInterface servicio)
        {
            this.servicio = servicio;
            this.servicio.Init();
            GuardarCommand = new Command(async () => await GuardarClienteAsync());
            servicio.InicializarBaseDeDatosAsync();
        }

        private async Task GuardarClienteAsync()
        {
            if (!servicio.EsAntiguedadValida(Cliente.AntiguedadMeses))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Antigüedad > 1500 días", "OK");
                return;
            }

            await servicio.AgregarClienteAsync(Cliente);
            await servicio.AgregarLogAsync(Cliente.Nombre);
            await Application.Current.MainPage.DisplayAlert("Éxito", "Cliente registrado", "OK");

            Cliente = new Cliente();
            OnPropertyChanged(nameof(Cliente));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}

