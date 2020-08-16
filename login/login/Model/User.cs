using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace login.Model
{
    [Table ("user")]
    class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(100), Unique]
        public String Usuario { get; set; }
        public String Password { get; set; }
        public String ConfirmarPassword { get; set; }
    }
}
