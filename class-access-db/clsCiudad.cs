using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data; // para trabajar con db
using System.Data.OleDb; // para realizar la conexion hacia la db
using System.Windows.Forms; // para usar windows forms
using System.IO;
using System.Drawing.Text; // para poder leer, escribir, flujos de datos, con archivos

namespace class_access_db
{
    internal class clsCiudad
    {
        private OleDbConnection conexion = new OleDbConnection();
        private OleDbCommand comando = new OleDbCommand();
        private OleDbDataAdapter adaptador = new OleDbDataAdapter();

        private string cadenaDeConexion = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = Clientes.mdb";
        private string tabla = "Ciudad";

        public void Listar(ComboBox Combo)
        {
            try
            {
                conexion.ConnectionString = cadenaDeConexion;
                conexion.Open();

                comando.Connection = conexion;
                comando.CommandText = tabla;
                comando.CommandType = CommandType.TableDirect;

                adaptador = new OleDbDataAdapter(comando);
                DataSet DS = new DataSet();
                adaptador.Fill(DS, tabla);

                Combo.DataSource = DS.Tables[tabla];
                Combo.DisplayMember = "nombre";
                Combo.ValueMember = "idCiudad";

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            } finally
            {
                conexion.Close();
            }
        }

        public string Buscar (Int32 idCiudad)
        {
            try
            {
                conexion.ConnectionString = cadenaDeConexion;
                conexion.Open();

                comando.Connection = conexion;
                comando.CommandType = CommandType.TableDirect;
                comando.CommandText = tabla;

                OleDbDataReader DR = comando.ExecuteReader();

                string res = "";

                if (DR.HasRows)
                {
                    while (DR.Read())
                    {
                        if(DR.GetInt32(0) == idCiudad)
                        {
                            res = DR.GetString(1);
                        }
                    }
                }

                DR.Close();
                conexion.Close();
                return res;
            }
            catch (Exception e)
            {
                return(e.ToString());
            }
            finally
            {
                conexion.Close();
            }
        }
    }
}
