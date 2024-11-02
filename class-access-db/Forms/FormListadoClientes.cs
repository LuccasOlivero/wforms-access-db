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
    public partial class FormListadoClientes : Form
    {
        public FormListadoClientes()
        {
            InitializeComponent();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            clsCliente objCliente = new clsCliente();
            objCliente.Listar(Grilla);
        }

        private void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            clsCliente objCliente = new clsCliente();
            objCliente.ReporteClientes();
        }
    }
}
