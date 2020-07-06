namespace Micelli.Martin._2D.SegundoParcialLaboratorio2
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblDocentes = new System.Windows.Forms.Label();
            this.dgvTablaDocentes = new System.Windows.Forms.DataGridView();
            this.lblAulas = new System.Windows.Forms.Label();
            this.dgvTablaAulas = new System.Windows.Forms.DataGridView();
            this.dgvTablaAlumnos = new System.Windows.Forms.DataGridView();
            this.lblAlumnos = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTablaDocentes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTablaAulas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTablaAlumnos)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDocentes
            // 
            this.lblDocentes.AutoSize = true;
            this.lblDocentes.Location = new System.Drawing.Point(12, 256);
            this.lblDocentes.Name = "lblDocentes";
            this.lblDocentes.Size = new System.Drawing.Size(59, 15);
            this.lblDocentes.TabIndex = 3;
            this.lblDocentes.Text = "Docentes";
            // 
            // dgvTablaDocentes
            // 
            this.dgvTablaDocentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTablaDocentes.Location = new System.Drawing.Point(12, 274);
            this.dgvTablaDocentes.Name = "dgvTablaDocentes";
            this.dgvTablaDocentes.Size = new System.Drawing.Size(771, 199);
            this.dgvTablaDocentes.TabIndex = 4;
            // 
            // lblAulas
            // 
            this.lblAulas.AutoSize = true;
            this.lblAulas.Location = new System.Drawing.Point(12, 498);
            this.lblAulas.Name = "lblAulas";
            this.lblAulas.Size = new System.Drawing.Size(37, 15);
            this.lblAulas.TabIndex = 6;
            this.lblAulas.Text = "Aulas";
            // 
            // dgvTablaAulas
            // 
            this.dgvTablaAulas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTablaAulas.Location = new System.Drawing.Point(12, 516);
            this.dgvTablaAulas.Name = "dgvTablaAulas";
            this.dgvTablaAulas.Size = new System.Drawing.Size(771, 159);
            this.dgvTablaAulas.TabIndex = 7;
            // 
            // dgvTablaAlumnos
            // 
            this.dgvTablaAlumnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTablaAlumnos.Location = new System.Drawing.Point(12, 29);
            this.dgvTablaAlumnos.Name = "dgvTablaAlumnos";
            this.dgvTablaAlumnos.Size = new System.Drawing.Size(771, 198);
            this.dgvTablaAlumnos.TabIndex = 9;
            // 
            // lblAlumnos
            // 
            this.lblAlumnos.AutoSize = true;
            this.lblAlumnos.Location = new System.Drawing.Point(12, 9);
            this.lblAlumnos.Name = "lblAlumnos";
            this.lblAlumnos.Size = new System.Drawing.Size(55, 15);
            this.lblAlumnos.TabIndex = 10;
            this.lblAlumnos.Text = "Alumnos";
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PeachPuff;
            this.ClientSize = new System.Drawing.Size(799, 687);
            this.Controls.Add(this.lblAlumnos);
            this.Controls.Add(this.dgvTablaAlumnos);
            this.Controls.Add(this.dgvTablaAulas);
            this.Controls.Add(this.lblAulas);
            this.Controls.Add(this.dgvTablaDocentes);
            this.Controls.Add(this.lblDocentes);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(100, 100);
            this.MaximizeBox = false;
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Jardin de infantes \"Los pichoncitos\"";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmPrincipal_FormClosed);
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTablaDocentes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTablaAulas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTablaAlumnos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblDocentes;
        private System.Windows.Forms.DataGridView dgvTablaDocentes;
        private System.Windows.Forms.Label lblAulas;
        private System.Windows.Forms.DataGridView dgvTablaAulas;
        private System.Windows.Forms.DataGridView dgvTablaAlumnos;
        private System.Windows.Forms.Label lblAlumnos;
    }
}

