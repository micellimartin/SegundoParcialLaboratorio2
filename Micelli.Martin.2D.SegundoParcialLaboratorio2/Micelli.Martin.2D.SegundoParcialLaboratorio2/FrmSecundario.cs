using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Entidades;

namespace Micelli.Martin._2D.SegundoParcialLaboratorio2
{
    public partial class FrmSecundario : Form
    {
        delegate void EvaluacionConcluidaEventHandler(Evaluacion e);
        event EvaluacionConcluidaEventHandler EvaluacionConcluida; 

        List<Docente> listadoDocentes;
        List<Alumno> listadoAlumnos;
        List<Aula> listadoAulas;
        List<Evaluacion> listadoEvaluaciones;

        Thread hilo1;
        Thread hilo2;
        Thread hilo3;

        Random aleatorio1;
        Random aleatorio2;
        Random aleatorio3;

        Alumno proximoAlumno;

        #region Propiedades

        public Thread Hilo1
        {
            get
            {
                return this.hilo1;
            }
        }

        public Thread Hilo2
        {
            get
            {
                return this.hilo2;
            }
        }

        public Thread Hilo3
        {
            get
            {
                return this.hilo3;
            }
        }

        #endregion

        public FrmSecundario(List<Docente> docentes, List<Alumno> alumnos, List<Aula> aulas)
        {
            InitializeComponent();

            this.CargarListados(docentes, alumnos, aulas);
          
            //Randoms
            this.aleatorio1 = new Random();
            this.aleatorio2 = new Random();
            this.aleatorio3 = new Random();

            //Manejador del evento
            EvaluacionConcluida += JardinSql.InsertarEvaluacion;
           
            //Threads
            this.hilo1 = new Thread(EvaluarAlumnos);
            this.hilo2 = new Thread(MostrarTiempo);
            this.hilo3 = new Thread(IntervaloRecreo);

            //El primer alumno que sera llamado a rendir
            this.proximoAlumno = LlamarAlumnoAlAzar();
        }

        private void FrmSecundario_Load(object sender, EventArgs e)
        {
            CargarAlumnos();
            ConfigurarTablas();
        }

        #region Cargar

        /// <summary>
        /// Carga las listas con sus respectivos objetos. La de evaluaciones se carga cuando se evaluan a los alumnos
        /// </summary>
        /// <param name="docentes">Lista de docentes</param>
        /// <param name="alumnos">Lista de alumnos</param>
        /// <param name="aulas">Lista de aulas</param>
        private void CargarListados(List<Docente> docentes, List<Alumno> alumnos, List<Aula> aulas)
        {
            //Esto se hace para que cada formulario tenga 2 copias de las listas por separado y no haya conflictos cuando modificas un listado en un form 
            //y se afecta a los controles del otro form
            this.listadoDocentes = new List<Docente>();
            this.listadoAlumnos = new List<Alumno>();
            this.listadoAulas = new List<Aula>();
            this.listadoEvaluaciones = new List<Evaluacion>();

            foreach (Docente d in docentes)
            {
                this.listadoDocentes.Add(d);
            }

            foreach(Alumno a in alumnos)
            {
                this.listadoAlumnos.Add(a);
            }

            foreach(Aula a in aulas)
            {
                this.listadoAulas.Add(a);
            }
        }

        /// <summary>
        /// Carga la lstboxAlumnos con la lista de alumnos
        /// </summary>
        private void CargarAlumnos()
        {
            foreach (Alumno a in this.listadoAlumnos)
            {
                this.lstboxAlumnos.Items.Add(a);
            }
        }

        #endregion

        #region Llamar al azar

        /// <summary>
        /// Devuelve un alumno elegido al azar de la lista de alumnos
        /// </summary>
        /// <returns>Alumno elegido al azar</returns>
        private Alumno LlamarAlumnoAlAzar()
        {
            Alumno retorno = null;

            int indiceAleatorio = aleatorio1.Next(this.listadoAlumnos.Count);

            retorno = this.listadoAlumnos[indiceAleatorio];

            return retorno;
        }

        /// <summary>
        /// Devuelve un docente elegido al azar de la lista de docentes
        /// </summary>
        /// <returns>Docente elegido al azar</returns>
        private Docente LlamarDocenteAlAzar()
        {
            Docente retorno = null;

            int indiceAleatorio = aleatorio2.Next(this.listadoDocentes.Count);
          
            retorno = this.listadoDocentes[indiceAleatorio];

            return retorno;
        }

