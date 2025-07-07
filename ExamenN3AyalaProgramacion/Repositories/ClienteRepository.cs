using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using ExamenN3AyalaProgramacion.Models;
using ExamenN3AyalaProgramacion.Interfaces;

namespace ExamenN3AyalaProgramacion.Repositories
{
    public class ClienteRepository : IClienteInterface
    {
        private SQLiteAsyncConnection db;
        private readonly string logFile = Path.Combine(FileSystem.AppDataDirectory, "Logs_Ayala.txt");

        public void Init()
        {
            
        }

        public async Task InicializarBaseDeDatosAsync()
        {
            if (db != null) return;
            var path = Path.Combine(FileSystem.AppDataDirectory, "clientes.db");
            db = new SQLiteAsyncConnection(path);
            await db.CreateTableAsync<Cliente>();
        }

        public async Task<List<Cliente>> ObtenerClientesAsync()
        {
            return await db.Table<Cliente>().ToListAsync();
        }

        public async Task AgregarClienteAsync(Cliente cliente)
        {
            await db.InsertAsync(cliente);
        }

        public async Task EliminarTodosLosClientesAsync()
        {
            await db.DeleteAllAsync<Cliente>();
        }

        public bool EsAntiguedadValida(int antiguedadMeses)
        {
            return antiguedadMeses * 10 <= 1500;
        }

        public async Task AgregarLogAsync(string nombreCliente)
        {
            string log = $"Se incluyó el registro [{nombreCliente}] el {DateTime.Now:dd/MM/yyyy HH:mm}";
            await File.AppendAllLinesAsync(logFile, new[] { log });
        }

        public async Task<List<string>> ObtenerLogsAsync()
        {
            if (!File.Exists(logFile)) return new List<string>();
            return (await File.ReadAllLinesAsync(logFile)).ToList();
        }

        public Task EliminarLogsAsync()
        {
            if (File.Exists(logFile)) File.Delete(logFile);
            return Task.CompletedTask;
        }
    }
}
