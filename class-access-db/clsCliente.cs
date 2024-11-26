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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.ComponentModel;


namespace class_access_db
{
    internal class clsCliente
    {
        // creaciones necesarias para la base de datos
        private OleDbConnection conexion = new OleDbConnection();
        private OleDbCommand comando = new OleDbCommand();
        private OleDbDataAdapter adaptador = new OleDbDataAdapter();

        private string cadenaConexion = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source = Clientes.mdb";
        public string tabla = "Cliente";

        private decimal deudaTotal = 0;
        private int cantidad = 0;

        private Int32 idCli;
        private string nombre;
        private decimal deuda;
        private Int32 limite;
        private Int32 idCiu;

        public Int32 idCliente
        {
            get { return idCli; }
            set { idCli = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public Int32 Limite
        {
            get { return limite; }
            set { limite = value; }
        }
        public decimal Deuda
        {
            get { return deuda; }
            set { deuda = value; }
        }

        public Int32 idCiudad
        {
            get { return idCiu; }
            set { idCiu = value; }
        }
        public Decimal TotalDeuda
        { 
            get { return deudaTotal; }
        }

        public Int32 CantDeudores
        {
            get { return cantidad; }
        }

        public decimal PromedioDeuda
        {
            get { return deudaTotal / cantidad; }
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

        public void BuscarCliente ( Int32 idParaBuscar) 
        {
            try
            {
                conexion.ConnectionString = cadenaConexion;
                conexion.Open();

                comando.Connection = conexion;
                comando.CommandType = CommandType.TableDirect;
                comando.CommandText = tabla;

                OleDbDataReader DR = comando.ExecuteReader();

                idCli = 0;

                if( DR.HasRows )
                {
                    while (DR.Read())
                    {
                        if(DR.GetInt32(0) == idParaBuscar)
                        {
                            idCli = DR.GetInt32(0);
                            nombre = DR.GetString(1);
                            deuda = DR.GetDecimal(2);
                            idCiu = DR.GetInt32(3);
                            limite = DR.GetInt32(4);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());  
            } finally
            {
                conexion.Close();
            }
        }

        public void Llenar()
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
                adaptador.Fill(DS, tabla);
                DataTable tablaToFill = DS.Tables[tabla];
                DataRow fila = tablaToFill.NewRow();

                fila["nombre"] = nombre;
                fila["deuda"] = deuda;
                fila["limite"] = limite;
                fila["idCiudad"] = idCiu;

                tablaToFill.Rows.Add(fila);

                OleDbCommandBuilder ConciliaCambios = new OleDbCommandBuilder(adaptador);

                adaptador.Update(DS, tabla);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            } finally
            {
                conexion.Close();
            }
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
                            deudaTotal = deudaTotal + DR.GetDecimal(2); ;
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
                        deudaTotal = deudaTotal + DR.GetDecimal(2);
                    }

                    AD.Write("Cantidad de clientes: ;");
                    AD.WriteLine(cantidad);
                    AD.Write("Deuda de los clientes: ;");
                    AD.WriteLine(deudaTotal.ToString("0,00"));
                }

                MessageBox.Show("reporte generado!");
                AD.Close();
                conexion.Close();
            } catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

        }

        public void ModificarCliente (Int32 idCliente)
        {
            try
            {
                String sql = "";
                sql = "UPDATE Cliente SET Limite = ";
                sql = sql + limite.ToString();
                sql = sql + " WHERE IdCliente = ";
                sql = sql + idCliente.ToString();
                conexion.ConnectionString = cadenaConexion;
                conexion.Open();
                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = sql;
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                conexion.Close();
            }
        }

        public void Eliminar(Int32 idCliente)
        {
            try
            {
                String sql = "";
                sql = "DELETE FROM Cliente WHERE idCliente = " + idCliente.ToString();

                conexion.ConnectionString = cadenaConexion;
                conexion.Open();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = sql;

                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                conexion.Close();
            }
        }

        public void AgregarNuevoRegistro()
        {
            try
            {
                String sql = "";
                sql = "INSERT INTO Cliente (Nombre, Deuda, IdCiudad, Limite)";
                sql = sql + "VALUES ('" + nombre + "',0," + limite.ToString() + "," + idCiu.ToString() + ") ";

                conexion.ConnectionString = cadenaConexion;
                conexion.Open();
                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = sql;
                comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
    }
}
