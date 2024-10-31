using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// importaciones necesarias para la base de datos
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;


namespace class_access_db
{
    internal class clsCliente
    {
        // creaciones necesarias para la base de datos
        private OleDbConnection conexion = new OleDbConnection();
        private OleDbCommand comando = new OleDbCommand();
        private OleDbDataAdapter adaptador = new OleDbDataAdapter();

        private string cadenaConexion = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source = Clientes.mdb";
        private string tabla = "Cliente";

        public void Listar(DataGridView Grilla)
        {
            try
            {
            conexion.ConnectionString = cadenaConexion;
            conexion.Open();

            comando.Connection = conexion;
            comando.CommandType = CommandType.TableDirect;
            comando.CommandText = tabla;

            adaptador = new OleDbDataAdapter(comando);
            DataSet DS = new DataSet();
            adaptador.Fill(DS);

            Grilla.DataSource = DS.Tables[0];

            conexion.Close();
            } catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            };
        }
    }
}
