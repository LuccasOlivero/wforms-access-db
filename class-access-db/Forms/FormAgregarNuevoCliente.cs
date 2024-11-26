using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace class_access_db.Forms
{
    public partial class FormAgregarNuevoCliente : Form
    {
        public FormAgregarNuevoCliente()
        {
            InitializeComponent();
        }

        private void FormAgregarNuevoCliente_Load(object sender, EventArgs e)
        {
            clsCiudad objCiudad = new clsCiudad();
            objCiudad.Listar(cmbCiudad);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clsCliente objCliente = new clsCliente();
            objCliente.Nombre = textBox1.Text.ToString();
            objCliente.Limite = Convert.ToInt32(textBox2.Text);
            objCliente.idCiudad = Convert.ToInt32(cmbCiudad.SelectedValue);
            objCliente.Llenar();
            MessageBox.Show("Listo");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clsCliente objCliente = new clsCliente();
            objCliente.AgregarNuevoRegistro();
            MessageBox.Show("Listo");
        }
    }
}
