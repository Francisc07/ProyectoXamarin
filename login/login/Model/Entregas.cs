using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace login.Model
{
    [Table("Entregas")]
    class Entregas
    {
        [PrimaryKey, AutoIncrement]
        public int IdEntre { get; set; }
        [MaxLength(100), Unique]
        public DateTime FechaEntre { get; set; }
        [MaxLength(100), Unique]
        public String ClientEntre { get; set; }
        public String EmailCliEntre { get; set; }
    }
}
