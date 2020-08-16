using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace login.Model
{
    class BitacoraRepository
    {
        private SQLiteConnection con;
        private static BitacoraRepository instancia;
        public static BitacoraRepository Instancia
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
            instancia = new BitacoraRepository(filename);
        }
        private BitacoraRepository(String dbPath)
        {
            con = new SQLiteConnection(dbPath);
            con.CreateTable<Bitacora>();
        }

        public string EstadoMensaje;
        public int AddBit(string ClientEntre, string FechaEntre, float Monto)
        {
            int result = 0;
            try
            {
                result = con.Insert(new Bitacora
                {
                    ClientEntre = ClientEntre,
                    FechaEntre = FechaEntre,
                    Monto = Monto
                });
                EstadoMensaje = string.Format("Cantidad filas : {0}", result);
            }
            catch (Exception e)
            { EstadoMensaje = e.Message; }
            return result;
        }
        public IEnumerable<Bitacora> GetBit()
        {
            try
            {
                return con.Table<Bitacora>();
            }
            catch (Exception e)
            {
                EstadoMensaje = e.Message;
            }
            return Enumerable.Empty<Bitacora>();
        }
    }
}

