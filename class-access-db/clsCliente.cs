using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// importaciones necesarias para la base de datos
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using System.IO;


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

        private decimal deuda = 0;
        private int cantidad = 0;  
        public Decimal TotalDeuda
        {
            get { return deuda; }
        }

        public Int32 CantDeudores
        {
            get { return cantidad; }
        }

        public decimal PromedioDeuda
        {
            get { return deuda / cantidad; }
        }

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


            if (DR.HasRows)
            {
                while (DR.Read())
                {
                    if (DR.GetDecimal(2) > 0)
                    {
                        grilla.Rows.Add(
                        DR.GetInt32(0), // idCliente
                        DR.GetString(1), // nombre
                        DR.GetDecimal(2)); // deuda

                        cantidad++;
                        deuda = deuda + DR.GetDecimal(2); ;
                    }
                }
            }

                DR.Close();
                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al cargar los datos: " + e.Message);
            }
        }

        public void ReporteClientes() 
        {
            try
            {

                conexion.ConnectionString = cadenaConexion;
                conexion.Open();

                comando.CommandText = tabla;
                comando.CommandType = CommandType.TableDirect;
                comando.Connection = conexion;

                OleDbDataReader DR = comando.ExecuteReader();

                StreamWriter AD = new StreamWriter("Reportes clientes.txt", false);
                AD.WriteLine("Listado clientes\n");
                AD.WriteLine("Codigo;Clientes;Deuda\n");

                if (DR.HasRows)
                {
                    while (DR.Read())
                    {
                        AD.Write(DR.GetInt32(0));
                        AD.Write(";");
                        AD.Write(DR.GetString(1));
                        AD.Write(";");
                        AD.WriteLine(DR.GetDecimal(2));

                        cantidad++;
                        deuda = deuda + DR.GetDecimal(2);
                    }

                    AD.Write("Cantidad de clientes: ;");
                    AD.WriteLine(cantidad);
                    AD.Write("Deuda de los clientes: ;");
                    AD.WriteLine(deuda.ToString("0,00"));
                }

                MessageBox.Show("reporte generado!");
                AD.Close();
                conexion.Close();
            } catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

        }
    }
}