        /// <summary>
        /// Devuelve un aula elegida al azar de la lista de aulas
        /// </summary>
        /// <returns>Aula elegida al azar</returns>
        private Aula LlamarAulaAlAzar()
        {
            Aula retorno = null;

            int indiceAleatorio = aleatorio3.Next(this.listadoAulas.Count);

            retorno = this.listadoAulas[indiceAleatorio];

            return retorno;
        }

        #endregion

        #region Mostrar en formulario

        /// <summary>
        /// Muestra en el formulario el alumno que esta rindiendo la evaluacion actualmente
        /// </summary>
        /// <param name="a">Alumno en evaluacion</param>
        private void MostrarAlumnoEnEvaluacion(Alumno a)
        {
            if(this.txtAlumnoEnEvaluacion.InvokeRequired)
            {
                txtAlumnoEnEvaluacion.BeginInvoke((MethodInvoker)delegate
                {
                    this.txtAlumnoEnEvaluacion.Text = a.mostrarAlumno();
                });
            }
            else
            {
                this.txtAlumnoEnEvaluacion.Text = a.mostrarAlumno();
            }
        }

        /// <summary>
        /// Muestra en el formulario al proximo alumno que rendira la evaluacion cuando termine el que rinde actualmente
        /// </summary>
        /// <param name="a">Alumno proximo a rendir</param>
        private void MostrarProximoAlumno(Alumno a)
        {
            if(this.txtProximoAlumno.InvokeRequired)
            {
                txtProximoAlumno.BeginInvoke((MethodInvoker)delegate
                {
                    this.txtProximoAlumno.Text = a.mostrarAlumno();
                });
            }
            else
            {
                this.txtProximoAlumno.Text = a.mostrarAlumno();
            }
        }

        /// <summary>
        /// Muestra en el formulario el docente que esta evaluando actualmente
        /// </summary>
        /// <param name="d">Docente evaluando</param>
        private void MostrarDocenteEvaluando(Docente d)
        {
            if(this.txtDocenteEvaluando.InvokeRequired)
            {
                txtDocenteEvaluando.BeginInvoke((MethodInvoker)delegate
                {
                    this.txtDocenteEvaluando.Text = d.mostrarDocente();
                });
            }
            else
            {
                this.txtDocenteEvaluando.Text = d.mostrarDocente();
            }
        }

        #endregion

        #region Actualizar

        /// <summary>
        /// Remueve de la lstboxAlumnos los alumnos que ya fueron evaluados
        /// </summary>
        /// <param name="a">Alumno a remover</param>
        private void ActualizarListaEsperaAlumnos(Alumno a)
        {
            if (this.lstboxAlumnos.InvokeRequired)
            {
                lstboxAlumnos.BeginInvoke((MethodInvoker)delegate
                {
                    this.lstboxAlumnos.Items.Remove(a);
                });
            }
            else
            {
                this.lstboxAlumnos.Items.Remove(a);
            }
        }

        /// <summary>
        /// Actualiza la dgvTablaEvaluaciones obteniendo las evaluaciones de la base de datos
        /// </summary>
        private void ActualizarListaEvaluaciones()
        {
            if (this.dgvTablaEvaluaciones.InvokeRequired)
            {
                dgvTablaEvaluaciones.BeginInvoke((MethodInvoker)delegate
                {
                    try
                    {
                        this.dgvTablaEvaluaciones.DataSource = JardinSql.ObtenerEvaluaciones();
                    }
                    catch (Exception excepcion)
                    {
                        //Se registra la informacion de la excepcion en un archivo txt
                        ArchivoTxt.GuardarEnLog("Ocurrio el siguiente error: " + excepcion.Message);
                        MessageBox.Show(excepcion.Message, "Error");
                    }
                });
            }
            else
            {
                try
                {
                    this.dgvTablaEvaluaciones.DataSource = JardinSql.ObtenerEvaluaciones();               
                }
                catch (Exception excepcion)
                {
                    //Se registra la informacion de la excepcion en un archivo txt
                    ArchivoTxt.GuardarEnLog("Ocurrio el siguiente error: " + excepcion.Message);
                    MessageBox.Show(excepcion.Message, "Error");
                }
            }
        }

        #endregion

        #region Poner en blanco

