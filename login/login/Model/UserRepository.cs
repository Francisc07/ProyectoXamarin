using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;

namespace login.Model
{
    class UserRepository
    {
        private SQLiteConnection con;
        private static UserRepository instancia;
        public static UserRepository Instancia
        {
            get
            {
                if (instancia == null)
                    throw new Exception("Debe llamar al inicializador, acción detenida");
                return instancia;
            }
        }
        public static void Inicializador(String filename)
        {
            if (filename == null)
            {
                throw new ArgumentException();
            }
            if (instancia != null)
            {
                instancia.con.Close();
            }
            instancia = new UserRepository(filename);
        }
        private UserRepository(String dbPath)
        {
            con = new SQLiteConnection(dbPath);
            con.CreateTable<User>();
        }

        public string EstadoMensaje;
        public int AddNewUser(string Usuario, string Password, string ConfirmarPassword)
        {
            int result = 0;
            try
            {
                result = con.Insert(new User
                {
                    Usuario = Usuario,
                    Password = Password,
                    ConfirmarPassword = ConfirmarPassword
                });
                EstadoMensaje = string.Format("Cantidad filas : {0}", result);
            }
            catch (Exception e)
            { EstadoMensaje = e.Message; }
            return result;
        }
        public IEnumerable<User> GetAllUsers()
        {
            try
            {
                return con.Table<User>();
            }
            catch (Exception e)
            {
                EstadoMensaje = e.Message;
            }
            return Enumerable.Empty<User>();
        }
    }
}
