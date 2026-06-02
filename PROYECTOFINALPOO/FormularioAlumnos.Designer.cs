namespace PROYECTOFINALPOO
{
    partial class FormularioAlumnos
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
            this.btnAlumnos = new System.Windows.Forms.Button();
            this.btnAsistencia = new System.Windows.Forms.Button();
            this.btnNotas = new System.Windows.Forms.Button();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAlumnos
            // 
            this.btnAlumnos.BackColor = System.Drawing.Color.Orange;
            this.btnAlumnos.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAlumnos.Location = new System.Drawing.Point(50, 386);
            this.btnAlumnos.Name = "btnAlumnos";
            this.btnAlumnos.Size = new System.Drawing.Size(112, 32);
            this.btnAlumnos.TabIndex = 0;
            this.btnAlumnos.Text = "Alumnos";
            this.btnAlumnos.UseVisualStyleBackColor = false;
            this.btnAlumnos.Click += new System.EventHandler(this.btnAlumnos_Click);
            // 
            // btnAsistencia
            // 
            this.btnAsistencia.BackColor = System.Drawing.Color.Orange;
            this.btnAsistencia.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAsistencia.Location = new System.Drawing.Point(361, 386);
            this.btnAsistencia.Name = "btnAsistencia";
            this.btnAsistencia.Size = new System.Drawing.Size(99, 32);
            this.btnAsistencia.TabIndex = 1;
            this.btnAsistencia.Text = "Asistencia";
            this.btnAsistencia.UseVisualStyleBackColor = false;
            this.btnAsistencia.Click += new System.EventHandler(this.btnAsistencia_Click);
            // 
            // btnNotas
            // 
            this.btnNotas.BackColor = System.Drawing.Color.Orange;
            this.btnNotas.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnNotas.Location = new System.Drawing.Point(625, 386);
            this.btnNotas.Name = "btnNotas";
            this.btnNotas.Size = new System.Drawing.Size(139, 32);
            this.btnNotas.TabIndex = 2;
            this.btnNotas.Text = "Notas";
            this.btnNotas.UseVisualStyleBackColor = false;
            this.btnNotas.Click += new System.EventHandler(this.btnNotas_Click);
            // 
            // btnRegresar
            // 
            this.btnRegresar.BackColor = System.Drawing.Color.DimGray;
            this.btnRegresar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegresar.Font = new System.Drawing.Font("Segoe UI Semilight", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegresar.ForeColor = System.Drawing.Color.White;
            this.btnRegresar.Location = new System.Drawing.Point(664, 12);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(124, 30);
            this.btnRegresar.TabIndex = 76;
            this.btnRegresar.Text = "⬅ Regresar";
            this.btnRegresar.UseVisualStyleBackColor = false;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // FormularioAlumnos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PROYECTOFINALPOO.Properties.Resources.logo_fun;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnRegresar);
            this.Controls.Add(this.btnNotas);
            this.Controls.Add(this.btnAsistencia);
            this.Controls.Add(this.btnAlumnos);
            this.Name = "FormularioAlumnos";
            this.Text = "FormularioAlumnos";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAlumnos;
        private System.Windows.Forms.Button btnAsistencia;
        private System.Windows.Forms.Button btnNotas;
        private System.Windows.Forms.Button btnRegresar;
    }
}