        /// <summary>
        /// Pone en blanco los siguientes textboxs: txtProximoAlumno, txtAlumnoEnEvaluacion, txtDocenteEvaluando
        /// Se utiliza cuando se termino de evaluar a todos los alumnos a modo de limpiar esos campos del formulario
        /// </summary>
        public void PonerEnBlanco()
        {
            if (this.txtProximoAlumno.InvokeRequired)
            {
                txtProximoAlumno.BeginInvoke((MethodInvoker)delegate
                {
                    this.txtProximoAlumno.Text = string.Empty;
                });
            }
            else
            {
                this.txtProximoAlumno.Text = string.Empty;
            }

            if (this.txtAlumnoEnEvaluacion.InvokeRequired)
            {
                txtAlumnoEnEvaluacion.BeginInvoke((MethodInvoker)delegate
                {
                    this.txtAlumnoEnEvaluacion.Text = string.Empty;
                });
            }
            else
            {
                this.txtAlumnoEnEvaluacion.Text = string.Empty;
            }

            if (this.txtDocenteEvaluando.InvokeRequired)
            {
                txtDocenteEvaluando.BeginInvoke((MethodInvoker)delegate
                {
                    this.txtDocenteEvaluando.Text = string.Empty;
                });
            }
            else
            {
                this.txtDocenteEvaluando.Text = string.Empty;
            }
        }

        #endregion

        #region Metodos dedicados al proceso de Evaluacion

        /// <summary>
        /// Incia el proceso de evaluar a los alumnos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnComenzarEvaluacion_Click(object sender, EventArgs e)
        {
            this.btnComenzarEvaluacion.Enabled = false;
            this.lblNoHayRecreo.Visible = true;
            this.lblTiempoTranscurrido.Visible = true;
            this.hilo1.Start();
            this.hilo2.Start();
            this.hilo3.Start();
        }

        /// <summary>
        /// Lleva a cabo el proceso de evaluacion de los alumnos
        /// </summary>
        private void EvaluarAlumnos()
        {
            //Se ejecuta hasta que ya no queden alumnos para evaluar
            //Cuando un alumno termine de rendir se lo remueve de la lista de alumnos
            while (this.listadoAlumnos.Count != 0)
            {
                //Llamo al proximo alumno a ser evaluado
                //El primer alumno que rinde se genera cuando inicia el programa y se guarda en el atributo proximoAlumno del form
                MostrarProximoAlumno(this.proximoAlumno);
                this.listadoAlumnos.Remove(proximoAlumno);
                ActualizarListaEsperaAlumnos(proximoAlumno);

                Thread.Sleep(2000);

                Alumno alumnoEnEvaluacion = proximoAlumno;
                MostrarAlumnoEnEvaluacion(alumnoEnEvaluacion);

                //Si la lista de alumnos esta en 0 es porque no hay un proximo alumno a quien llamar
                if(this.listadoAlumnos.Count !=0)
                {
                    this.proximoAlumno = LlamarAlumnoAlAzar();
                    MostrarProximoAlumno(proximoAlumno);
                }
              
                Aula aulaEvaluacion = LlamarAulaAlAzar();
                Docente docenteEvaluador = LlamarDocenteAlAzar();
                MostrarDocenteEvaluando(docenteEvaluador);
                
                Evaluar();

                Evaluacion e = this.generarEvaluacion(alumnoEnEvaluacion, docenteEvaluador, aulaEvaluacion);

                try
                {
                    EvaluacionConcluida.Invoke(e);
                }
                catch (Exception excepcion)
                {
                    //Se registra la informacion de la excepcion en un archivo txt
                    ArchivoTxt.GuardarEnLog("Ocurrio el siguiente error: " + excepcion.Message);
                    MessageBox.Show(excepcion.Message, "Error");
                }

                ActualizarListaEvaluaciones();

                //Se aprueba con 5 o mas
                if(e.NotaFinal>= 5)
                {
                    alumnoEnEvaluacion.NotaFinal = e.NotaFinal;
                    SerializarAlumnoAprobado(alumnoEnEvaluacion);
                }
                else
                {
                    alumnoEnEvaluacion.NotaFinal = e.NotaFinal;
                    SerializarAlumnoDesaprobado(alumnoEnEvaluacion);
                }
            }

            PonerEnBlanco();
        }

        /// <summary>
        /// Simula el tiempo que dura la evaluacion
        /// </summary>
        public void Evaluar()
        {
            if (this.lblEvaluacionEnProceso.InvokeRequired)
            {
                lblEvaluacionEnProceso.BeginInvoke((MethodInvoker)delegate
                {
                    this.lblEvaluacionEnProceso.Visible = true;
                });
            }
            else
            {
                this.lblEvaluacionEnProceso.Visible = true;
            }

            Thread.Sleep(8000);

            if (this.lblEvaluacionEnProceso.InvokeRequired)
            {
                lblEvaluacionEnProceso.BeginInvoke((MethodInvoker)delegate
                {
                    this.lblEvaluacionEnProceso.Visible = false;
                });
            }
            else
            {
                this.lblEvaluacionEnProceso.Visible = false;
            }
        }

