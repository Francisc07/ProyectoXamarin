using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace login.Model
{
    [Table("Clientes")]
    class Clientes
    {
        [PrimaryKey, AutoIncrement]
        public int IdCli { get; set; }
        [MaxLength(100), Unique]
        public String NomCli { get; set; }
        [MaxLength(100), Unique]
        public String TelCli { get; set; }
        public String EmailCli { get; set; }
    }
}