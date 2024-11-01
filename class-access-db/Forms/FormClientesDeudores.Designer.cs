namespace class_access_db.Forms
{
    partial class FormClientesDeudores
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnListarDeudores = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxPromedio = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxCantDeudores = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxDeudores = new System.Windows.Forms.TextBox();
            this.GrillaDeudores = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaDeudores)).BeginInit();
            this.SuspendLayout();
            // 
            // btnListarDeudores
            // 
            this.btnListarDeudores.Location = new System.Drawing.Point(332, 311);
            this.btnListarDeudores.Name = "btnListarDeudores";
            this.btnListarDeudores.Size = new System.Drawing.Size(155, 33);
            this.btnListarDeudores.TabIndex = 20;
            this.btnListarDeudores.Text = "Listar";
            this.btnListarDeudores.UseVisualStyleBackColor = true;
            this.btnListarDeudores.Click += new System.EventHandler(this.btnListarDeudores_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(278, 274);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Promedio de deuda";
            // 
            // textBoxPromedio
            // 
            this.textBoxPromedio.Enabled = false;
            this.textBoxPromedio.Location = new System.Drawing.Point(387, 271);
            this.textBoxPromedio.Name = "textBoxPromedio";
            this.textBoxPromedio.Size = new System.Drawing.Size(100, 20);
            this.textBoxPromedio.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(278, 248);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Cantidad de clientes";
            // 
            // textBoxCantDeudores
            // 
            this.textBoxCantDeudores.Enabled = false;
            this.textBoxCantDeudores.Location = new System.Drawing.Point(387, 245);
            this.textBoxCantDeudores.Name = "textBoxCantDeudores";
            this.textBoxCantDeudores.Size = new System.Drawing.Size(100, 20);
            this.textBoxCantDeudores.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(278, 222);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Total de deuda";
            // 
            // textBoxDeudores
            // 
            this.textBoxDeudores.Enabled = false;
            this.textBoxDeudores.Location = new System.Drawing.Point(387, 219);
            this.textBoxDeudores.Name = "textBoxDeudores";
            this.textBoxDeudores.Size = new System.Drawing.Size(100, 20);
            this.textBoxDeudores.TabIndex = 13;
            // 
            // GrillaDeudores
            // 
            this.GrillaDeudores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrillaDeudores.Location = new System.Drawing.Point(12, 42);
            this.GrillaDeudores.Name = "GrillaDeudores";
            this.GrillaDeudores.Size = new System.Drawing.Size(475, 150);
            this.GrillaDeudores.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Consulta de datos";
            // 
            // FormClientesDeudores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 352);
            this.Controls.Add(this.btnListarDeudores);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxPromedio);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxCantDeudores);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxDeudores);
            this.Controls.Add(this.GrillaDeudores);
            this.Controls.Add(this.label1);
            this.Name = "FormClientesDeudores";
            this.Text = "FormClientesDeudores";
            ((System.ComponentModel.ISupportInitialize)(this.GrillaDeudores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnListarDeudores;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxPromedio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxCantDeudores;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxDeudores;
        private System.Windows.Forms.DataGridView GrillaDeudores;
        private System.Windows.Forms.Label label1;
    }
}