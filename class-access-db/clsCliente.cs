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

            //  Cuando usas DataSource, el DataGridView automáticamente:
            //  Lee la estructura de la tabla
            //  Crea las columnas basándose en esa estructura
            //  Llena los datos
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

        public void ListarDeudores(DataGridView grilla)
        {
            if (grilla.Columns.Count == 0)
            {
                grilla.Columns.Add("ID", "ID Cliente");
                grilla.Columns.Add("Nombre", "Nombre");
                grilla.Columns.Add("Deuda", "Deuda");
            }

            try
            {
                conexion.ConnectionString = cadenaConexion;
                conexion.Open();

                comando.Connection = conexion;
                comando.CommandType = CommandType.TableDirect;
                comando.CommandText = tabla;

                OleDbDataReader DR = comando.ExecuteReader();
                grilla.Rows.Clear();

                while (DR.Read())
                {
                    grilla.Rows.Add(DR.GetInt32(0), DR.GetString(1), DR.GetDecimal(2));
                }

                DR.Close();
                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al cargar los datos: " + e.Message);
            }
        }
    }
}
