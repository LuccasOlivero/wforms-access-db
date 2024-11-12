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
    public partial class FormBuscarCliente : Form
    {
        public FormBuscarCliente()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Int32 idCliente = Convert.ToInt32(textBox1.Text);

            clsCliente objCliente = new clsCliente();
            objCliente.BuscarCliente(idCliente);
            if(objCliente.idCliente != 0)
            {
                textBox2.Text = objCliente.Nombre;
                textBox3.Text = objCliente.Deuda.ToString();
                textBox4.Text = objCliente.Limite.ToString();

            } else
            {
                MessageBox.Show("no encontrado");
            }
        }
    }
}
