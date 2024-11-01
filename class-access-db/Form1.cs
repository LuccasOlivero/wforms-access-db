﻿using class_access_db.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace class_access_db
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void listadoDeTodosLosClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormListadoClientes formClientes = new FormListadoClientes();
            formClientes.ShowDialog();  
        }

        private void listadoDeClientesDeudoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormClientesDeudores formClientesDeudores = new FormClientesDeudores();
            formClientesDeudores.ShowDialog();
        }
    }
}
