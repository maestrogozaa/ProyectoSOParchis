using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        Form3 formularioConsultas;
        Socket server;
        string nombreUsuario, personaInvitada;
        bool admin;
        string nombreAdmin;
        bool celdaSeleccionada = false;
        bool enSala = false;
        bool partidaEmpezada = false;


        public Form2(string nombreUsuario, Socket server)
        {
            InitializeComponent();
            usuarioLbl.Text = "Hola, '" + nombreUsuario + "'";
            this.admin = false;
            this.server = server;
            this.nombreUsuario = nombreUsuario;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            AjustarDataGridView(dataGridView1);
            this.BackColor = Color.DarkMagenta;
        }

        public void EscribeConectados(string conectados)
        {
            try
            {
                string[] usuariosConectados = conectados.Split('/');

                if (this.InvokeRequired)
                {
                    this.Invoke(new Action<string>(EscribeConectados), new object[] { conectados });
                }
                else
                {
                    dataGridView1.Rows.Clear(); 

                    foreach (string usuario in usuariosConectados)
                    {
                        if (!string.IsNullOrWhiteSpace(usuario)) 
                        {
                            dataGridView1.Rows.Add(usuario);
                        }
                    }
                    AjustarDataGridView(dataGridView1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error actualizando DataGridView: " + ex.Message);
            }
        }
        public void EscribeJugadoresSala(string jugadores)
        {
            try
            {
                string[] jugadoresSala = jugadores.Split('-');

                if (this.InvokeRequired)
                {
                    this.Invoke(new Action<string>(EscribeJugadoresSala), new object[] { jugadores });
                }
                else
                {
                    dataGridView2.Rows.Clear();

                    foreach (string jugador in jugadoresSala)
                    {
                        if (!string.IsNullOrWhiteSpace(jugador))
                        {
                            dataGridView2.Rows.Add(jugador);
                        }
                    }
                    AjustarDataGridView(dataGridView2);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error actualizando DataGridView: " + ex.Message);
            }
        }
        public void EscribirGrid(string jugador)
        {
            formularioConsultas.EscribirGrid(jugador);
        }
        public void EscribirGrid2(string info)
        {
            formularioConsultas.EscribirGrid2(info);
        }
        public void EscribirGrid3(string info)
        {
            formularioConsultas.EscribirGrid3(info);
        }
        public void EscribirMensajeConsultas(string mensaje)
        {
            formularioConsultas.EscribirMensajeConsultas(mensaje);
        }

        public void SetAdmin(bool admin)
        {
            this.admin = admin;
        }
        public void EnSala(bool enSala)
        {
            this.enSala = enSala;
        }
        public void Ajustes(bool partidaEmpezada)
        {
            this.partidaEmpezada = partidaEmpezada;
            empezarpartidaBtn.Visible = !partidaEmpezada;
        }
        public void SetNombreAdmin(string nombreAdmin)
        {
            this.nombreAdmin = nombreAdmin;
        }
        public void SetGrid2(bool gridSala)
        {
            salaJuegoLbl.Visible = gridSala;
            dataGridView2.Visible = gridSala;
            chatSalaLbl.Visible = gridSala;
            mensajeslistBox.Visible = gridSala;
            escribirMensajesTextBox.Visible = gridSala;
            enviarMensajeBtn.Visible = gridSala;
        }
        public void SetGrid(bool gridSala)
        {
            salaJuegoLbl.Visible = gridSala;
            dataGridView2.Visible = gridSala;
            chatSalaLbl.Visible = gridSala;
            mensajeslistBox.Visible = gridSala;
            escribirMensajesTextBox.Visible = gridSala;
            enviarMensajeBtn.Visible = gridSala;
            mensajeslistBox.Items.Clear();
        }
        public void EscribirChat(string emisorMensaje, string mensaje)
        {
            mensajeslistBox.Items.Add(emisorMensaje + ": " + mensaje);
        }
        public void BorrarChat(bool borrar)
        {
            if(borrar) mensajeslistBox.Items.Clear();
        }

        public void EscribirNotificacion(string notificacion)
        {
            MessageBox.Show(notificacion);
        }      

        // Los usuarios invitados reciben la solicitud y deciden si aceptar o rechazar
        public void EscribirSolicitud(string notificacion) // Invitador/Invitado
        {            
            string [] resultado = notificacion.Split('/');
            string invitador = resultado[0];
            string invitado = resultado[1].Split('\0')[0];
            string mensaje = invitador + " te ha invitado a jugar.";
            string contestacion;
            DialogResult result = MessageBox.Show(mensaje + "\n¿Quieres aceptar?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                MessageBox.Show("Has aceptado la solicitud.");
                contestacion = "1";
                this.nombreAdmin = invitador;
                SetGrid(true);
            }
            else
            {
                MessageBox.Show("Has rechazado la solicitud.");
                contestacion = "-1";
                this.nombreAdmin = "";
            }

            //Envío a la base de datos los datos introducidos
            mensaje = $"8/{invitador}/{invitado}/{contestacion}";

            // Enviamos al servidor los datos tecleados
            byte[] msg = Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }

        private void AjustarDataGridView(DataGridView dataGridView)
        {
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridView.AllowUserToResizeColumns = false;
            dataGridView.AllowUserToResizeRows = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.celdaSeleccionada = true;
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                try
                {
                    personaInvitada = dataGridView1[e.ColumnIndex, e.RowIndex].Value.ToString();
                }
                catch (NullReferenceException)
                {
                    personaInvitada = "";
                    this.celdaSeleccionada = false;
                }
            }
        }  
        private void invitacionesBtn_Click(object sender, EventArgs e)
        {
            if (this.celdaSeleccionada)
            {
                personaInvitada = personaInvitada.Split('\0')[0];
                if (nombreUsuario == personaInvitada) MessageBox.Show("No puedes invitar a esta persona. (Eres tú)");
                else
                {
                    if (this.admin)
                    {
                        if (personaInvitada != "" && personaInvitada != null)
                        {
                            //Envío a la base de datos los datos introducidos
                            string mensaje = $"7/{nombreUsuario}/{personaInvitada}";

                            // Enviamos al servidor los datos tecleados
                            byte[] msg = Encoding.ASCII.GetBytes(mensaje);
                            server.Send(msg);
                        }
                        else MessageBox.Show("Por favor, selecciona el usuario al que quieres invitar.");
                    }
                    else MessageBox.Show("Debes crear una sala para poder invitar.");
                }
            }
            else MessageBox.Show("Por favor, selecciona el usuario al que quieres invitar.");
        }

        private void crearSalaBtn_Click(object sender, EventArgs e)
        {
            //Envío a la base de datos los datos introducidos
            string mensaje = $"3/{nombreUsuario}";

            // Enviamos al servidor los datos tecleados
            byte[] msg = Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }

        private void abandonarSalaBtn_Click(object sender, EventArgs e)
        {
            //Envío a la base de datos los datos introducidos
            string mensaje = $"4/{nombreUsuario}/{nombreAdmin}";

            // Enviamos al servidor los datos tecleados
            byte[] msg = Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
            if (this.admin)
            {
                this.admin = false;
                empezarpartidaBtn.Visible = false;
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.enSala)
            {
                MessageBox.Show("Debes salir de la sala para desconectarte.");
                e.Cancel = true; // Cancela el cierre del formulario
                return;
            }

            string mensaje;
            byte[] msg;
            if (admin)
            {
                // Envío a la base de datos los datos introducidos
                mensaje = $"4/{nombreUsuario}";

                // Enviamos al servidor los datos tecleados
                msg = Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }

            // Envío a la base de datos los datos introducidos
            mensaje = $"0/{nombreUsuario}";

            // Enviamos al servidor los datos tecleados
            msg = Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }


        private void enviarMensajeBtn_Click(object sender, EventArgs e)
        {
            string texto = escribirMensajesTextBox.Text;

            if (texto.Replace(" ", "").Length > 0)
            {
                if (texto.Length <= 500)
                {
                    //Envío a la base de datos los datos introducidos
                    string mensaje = $"11/0/{nombreAdmin}/{nombreUsuario}/{texto}";

                    // Enviamos al servidor los datos tecleados
                    byte[] msg = Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);

                    escribirMensajesTextBox.Text = "";
                }
                else MessageBox.Show("El mensaje excede el límite de caracteres. (máx. 500 caracteres)");
            }
            else MessageBox.Show("Debes escribir algo.");
        }

        private void empezarpartidaBtn_Click(object sender, EventArgs e)
        {
            //Envío a la base de datos los datos introducidos
            string mensaje = $"12/{nombreAdmin}";

            // Enviamos al servidor los datos tecleados
            byte[] msg = Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }

        private void consultasBtn_Click(object sender, EventArgs e)
        {
            formularioConsultas = new Form3(server, nombreUsuario);
            formularioConsultas.Show();
        }

        private void bloquearBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