        /// <summary>
        /// Genera un objeto evaluacion y lo devuelve
        /// </summary>
        /// <param name="alumno">Alumno dueño de la evaluacion</param>
        /// <param name="docente">Docente que tomo la evaluacion</param>
        /// <param name="aula">Aula donde se rindio la evaluacion</param>
        /// <returns>Evaluacion generada</returns>
        public Evaluacion generarEvaluacion(Alumno alumno, Docente docente, Aula aula)
        {
            //Atributos del objeto evaluacion
            //El id no importa porque se genera automaticamente cuando se inserta la evaluacion en la base de datos
            int idEvaluacion = 0;
            int idAlumno = alumno.IdAlumno;
            int idDocente = docente.Id;
            int idAula = aula.IdAula;
            int nota1 = this.aleatorio1.Next(1, 10);
            int nota2 = this.aleatorio2.Next(1, 10);
            float notaFinal = (((float)nota1 + nota2) / 2);

            List<string> listaObservaciones = new List<string>();
            listaObservaciones.Add("Excelente redaccion");
            listaObservaciones.Add("Muchas faltas de ortografía");
            listaObservaciones.Add("No se entiende la letra");
            listaObservaciones.Add("Mejorar puntuacion");
            listaObservaciones.Add("Excelente composicion");

            //Elijo una observacion al azar
            int indiceAleatorio = aleatorio3.Next(listaObservaciones.Count);

            string observacion = listaObservaciones[indiceAleatorio];

            Evaluacion retorno = new Evaluacion(idEvaluacion, idAlumno, idDocente, idAula, nota1, nota2, notaFinal, observacion);

            return retorno;
        }

        #endregion

        #region Recreo

        /// <summary>
        /// Cada 20 segundos inicia un nuevo recreo
        /// </summary>
        public void IntervaloRecreo()
        {
            while(this.hilo1.IsAlive)
            {
                Thread.Sleep(20000);
                MostrarRecreo();
            }         
        }

        /// <summary>
        /// Muestra cuando se esta en recreo y cuando no
        /// </summary>
        public void MostrarRecreo()
        {
            if (lblRecreoEnProceso.InvokeRequired)
            {
                lblRecreoEnProceso.BeginInvoke((MethodInvoker)delegate ()
                {
                    this.lblRecreoEnProceso.Visible = true;
                });
            }
            else
            {
                this.lblRecreoEnProceso.Visible = true;
            }

            if (lblNoHayRecreo.InvokeRequired)
            {
                lblNoHayRecreo.BeginInvoke((MethodInvoker)delegate ()
                {
                    this.lblNoHayRecreo.Visible = false;
                });
            }
            else
            {
                this.lblNoHayRecreo.Visible = false;
            }

            Thread.Sleep(5000);

            if (lblRecreoEnProceso.InvokeRequired)
            {
                lblRecreoEnProceso.BeginInvoke((MethodInvoker)delegate ()
                {
                    this.lblRecreoEnProceso.Visible = false;
                });
            }
            else
            {
                this.lblRecreoEnProceso.Visible = false;
            }

            if (lblNoHayRecreo.InvokeRequired)
            {
                lblNoHayRecreo.BeginInvoke((MethodInvoker)delegate ()
                {
                    this.lblNoHayRecreo.Visible = true;
                });
            }
            else
            {
                this.lblNoHayRecreo.Visible = true;
            }
        }

        #endregion

        #region Serializar

        /// <summary>
        /// Serializa a un alumno aprobado en Xml
        /// </summary>
        /// <param name="a">Alumno a serializar</param>
        private void SerializarAlumnoAprobado(Alumno a)
        {
            string fecha = DateTime.Now.ToString("dddd_MMMM_yyyy");
            string nombreArchivo = a.Apellido + "_" + a.Nombre + "_" + fecha + ".xml";

            ArchivoXml<Alumno> serializador = new ArchivoXml<Alumno>();
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\SegundoParcialUtn\\JardinUtn\\Serializaciones\\APROBADOS\\" + nombreArchivo;

            try
            {
                serializador.Guardar(a, path);
            }
            catch (Exception excepcion)
            {
                //Se registra la informacion de la excepcion en un archivo txt
                ArchivoTxt.GuardarEnLog("Ocurrio el siguiente error: " + excepcion.Message);
                MessageBox.Show(excepcion.Message, "Error");
            }
        }

