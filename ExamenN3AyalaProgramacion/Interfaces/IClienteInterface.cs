using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamenN3AyalaProgramacion.Models;
using SQLite;

namespace ExamenN3AyalaProgramacion.Interfaces
{
    public interface IClienteInterface
    {
        public void Init();
        public Task InicializarBaseDeDatosAsync();
        public Task AgregarClienteAsync(ExamenN3AyalaProgramacion.Models.Cliente cliente);
        public Task<List<ExamenN3AyalaProgramacion.Models.Cliente>> ObtenerClientesAsync();
        public bool EsAntiguedadValida(int antiguedadMeses);
        public Task AgregarLogAsync(string nombreCliente);
        public Task<List<string>> ObtenerLogsAsync();
        public Task EliminarTodosLosClientesAsync();
        public Task EliminarLogsAsync();
    }
}

