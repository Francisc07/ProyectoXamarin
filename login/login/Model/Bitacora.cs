using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace login.Model
{
    [Table("bitacora")]
    class Bitacora
    {
        [PrimaryKey, AutoIncrement]
        public int IdEntre { get; set; }
        public String FechaEntre { get; set; }
        public String ClientEntre { get; set; }
        public float Monto { get; set; }
    }
}
