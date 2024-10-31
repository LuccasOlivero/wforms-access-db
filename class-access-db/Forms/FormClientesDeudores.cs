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
    public partial class FormClientesDeudores : Form
    {
        public FormClientesDeudores()
        {
            InitializeComponent();
        }

        private void btnListarDeudores_Click(object sender, EventArgs e)
        {
            clsCliente objClientesDeudores = new clsCliente();
            objClientesDeudores.ListarDeudores(GrillaDeudores);
        }
    }
}
