using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace ExamenN3AyalaProgramacion.Models
{
    [Table("clientes")]
    public class Cliente
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(250), Unique]
        public string Nombre { get; set; }

        [MaxLength(250)]
        public string Empresa { get; set; }

        public int AntiguedadMeses { get; set; }

        public bool Activo { get; set; }
    }
}
