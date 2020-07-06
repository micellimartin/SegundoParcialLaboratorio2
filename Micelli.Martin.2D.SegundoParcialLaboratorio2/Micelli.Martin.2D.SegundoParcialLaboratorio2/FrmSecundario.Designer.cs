namespace Micelli.Martin._2D.SegundoParcialLaboratorio2
{
    partial class FrmSecundario
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
            this.lblAlumnos = new System.Windows.Forms.Label();
            this.lblEvaluaciones = new System.Windows.Forms.Label();
            this.dgvTablaEvaluaciones = new System.Windows.Forms.DataGridView();
            this.btnComenzarEvaluacion = new System.Windows.Forms.Button();
            this.txtAlumnoEnEvaluacion = new System.Windows.Forms.TextBox();
            this.lblAlumnoEnEvaluacion = new System.Windows.Forms.Label();
            this.lblDocenteEvaluando = new System.Windows.Forms.Label();
            this.txtDocenteEvaluando = new System.Windows.Forms.TextBox();
            this.lblProximoAlumno = new System.Windows.Forms.Label();
            this.txtProximoAlumno = new System.Windows.Forms.TextBox();
            this.lstboxAlumnos = new System.Windows.Forms.ListBox();
            this.lblEvaluacionEnProceso = new System.Windows.Forms.Label();
            this.lblTiempoTranscurrido = new System.Windows.Forms.Label();
            this.lblRecreoEnProceso = new System.Windows.Forms.Label();
            this.lblNoHayRecreo = new System.Windows.Forms.Label();
            this.gbEstadoRecreo = new System.Windows.Forms.GroupBox();
            this.lblTiempoEnEvaluacion = new System.Windows.Forms.Label();
            this.gbEstadoTiempo = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTablaEvaluaciones)).BeginInit();
            this.gbEstadoRecreo.SuspendLayout();
            this.gbEstadoTiempo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblAlumnos
            // 
            this.lblAlumnos.AutoSize = true;
            this.lblAlumnos.Location = new System.Drawing.Point(12, 256);
            this.lblAlumnos.Name = "lblAlumnos";
            this.lblAlumnos.Size = new System.Drawing.Size(202, 15);
            this.lblAlumnos.TabIndex = 4;
            this.lblAlumnos.Text = "Alumnos en espera a ser evaluados";
            // 
            // lblEvaluaciones
            // 
            this.lblEvaluaciones.AutoSize = true;
            this.lblEvaluaciones.Location = new System.Drawing.Point(12, 499);
            this.lblEvaluaciones.Name = "lblEvaluaciones";
            this.lblEvaluaciones.Size = new System.Drawing.Size(80, 15);
            this.lblEvaluaciones.TabIndex = 10;
            this.lblEvaluaciones.Text = "Evaluaciones";
            // 
            // dgvTablaEvaluaciones
            // 
            this.dgvTablaEvaluaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTablaEvaluaciones.Location = new System.Drawing.Point(12, 517);
            this.dgvTablaEvaluaciones.Name = "dgvTablaEvaluaciones";
            this.dgvTablaEvaluaciones.Size = new System.Drawing.Size(771, 159);
            this.dgvTablaEvaluaciones.TabIndex = 11;
            // 
            // btnComenzarEvaluacion
            // 
            this.btnComenzarEvaluacion.Location = new System.Drawing.Point(12, 12);
            this.btnComenzarEvaluacion.Name = "btnComenzarEvaluacion";
            this.btnComenzarEvaluacion.Size = new System.Drawing.Size(196, 59);
            this.btnComenzarEvaluacion.TabIndex = 13;
            this.btnComenzarEvaluacion.Text = "Comenzar evaluacion";
            this.btnComenzarEvaluacion.UseVisualStyleBackColor = true;
            this.btnComenzarEvaluacion.Click += new System.EventHandler(this.btnComenzarEvaluacion_Click);
            // 
            // txtAlumnoEnEvaluacion
            // 
            this.txtAlumnoEnEvaluacion.Enabled = false;
            this.txtAlumnoEnEvaluacion.Location = new System.Drawing.Point(12, 200);
            this.txtAlumnoEnEvaluacion.Name = "txtAlumnoEnEvaluacion";
            this.txtAlumnoEnEvaluacion.Size = new System.Drawing.Size(196, 21);
            this.txtAlumnoEnEvaluacion.TabIndex = 14;
            // 
            // lblAlumnoEnEvaluacion
            // 
            this.lblAlumnoEnEvaluacion.AutoSize = true;
            this.lblAlumnoEnEvaluacion.Location = new System.Drawing.Point(12, 182);
            this.lblAlumnoEnEvaluacion.Name = "lblAlumnoEnEvaluacion";
            this.lblAlumnoEnEvaluacion.Size = new System.Drawing.Size(128, 15);
            this.lblAlumnoEnEvaluacion.TabIndex = 15;
            this.lblAlumnoEnEvaluacion.Text = "Alumno en evaluacion";
            // 
            // lblDocenteEvaluando
            // 
            this.lblDocenteEvaluando.AutoSize = true;
            this.lblDocenteEvaluando.Location = new System.Drawing.Point(289, 182);
            this.lblDocenteEvaluando.Name = "lblDocenteEvaluando";
            this.lblDocenteEvaluando.Size = new System.Drawing.Size(113, 15);
            this.lblDocenteEvaluando.TabIndex = 16;
            this.lblDocenteEvaluando.Text = "Docente evaluando";
            // 
            // txtDocenteEvaluando
            // 
            this.txtDocenteEvaluando.Enabled = false;
            this.txtDocenteEvaluando.Location = new System.Drawing.Point(292, 200);
            this.txtDocenteEvaluando.Name = "txtDocenteEvaluando";
            this.txtDocenteEvaluando.Size = new System.Drawing.Size(196, 21);
            this.txtDocenteEvaluando.TabIndex = 17;
            // 
            // lblProximoAlumno
            // 
            this.lblProximoAlumno.AutoSize = true;
            this.lblProximoAlumno.Location = new System.Drawing.Point(12, 95);
            this.lblProximoAlumno.Name = "lblProximoAlumno";
            this.lblProximoAlumno.Size = new System.Drawing.Size(151, 15);
            this.lblProximoAlumno.TabIndex = 18;
            this.lblProximoAlumno.Text = "Proximo alumno a evaluar";
            // 
            // txtProximoAlumno
            // 
            this.txtProximoAlumno.Enabled = false;
            this.txtProximoAlumno.Location = new System.Drawing.Point(12, 113);
            this.txtProximoAlumno.Name = "txtProximoAlumno";
            this.txtProximoAlumno.Size = new System.Drawing.Size(196, 21);
            this.txtProximoAlumno.TabIndex = 19;
            // 
            // lstboxAlumnos
            // 
            this.lstboxAlumnos.FormattingEnabled = true;
            this.lstboxAlumnos.ItemHeight = 15;
            this.lstboxAlumnos.Location = new System.Drawing.Point(12, 274);
            this.lstboxAlumnos.Name = "lstboxAlumnos";
            this.lstboxAlumnos.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lstboxAlumnos.Size = new System.Drawing.Size(768, 199);
            this.lstboxAlumnos.TabIndex = 20;
            // 
            // lblEvaluacionEnProceso
            // 
            this.lblEvaluacionEnProceso.AutoSize = true;
            this.lblEvaluacionEnProceso.Location = new System.Drawing.Point(643, 206);
            this.lblEvaluacionEnProceso.Name = "lblEvaluacionEnProceso";
            this.lblEvaluacionEnProceso.Size = new System.Drawing.Size(140, 15);
            this.lblEvaluacionEnProceso.TabIndex = 21;
            this.lblEvaluacionEnProceso.Text = "Evaluacion en proceso...";
            this.lblEvaluacionEnProceso.Visible = false;
            // 
            // lblTiempoTranscurrido
            // 
            this.lblTiempoTranscurrido.AutoSize = true;
            this.lblTiempoTranscurrido.Location = new System.Drawing.Point(6, 69);
            this.lblTiempoTranscurrido.Name = "lblTiempoTranscurrido";
            this.lblTiempoTranscurrido.Size = new System.Drawing.Size(117, 15);
            this.lblTiempoTranscurrido.TabIndex = 23;
            this.lblTiempoTranscurrido.Text = "Tiempo transcurrido";
            this.lblTiempoTranscurrido.Visible = false;
            // 
            // lblRecreoEnProceso
            // 
            this.lblRecreoEnProceso.AutoSize = true;
            this.lblRecreoEnProceso.Location = new System.Drawing.Point(6, 69);
            this.lblRecreoEnProceso.Name = "lblRecreoEnProceso";
            this.lblRecreoEnProceso.Size = new System.Drawing.Size(120, 15);
            this.lblRecreoEnProceso.TabIndex = 25;
            this.lblRecreoEnProceso.Text = "Recreo en proceso...";
            this.lblRecreoEnProceso.Visible = false;
            // 
            // lblNoHayRecreo
            // 
            this.lblNoHayRecreo.AutoSize = true;
            this.lblNoHayRecreo.Location = new System.Drawing.Point(6, 22);
            this.lblNoHayRecreo.Name = "lblNoHayRecreo";
            this.lblNoHayRecreo.Size = new System.Drawing.Size(120, 15);
            this.lblNoHayRecreo.TabIndex = 26;
            this.lblNoHayRecreo.Text = "No se esta en recreo";
            this.lblNoHayRecreo.Visible = false;
            // 
            // gbEstadoRecreo
            // 
            this.gbEstadoRecreo.BackColor = System.Drawing.Color.Orange;
            this.gbEstadoRecreo.Controls.Add(this.lblNoHayRecreo);
            this.gbEstadoRecreo.Controls.Add(this.lblRecreoEnProceso);
            this.gbEstadoRecreo.Location = new System.Drawing.Point(584, 12);
            this.gbEstadoRecreo.Name = "gbEstadoRecreo";
            this.gbEstadoRecreo.Size = new System.Drawing.Size(196, 100);
            this.gbEstadoRecreo.TabIndex = 27;
            this.gbEstadoRecreo.TabStop = false;
            // 
            // lblTiempoEnEvaluacion
            // 
            this.lblTiempoEnEvaluacion.AutoSize = true;
            this.lblTiempoEnEvaluacion.Location = new System.Drawing.Point(6, 22);
            this.lblTiempoEnEvaluacion.Name = "lblTiempoEnEvaluacion";
            this.lblTiempoEnEvaluacion.Size = new System.Drawing.Size(134, 15);
            this.lblTiempoEnEvaluacion.TabIndex = 28;
            this.lblTiempoEnEvaluacion.Text = "Tiempo en evaluacion :";
            // 
            // gbEstadoTiempo
            // 
            this.gbEstadoTiempo.BackColor = System.Drawing.Color.Orange;
            this.gbEstadoTiempo.Controls.Add(this.lblTiempoEnEvaluacion);
            this.gbEstadoTiempo.Controls.Add(this.lblTiempoTranscurrido);
            this.gbEstadoTiempo.Location = new System.Drawing.Point(292, 12);
            this.gbEstadoTiempo.Name = "gbEstadoTiempo";
            this.gbEstadoTiempo.Size = new System.Drawing.Size(196, 100);
            this.gbEstadoTiempo.TabIndex = 29;
            this.gbEstadoTiempo.TabStop = false;
            // 
            // FrmSecundario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PeachPuff;
            this.ClientSize = new System.Drawing.Size(800, 688);
            this.Controls.Add(this.gbEstadoTiempo);
            this.Controls.Add(this.gbEstadoRecreo);
            this.Controls.Add(this.lblEvaluacionEnProceso);
            this.Controls.Add(this.lstboxAlumnos);
            this.Controls.Add(this.txtProximoAlumno);
            this.Controls.Add(this.lblProximoAlumno);
            this.Controls.Add(this.txtDocenteEvaluando);
            this.Controls.Add(this.lblDocenteEvaluando);
            this.Controls.Add(this.lblAlumnoEnEvaluacion);
            this.Controls.Add(this.txtAlumnoEnEvaluacion);
            this.Controls.Add(this.btnComenzarEvaluacion);
            this.Controls.Add(this.dgvTablaEvaluaciones);
            this.Controls.Add(this.lblEvaluaciones);
            this.Controls.Add(this.lblAlumnos);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(1000, 100);
            this.MaximizeBox = false;
            this.Name = "FrmSecundario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Mesa de evaluacion";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmSecundario_FormClosed);
            this.Load += new System.EventHandler(this.FrmSecundario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTablaEvaluaciones)).EndInit();
            this.gbEstadoRecreo.ResumeLayout(false);
            this.gbEstadoRecreo.PerformLayout();
            this.gbEstadoTiempo.ResumeLayout(false);
            this.gbEstadoTiempo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAlumnos;
        private System.Windows.Forms.Label lblEvaluaciones;
        private System.Windows.Forms.DataGridView dgvTablaEvaluaciones;
        private System.Windows.Forms.Button btnComenzarEvaluacion;
        private System.Windows.Forms.TextBox txtAlumnoEnEvaluacion;
        private System.Windows.Forms.Label lblAlumnoEnEvaluacion;
        private System.Windows.Forms.Label lblDocenteEvaluando;
        private System.Windows.Forms.TextBox txtDocenteEvaluando;
        private System.Windows.Forms.Label lblProximoAlumno;
        private System.Windows.Forms.TextBox txtProximoAlumno;
        private System.Windows.Forms.ListBox lstboxAlumnos;
        private System.Windows.Forms.Label lblEvaluacionEnProceso;
        private System.Windows.Forms.Label lblTiempoTranscurrido;
        private System.Windows.Forms.Label lblRecreoEnProceso;
        private System.Windows.Forms.Label lblNoHayRecreo;
        private System.Windows.Forms.GroupBox gbEstadoRecreo;
        private System.Windows.Forms.Label lblTiempoEnEvaluacion;
        private System.Windows.Forms.GroupBox gbEstadoTiempo;
    }
}