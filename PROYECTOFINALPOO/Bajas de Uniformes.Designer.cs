namespace PROYECTOFINALPOO
{
    partial class Bajas_de_Uniformes
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
            this.cmbTallaB = new System.Windows.Forms.ComboBox();
            this.npCantidadB = new System.Windows.Forms.NumericUpDown();
            this.cmbTipoB = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnEnviarB = new System.Windows.Forms.Button();
            this.btnEliminarB = new System.Windows.Forms.Button();
            this.btnEditarB = new System.Windows.Forms.Button();
            this.btnIngresarB = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNomEncargadoB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.npCantidadB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbTallaB
            // 
            this.cmbTallaB.FormattingEnabled = true;
            this.cmbTallaB.Items.AddRange(new object[] {
            "XS",
            "S",
            "M",
            "L",
            "XL",
            "XXL"});
            this.cmbTallaB.Location = new System.Drawing.Point(204, 195);
            this.cmbTallaB.Name = "cmbTallaB";
            this.cmbTallaB.Size = new System.Drawing.Size(121, 21);
            this.cmbTallaB.TabIndex = 37;
            // 
            // npCantidadB
            // 
            this.npCantidadB.Location = new System.Drawing.Point(205, 128);
            this.npCantidadB.Name = "npCantidadB";
            this.npCantidadB.Size = new System.Drawing.Size(120, 20);
            this.npCantidadB.TabIndex = 36;
            // 
            // cmbTipoB
            // 
            this.cmbTipoB.FormattingEnabled = true;
            this.cmbTipoB.Items.AddRange(new object[] {
            "Hoddie Beige 001",
            "Hoddie Blue  001"});
            this.cmbTipoB.Location = new System.Drawing.Point(204, 163);
            this.cmbTipoB.Name = "cmbTipoB";
            this.cmbTipoB.Size = new System.Drawing.Size(121, 21);
            this.cmbTipoB.TabIndex = 35;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(65, 163);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 34;
            this.label7.Text = "Tipo Sueter";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.dataGridView1.Location = new System.Drawing.Point(493, 128);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(240, 150);
            this.dataGridView1.TabIndex = 29;
            // 
            // btnEnviarB
            // 
            this.btnEnviarB.Location = new System.Drawing.Point(683, 400);
            this.btnEnviarB.Name = "btnEnviarB";
            this.btnEnviarB.Size = new System.Drawing.Size(75, 23);
            this.btnEnviarB.TabIndex = 28;
            this.btnEnviarB.Text = "Enviar";
            this.btnEnviarB.UseVisualStyleBackColor = true;
            // 
            // btnEliminarB
            // 
            this.btnEliminarB.Location = new System.Drawing.Point(518, 400);
            this.btnEliminarB.Name = "btnEliminarB";
            this.btnEliminarB.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarB.TabIndex = 27;
            this.btnEliminarB.Text = "Eliminar";
            this.btnEliminarB.UseVisualStyleBackColor = true;
            // 
            // btnEditarB
            // 
            this.btnEditarB.Location = new System.Drawing.Point(683, 344);
            this.btnEditarB.Name = "btnEditarB";
            this.btnEditarB.Size = new System.Drawing.Size(75, 23);
            this.btnEditarB.TabIndex = 26;
            this.btnEditarB.Text = "Editar";
            this.btnEditarB.UseVisualStyleBackColor = true;
            // 
            // btnIngresarB
            // 
            this.btnIngresarB.Location = new System.Drawing.Point(518, 344);
            this.btnIngresarB.Name = "btnIngresarB";
            this.btnIngresarB.Size = new System.Drawing.Size(75, 23);
            this.btnIngresarB.TabIndex = 25;
            this.btnIngresarB.Text = "Ingresar";
            this.btnIngresarB.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(79, 203);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Talla";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(58, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Cantidad Sueteres";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = " Nombre encargado baja";
            // 
            // txtNomEncargadoB
            // 
            this.txtNomEncargadoB.Location = new System.Drawing.Point(204, 82);
            this.txtNomEncargadoB.Name = "txtNomEncargadoB";
            this.txtNomEncargadoB.Size = new System.Drawing.Size(122, 20);
            this.txtNomEncargadoB.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(352, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "INGRESO DE UNIFORMES";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(65, 237);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 38;
            this.label5.Text = "Motivo de Baja";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Código";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Tipo Suéter";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Talla";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Stock Actual";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Última Fecha";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Estado";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Dañado",
            "",
            "Perdido",
            "",
            "Robado",
            "",
            "Defecto de fábrica",
            "",
            "Otro"});
            this.comboBox1.Location = new System.Drawing.Point(205, 237);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 39;
            // 
            // Bajas_de_Uniformes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbTallaB);
            this.Controls.Add(this.npCantidadB);
            this.Controls.Add(this.cmbTipoB);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnEnviarB);
            this.Controls.Add(this.btnEliminarB);
            this.Controls.Add(this.btnEditarB);
            this.Controls.Add(this.btnIngresarB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNomEncargadoB);
            this.Controls.Add(this.label1);
            this.Name = "Bajas_de_Uniformes";
            this.Text = "Bajas_de_Uniformes";
            ((System.ComponentModel.ISupportInitialize)(this.npCantidadB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbTallaB;
        private System.Windows.Forms.NumericUpDown npCantidadB;
        private System.Windows.Forms.ComboBox cmbTipoB;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnEnviarB;
        private System.Windows.Forms.Button btnEliminarB;
        private System.Windows.Forms.Button btnEditarB;
        private System.Windows.Forms.Button btnIngresarB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNomEncargadoB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}