        /// <summary>
        /// Serializa a un alumno desaprobado en Xml
        /// </summary>
        /// <param name="a">Alumno a serializar</param>
        private void SerializarAlumnoDesaprobado(Alumno a)
        {
            string fecha = DateTime.Now.ToString("dddd_MMMM_yyyy");
            string nombreArchivo = a.Apellido + "_" + a.Nombre + "_" + fecha + ".xml";

            ArchivoXml<Alumno> serializador = new ArchivoXml<Alumno>();
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\SegundoParcialUtn\\JardinUtn\\Serializaciones\\DESAPROBADOS\\" + nombreArchivo;

            try
            {
                serializador.Guardar(a, path);
            }
            catch (Exception excepcion)
            {
                //Se registra la informacion de la excepcion en un archivo txt
                ArchivoTxt.GuardarEnLog("Ocurrio el siguiente error: " + excepcion.Message);
                MessageBox.Show(excepcion.Message, "Error");
            }
        }

        #endregion

        /// <summary>
        /// Configura la tabla de evaluaciones
        /// </summary>
        private void ConfigurarTablas()
        {
            dgvTablaEvaluaciones.ReadOnly = true;
            dgvTablaEvaluaciones.RowHeadersVisible = false;
            dgvTablaEvaluaciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTablaEvaluaciones.AllowUserToAddRows = false;
        }

        /// <summary>
        /// Muestra el tiempo transcurrido de evaluacion
        /// </summary>
        public void MostrarTiempo()
        {
            //Declaro un objeto DateTime con minutos y segundos en 0
            DateTime dt = new DateTime(2020, 10, 10, 0, 0, 0);

            //Se ejecuta mientras dura la evaluacion que se corre en el hilo1
            while (this.hilo1.IsAlive)
            {
                if (lblTiempoTranscurrido.InvokeRequired)
                {
                    lblTiempoTranscurrido.BeginInvoke((MethodInvoker)delegate ()
                    {
                        lblTiempoTranscurrido.Text = dt.ToString("00:mm:ss");
                    });
                }
                else
                {
                    lblTiempoTranscurrido.Text = dt.ToString("00:mm:ss");
                }

                //Lo actualiza cada segundo que pasa.
                Thread.Sleep(1000);
                dt = dt.AddSeconds(1);
            }
        }

        private void FrmSecundario_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(this.hilo1.IsAlive)
            {
                this.hilo1.Abort();
            }

            if (this.hilo2.IsAlive)
            {
                this.hilo2.Abort();
            }

            if (this.hilo3.IsAlive)
            {
                this.hilo2.Abort();
            }
        }

        private void btnProbarCosas_Click(object sender, EventArgs e)
        {
            //---------->PROBAR SERIALIZAR Y DESERIALIZAR ALUMNO EN XML
            /*
            Alumno a = new Alumno("Aristobulo", "DelValle", 5, 39123456, "Calle false 123", 1, "7");
            a.NotaFinal = 9;

            string fecha = DateTime.Now.ToString("dddd_MMMM_yyyy");
            string nombreArchivo = a.Apellido + "_" + a.Nombre + "_" + fecha + ".xml";

            ArchivoXml<Alumno> serializador = new ArchivoXml<Alumno>();
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + nombreArchivo;
            serializador.Guardar(a, path);

            Alumno b = serializador.Leer(path);

            MessageBox.Show(b.ToString());
            */

            //---------->PRUEBA SERIALIZAR Y DESERIALIZAR ALUMNO EN BINARIO
            /*
            Alumno a = new Alumno("Juan", "Perez", 5, 39123456, "Calle false 123", 1, "7");
            a.NotaFinal = 9;

            string fecha = DateTime.Now.ToString("dddd_MMMM_yyyy");
            string nombreArchivo = a.Apellido + "_" + a.Nombre + "_" + fecha + ".bin";

            ArchivoBin<Alumno> serializador = new ArchivoBin<Alumno>();
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + nombreArchivo;
            serializador.Guardar(a, path);

            Alumno b = serializador.Leer(path);

            MessageBox.Show(b.ToString());
            */

            //---------->PRUEBA METODO DE EXTENSION BACKEAR DOCENTES
            /*
            ArchivoXml<Alumno> serializador = new ArchivoXml<Alumno>();
            serializador.BackearDocentes();
            this.btnProbarCosas.Enabled = false;
            */
        }
    }
}
