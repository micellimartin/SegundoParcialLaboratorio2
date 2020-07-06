using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace Micelli.Martin._2D.SegundoParcialLaboratorio2
{
    public partial class FrmPrincipal : Form
    {
        List<Docente> listadoDocentes;
        List<Alumno> listadoAlumnos;
        List<Aula> listadoAulas;

        FrmSecundario mesaEvaluacion;

        public FrmPrincipal()
        {
            InitializeComponent();

            this.listadoDocentes = new List<Docente>();
            this.listadoAlumnos = new List<Alumno>();
            this.listadoAulas = new List<Aula>();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            DeserializarInsertarDocentes();
            CargarDocentes();         
            CargarAlumnos();
            CargarAulas();
            
            ConfigurarTablas();

            this.mesaEvaluacion = new FrmSecundario(listadoDocentes, listadoAlumnos, listadoAulas);
            mesaEvaluacion.Show();
        }

        #region Metodos auxiliares

        /// <summary>
        /// Deserializa la lista de docentes del archivo Xml y luego inserta los docentes en la base de datos SOLO la primera vez que se corre el programa
        /// </summary>
        private void DeserializarInsertarDocentes()
        {
            ArchivoXml<Alumno> serializador = new ArchivoXml<Alumno>();
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\SegundoParcialUtn\\JardinUtn\\Docentes\\Docentes.xml";

            try
            {
                List<Docente> auxDocentes = serializador.LeerLista(path);
                JardinSql.InsertarDocentes(auxDocentes);
            }
            catch (Exception excepcion)
            {
                //Se registra la informacion de la excepcion en un archivo txt
                ArchivoTxt.GuardarEnLog("Ocurrio el siguiente error: " + excepcion.Message);
                MessageBox.Show(excepcion.Message, "Error");
            }           
        }

        /// <summary>
        /// Obtieine los docentes de la base de datos y los guarda en una lista
        /// </summary>
        private void CargarDocentes()
        {
            try
            {
                JardinSql.ObtenerDocentes(this.listadoDocentes);
            }
            catch (Exception excepcion)
            {
                //Se registra la informacion de la excepcion en un archivo txt
                ArchivoTxt.GuardarEnLog("Ocurrio el siguiente error: " + excepcion.Message);
                MessageBox.Show(excepcion.Message, "Error");
            }

            this.dgvTablaDocentes.DataSource = this.listadoDocentes;
        }

        /// <summary>
        /// Obtiene los alumnos desde la base de datos y los guarda en una lista
        /// </summary>
        private void CargarAlumnos()
        {
            try
            {
                JardinSql.ObtenerAlumnos(this.listadoAlumnos);
            }
            catch (Exception excepcion)
            {
                //Se registra la informacion de la excepcion en un archivo txt
                ArchivoTxt.GuardarEnLog("Ocurrio el siguiente error: " + excepcion.Message);
                MessageBox.Show(excepcion.Message, "Error");
            }

            this.dgvTablaAlumnos.DataSource = this.listadoAlumnos;
        }

        /// <summary>
        /// Obtiene las aulas desde la base de datos y las guarda en una lista
        /// </summary>
        private void CargarAulas()
        {
            try
            {
                JardinSql.ObtenerAluas(this.listadoAulas);
            }
            catch (Exception excepcion)
            {
                //Se registra la informacion de la excepcion en un archivo txt
                ArchivoTxt.GuardarEnLog("Ocurrio el siguiente error: " + excepcion.Message);
                MessageBox.Show(excepcion.Message, "Error");
            }

            this.dgvTablaAulas.DataSource = this.listadoAulas;
        }

        /// <summary>
        /// Configura las tablas de alumnos, docentes y aulas
        /// </summary>
        private void ConfigurarTablas()
        {
            dgvTablaDocentes.ReadOnly = true;
            dgvTablaDocentes.RowHeadersVisible = false;
            dgvTablaDocentes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTablaDocentes.AllowUserToAddRows = false;
            

            dgvTablaAulas.ReadOnly = true;
            dgvTablaAulas.RowHeadersVisible = false;
            dgvTablaAulas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTablaAulas.AllowUserToAddRows = false;
            

            dgvTablaAlumnos.ReadOnly = true;
            dgvTablaAlumnos.RowHeadersVisible = false;
            dgvTablaAlumnos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTablaAlumnos.AllowUserToAddRows = false;
            
        }

        #endregion

        private void FrmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(this.mesaEvaluacion.Hilo1.IsAlive)
            {
                mesaEvaluacion.Hilo1.Abort();
            }

            if (this.mesaEvaluacion.Hilo2.IsAlive)
            {
                mesaEvaluacion.Hilo2.Abort();
            }

            if (this.mesaEvaluacion.Hilo3.IsAlive)
            {
                mesaEvaluacion.Hilo3.Abort();
            }
        }
    }
}
