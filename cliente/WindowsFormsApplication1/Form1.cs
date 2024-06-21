using System;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ParchisClassLibrary1;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        int puerto = 50015;
        Socket server;
        Thread atender;
        Form2 formulario;
        FormTablero formulario2;

        delegate void DelegadoParaEscribir(string mensaje);
        delegate void DelegadoParaActualizarJuego(int turno, string posiciones);
        delegate void DelegadoParaBorrar(bool borrar);
        delegate void DelegadoParaSala(bool enSala);
        delegate void DelegadoParaSolicitud(string notificacion);
        delegate void DelegadoParaAdmin(bool admin);
        delegate void DelegadoParaAdmin2(string nombreAdmin);
        delegate void DelegadoParaGridSala(bool gridSala);
        delegate void DelegadoParaAjustes(bool partidaEmpezada);
        delegate void DelegadoParaAbrirFormulario();

        public string nombreUsuario, correo, contrasena;
        public bool conectado, logeado, admin, gridSala, enSala = false;

        public void AtenderServidor()
        {
            while (true)
            {
                byte[] msg2 = new byte[2000];
                server.Receive(msg2);
                string[] trozos = Encoding.ASCII.GetString(msg2).Split('/');
                int codigo = Convert.ToInt32(trozos[0]);
                string mensaje;

                // Respuesta del servidor a la petición de darse de baja
                if (codigo == -2)
                {
                    mensaje = trozos[1].Split('\0')[0];
                    if (mensaje == "1")
                    {
                        MessageBox.Show("Usuario dado de baja con éxito!");
                        this.logeado = false;
                        OcultarElementosLogin();
                        OcultarElementosSignup();
                        OcultarElementosUnsubscribe();
                    }
                    else if (mensaje == "-1")
                    {
                        MessageBox.Show("No existe ningún usuario con los datos introducidos.");
                    }
                    else if (mensaje == "-2")
                    {
                        MessageBox.Show("Este usuario está conectado en estos momentos.\nPor favor, cierre sesión para poder darte de baja.");
                    }
                }
                // Respuesta del servidor a la petición de registro
                if (codigo == 1)
                {
                    mensaje = trozos[1].Split('\0')[0];
                    if (mensaje == "1")
                    {
                        MessageBox.Show("Registrado con éxito.\nBienvenido , " + signupUsuariotextBox.Text + "!");
                        this.logeado = true;
                        OcultarElementosSignup();
                        OcultarElementosUnsubscribe();
                        this.Hide();
                        PonerEnMarchaFormulario();
                    }
                    else if (mensaje == "-1")
                    {
                        MessageBox.Show("Este usuario ya existe.");
                    }
                    else MessageBox.Show("Otro error.");
                }

                // Respuesta del servidor a la petición de iniciar sesión
                if (codigo == 2)
                {
                    mensaje = trozos[1].Split('\0')[0];
                    if (mensaje == "1")
                    {
                        MessageBox.Show("Bienvenido de nuevo, " + loginUsuariotextBox.Text + "!");
                        this.logeado = true;
                        OcultarElementosLogin();
                        OcultarElementosUnsubscribe();
                        this.Hide();
                        PonerEnMarchaFormulario();
                    }
                    else if (mensaje == "-1")
                    {
                        MessageBox.Show("El usuario no existe o las credenciales son incorrectas.");
                    }
                    else if (mensaje == "-2")
                    {
                        MessageBox.Show("Este usuario ya está conectado.");
                    }
                }
                // Respuesta del servidor a la creación de una sala
                if (codigo == 3)
                {
                    string notificacion;
                    mensaje = trozos[1].Split('\0')[0];
                    if (mensaje == "1")
                    {
                        notificacion = "Sala creada con éxito!";
                        admin = true;
                        gridSala = true;
                        enSala = true;

                        DelegadoParaEscribir delegado = new DelegadoParaEscribir(EscribirNotificacion);
                        this.Invoke(delegado, new object[] { notificacion });

                        DelegadoParaAdmin2 delegado5 = new DelegadoParaAdmin2(SetNombreAdmin);
                        this.Invoke(delegado5, new object[] { nombreUsuario });

                        DelegadoParaAjustes delegado7 = new DelegadoParaAjustes(Ajustes);
                        this.Invoke(delegado7, new object[] { false });
                    }
                    else
                    {
                        notificacion = "Ya estás en una sala.";

                        DelegadoParaEscribir delegado = new DelegadoParaEscribir(EscribirNotificacion);
                        this.Invoke(delegado, new object[] { notificacion });
                        admin = true;
                        enSala = true;
                        gridSala = true;
                    }                    

                    DelegadoParaAdmin delegado2 = new DelegadoParaAdmin(SetAdmin);
                    this.Invoke(delegado2, new object[] { admin });

                    DelegadoParaGridSala delegado3 = new DelegadoParaGridSala(SetGrid2);
                    this.Invoke(delegado3, new object[] { gridSala });

                    DelegadoParaSala delegado6 = new DelegadoParaSala(EnSala);
                    this.Invoke(delegado6, new object[] { enSala });
                }
                // Respuesta del servidor al abandono de una sala
                if (codigo == 4)
                {
                    DelegadoParaBorrar delegado4 = new DelegadoParaBorrar(BorrarChat);
                    string notificacion;
                    mensaje = trozos[1].Split('\0')[0];
                    if (mensaje == "1")
                    {
                        notificacion = "Has abandonado la sala";
                        this.Invoke(delegado4, new object[] { true });
                        enSala = false;

                        DelegadoParaAdmin2 delegado5 = new DelegadoParaAdmin2(SetNombreAdmin);
                        this.Invoke(delegado5, new object[] { "" });
                    }
                    else
                    {
                        notificacion = "No estás en ninguna sala.";
                        enSala = false;
                    }
                    DelegadoParaEscribir delegado = new DelegadoParaEscribir(EscribirNotificacion);
                    this.Invoke(delegado, new object[] { notificacion });

                    DelegadoParaAdmin delegado2 = new DelegadoParaAdmin(SetAdmin);
                    this.Invoke(delegado2, new object[] { false });

                    DelegadoParaGridSala delegado3 = new DelegadoParaGridSala(SetGrid);
                    this.Invoke(delegado3, new object[] { false});

                    DelegadoParaSala delegado6 = new DelegadoParaSala(EnSala);
                    this.Invoke(delegado6, new object[] { enSala });
                }
                // El servidor envia la lista de jugadores dentro de la sala
                if (codigo == 5)
                {
                    string jugadores = trozos[1].Split('\0')[0];

                    DelegadoParaEscribir delegado = new DelegadoParaEscribir(EscribeJugadoresSala);
                    this.Invoke(delegado, new object[] { jugadores });
                }

                // El servidor envia la lista de conectados a todos los usuarios conectados
                if (codigo == 6)
                {
                    string conectados = string.Join("/", trozos.Skip(1));
                    DelegadoParaEscribir delegado = new DelegadoParaEscribir(EscribirConectados);
                    this.Invoke(delegado, new object[] { conectados });
                }

                // El usuario que invita recibe un mensaje para notificar el estado de la invitación
                if (codigo == 7)
                {
                    string notificacion = trozos[1].Split('\0')[0];
                    DelegadoParaEscribir delegado = new DelegadoParaEscribir(EscribirNotificacion);
                    this.Invoke(delegado, new object[] { notificacion });
                }

                // Los usuarios invitados reciben la notificación y pueden aceptar o rechazar
                if (codigo == 8)
                {
                    string notificacion = string.Join("/", trozos.Skip(1));
                    DelegadoParaSolicitud delegado = new DelegadoParaSolicitud(EscribirSolicitud);
                    this.Invoke(delegado, new object[] { notificacion });
                }

                // Los usuarios invitados reciben un mensaje para notificar el estado de la unión
                if (codigo == 9)
                {
                    string notificacion = trozos[1].Split('\0')[0];
                    DelegadoParaEscribir delegado = new DelegadoParaEscribir(EscribirNotificacion);
                    this.Invoke(delegado, new object[] { notificacion });
                }

                // Los usuarios invitados reciben un mensaje de que la sala ha sido eliminada
                if (codigo == 10)
                {
                    string notificacion = trozos[1].Split('\0')[0];
                    DelegadoParaEscribir delegado = new DelegadoParaEscribir(EscribirNotificacion);
                    this.Invoke(delegado, new object[] { notificacion });

                    DelegadoParaGridSala delegado2 = new DelegadoParaGridSala(SetGrid);
                    this.Invoke(delegado2, new object[] { false});
                }
                // Se actualiza el chat de la sala
                if (codigo == 11)
                {
                    int form = Convert.ToInt32(trozos[1]);
                    string mensajeChat = trozos[2].Split('\0')[0];
                    DelegadoParaGridSala delegado2 = new DelegadoParaGridSala(SetGrid2);
                    this.Invoke(delegado2, new object[] { true });

                    if(form == 0)
                    {
                        DelegadoParaEscribir delegado = new DelegadoParaEscribir(EscribirChat);
                        this.Invoke(delegado, new object[] { mensajeChat });
                    }
                    else
                    {
                        DelegadoParaEscribir delegado3 = new DelegadoParaEscribir(EscribirChatJuego);
                        this.Invoke(delegado3, new object[] { mensajeChat });
                    }
                }
                // Los usuarios invitados reciben un mensaje de que la partida va a empezar
                if (codigo == 12)
                {
                    // Cambiamos la división basada en '\0' por una división basada en '/'

                    string mensajeParte1 = trozos[1];
                    string nombreAdmin;
                    int turno;
                    int numeroJugadores;
                    // Procesamos la respuesta basándonos en el código de operación
                    if (mensajeParte1 == "1")
                    {
                        nombreAdmin = trozos[2];
                        turno = Convert.ToInt32(trozos[3].Split('\0')[0]);
                        numeroJugadores = Convert.ToInt32(trozos[4].Split('\0')[0]);

                        MessageBox.Show("La partida está a punto de empezar.");
                        DelegadoParaAjustes delegado = new DelegadoParaAjustes(Ajustes);
                        this.Invoke(delegado, new object[] { true });
                        PonerEnMarchaFormularioTablero(nombreAdmin, turno, numeroJugadores);
                    }
                    else if (mensajeParte1 == "-1")
                    {
                        MessageBox.Show("Faltan jugadores.");
                    }
                    else
                    {
                        MessageBox.Show($"Mensaje inesperado: {mensajeParte1}");
                    }

                }
                // Los usuarios reciben la resupuesta a la consulta realizada
                if (codigo == 13)
                {
                    string num_consulta = trozos[1];
                    string resultado = trozos[2];
                                        
                    if (num_consulta == "1")
                    {
                        if (resultado == "1")
                        {
                            string jugadores = trozos[3].Split('\0')[0];
                            DelegadoParaEscribir delegado = new DelegadoParaEscribir(RellenarGrid);
                            this.Invoke(delegado, new object[] { jugadores });
                        }
                        else
                        {
                            string msg = "No has jugado con nadie todavía.";
                            DelegadoParaEscribir delegado = new DelegadoParaEscribir(EscribirMensajeConsultas);
                            this.Invoke(delegado, new object[] { msg });
                        }
                    }
                    else if (num_consulta == "2")
                    {
                        if (resultado == "1")
                        {
                            string info = trozos[3].Split('\0')[0];
                            DelegadoParaEscribir delegado = new DelegadoParaEscribir(RellenarGrid2);
                            this.Invoke(delegado, new object[] { info });
                        }
                        else
                        {
                            string msg = "No has jugado con este jugador todavía.";
                            DelegadoParaEscribir delegado = new DelegadoParaEscribir(EscribirMensajeConsultas);
                            this.Invoke(delegado, new object[] { msg });
                        }
                    }
                    else if (num_consulta == "3")
                    {
                        if (resultado == "1")
                        {
                            string info = trozos[3].Split('\0')[0];
                            DelegadoParaEscribir delegado = new DelegadoParaEscribir(RellenarGrid3);
                            this.Invoke(delegado, new object[] { info });
                        }
                        else
                        {
                            string msg = "No se encontraron partidas en el período especificado.";
                            DelegadoParaEscribir delegado = new DelegadoParaEscribir(EscribirMensajeConsultas);
                            this.Invoke(delegado, new object[] { msg });
                        }
                    }
                }
                // Código del juego
                if (codigo == 20)
                {
                    int turno = Convert.ToInt32(trozos[1]);
                    string posiciones = trozos[2].Split('\0')[0];
                    DelegadoParaActualizarJuego delegado = new DelegadoParaActualizarJuego(ActualizarJuego);
                    this.Invoke(delegado, new object[] { turno, posiciones });
                }
                // Jugador abandona partida
                if (codigo == 21)
                {
                    mensaje = trozos[1].Split('\0')[0];

                    DelegadoParaBorrar delegado4 = new DelegadoParaBorrar(BorrarChat);
                    this.Invoke(delegado4, new object[] { true });

                    DelegadoParaAdmin2 delegado5 = new DelegadoParaAdmin2(SetNombreAdmin);
                    this.Invoke(delegado5, new object[] { "" });
                    enSala = false;

                    DelegadoParaEscribir delegado = new DelegadoParaEscribir(NotificarAbandono);
                    this.Invoke(delegado, new object[] { mensaje });

                    DelegadoParaAdmin delegado2 = new DelegadoParaAdmin(SetAdmin);
                    this.Invoke(delegado2, new object[] { false });

                    DelegadoParaGridSala delegado3 = new DelegadoParaGridSala(SetGrid);
                    this.Invoke(delegado3, new object[] { false });

                    DelegadoParaSala delegado6 = new DelegadoParaSala(EnSala);
                    this.Invoke(delegado6, new object[] { enSala });
                }
            }
        }

        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void Form1_Load(object sender, EventArgs e) { }
        private void PonerEnMarchaFormulario()
        {
            this.Invoke((MethodInvoker)delegate
            {
                formulario = new Form2(nombreUsuario, server);
                formulario.Show();
            });
        }

        private void PonerEnMarchaFormularioTablero(string nombreAdmin, int turno, int numeroJugadores)
        {
            this.Invoke((MethodInvoker)delegate
            {
                formulario2 = new FormTablero(nombreUsuario, nombreAdmin, server, formulario, turno, numeroJugadores);
                formulario2.Show();
            });
        }

        public void EscribirConectados(string conectados)
        {
            try
            {
                formulario.EscribeConectados(conectados);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en EscribirConectados: {ex.Message}");
            }
        }
        public void EscribeJugadoresSala(string jugadores)
        {
            try
            {
                formulario.EscribeJugadoresSala(jugadores);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en EscribirJugadoresSala: {ex.Message}");
            }
        }
        public void EscribirNotificacion(string notificacion)
        {
            formulario.EscribirNotificacion(notificacion);
        }
        public void EscribirChat(string mensaje)
        {
            string[] trozos = mensaje.Split('|');
            string emisor = trozos[0];
            string mensajeChat = trozos[1].Split('\0')[0];
            formulario.EscribirChat(emisor, mensajeChat);
        }
        public void NotificarAbandono(string mensaje)
        {
            formulario2.NotificarAbandono(mensaje);
        }
        public void ActualizarJuego(int turno, string posiciones)
        {
            formulario2.ActualizarJuego(turno, posiciones);
        }
        public void RellenarGrid(string jugador)
        {
            formulario.EscribirGrid(jugador);
        }
        public void RellenarGrid2(string info)
        {
            formulario.EscribirGrid2(info);
        }
        public void RellenarGrid3(string info)
        {
            formulario.EscribirGrid3(info);
        }
        public void EscribirMensajeConsultas(string jugador)
        {
            formulario.EscribirMensajeConsultas(jugador);
        }
        public void EscribirChatJuego(string mensaje)
        {
            string[] trozos = mensaje.Split('|');
            string emisor = trozos[0];
            string mensajeChat = trozos[1].Split('\0')[0];
            formulario2.EscribirChatJuego(emisor, mensajeChat);
        }
        public void BorrarChat(bool borrar)
        {
            formulario.BorrarChat(borrar);
        }
        public void SetAdmin(bool admin)
        {
            formulario.SetAdmin(admin);
        }
        public void SetNombreAdmin(string nombreAdmin)
        {
            formulario.SetNombreAdmin(nombreAdmin);
        }
        public void Ajustes(bool partidaEmpezada)
        {
            formulario.Ajustes(partidaEmpezada);
        }
        public void SetGrid(bool gridSala)
        {
            formulario.SetGrid(gridSala);
        }
        public void EnSala(bool enSala)
        {
            formulario.EnSala(enSala);
        }
        public void SetGrid2(bool gridSala)
        {
            formulario.SetGrid2(gridSala);
        }
        public void EscribirSolicitud(string notificacion)
        {
            formulario.EscribirSolicitud(notificacion);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!this.conectado)
            {
                IPAddress direc = IPAddress.Parse(IP.Text);
                IPEndPoint ipep = new IPEndPoint(direc, puerto);
                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                try
                {
                    server.Connect(ipep);
                    this.BackColor = Color.DarkMagenta;
                    MessageBox.Show("Conexión con el servidor establecida.");
                    this.conectado = true;
                    signupButton.Visible = true;
                    loginButton.Visible = true;
                    unsubscribeButton.Visible = true;
                }
                catch (SocketException ex)
                {
                    MessageBox.Show("No he podido conectar con el servidor.");
                    return;
                }

                ThreadStart ts = delegate { AtenderServidor(); };
                atender = new Thread(ts);
                atender.Start();
            }
            else MessageBox.Show("Ya estás conectado.");
        }

        private void signupButton_Click(object sender, EventArgs e)
        {
            MostrarElementosSignup();
            OcultarElementosLogin();
            OcultarElementosUnsubscribe();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            MostrarElementosLogin();
            OcultarElementosSignup();
            OcultarElementosUnsubscribe();
        }
        private void unsubscribeButton_Click(object sender, EventArgs e)
        {
            MostrarElementosUnsubscribe();
            OcultarElementosLogin();
            OcultarElementosSignup();
        }

        private void desconectarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (conectado)
            {
                this.conectado = false;
                string mensaje;
                if (this.logeado) mensaje = $"0/{nombreUsuario}";
                else
                {
                    nombreUsuario = "";
                    mensaje = $"-1/";
                }
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
                atender.Abort();
                this.BackColor = Color.Gray;
                MessageBox.Show("Hasta la próxima, " + nombreUsuario);
                server.Shutdown(SocketShutdown.Both);
                server.Close();
            }
            // Si no está conectado, cierra automáticamente sin avisar al servidor.
        }        

        private void signupRegistrarButton_Click(object sender, EventArgs e)
        {
            nombreUsuario = signupUsuariotextBox.Text;
            if (signupCorreotextBox.Text != "" && signupUsuariotextBox.Text != "" && signupContraseñatextBox.Text != "")
            {
                string mensaje = $"1/{signupCorreotextBox.Text}/{signupUsuariotextBox.Text}/{signupContraseñatextBox.Text}";
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
            else
            {
                MessageBox.Show("Debes rellenar todos los campos.");
            }
        }

        private void loginEntrarButton_Click(object sender, EventArgs e)
        {
            if (loginUsuariotextBox.Text != "" && loginContraseñatextBox.Text != "")
            {
                nombreUsuario = loginUsuariotextBox.Text;
                string mensaje = $"2/{loginUsuariotextBox.Text}/{loginContraseñatextBox.Text}";
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
            else
            {
                MessageBox.Show("Debes rellenar todos los campos.");
            }
        }

        private void unsubscribeSarseBajaButton_Click(object sender, EventArgs e)
        {
            nombreUsuario = unsubscribeUsuariotextBox.Text;
            if (unsubscribeCorreotextBox.Text != "" && unsubscribeUsuariotextBox.Text != "" && unsubscribeContraseñatextBox.Text != "")
            {
                string mensaje = $"-2/{unsubscribeCorreotextBox.Text}/{unsubscribeUsuariotextBox.Text}/{unsubscribeContraseñatextBox.Text}";
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
            else
            {
                MessageBox.Show("Debes rellenar todos los campos.");
            }
        }

        private void MostrarElementosSignup()
        {
            signupLabel.Visible = true;
            signupCorreoLabel.Visible = true;
            signupUsuarioLabel.Visible = true;
            signupContraseñaLabel.Visible = true;
            signupCorreotextBox.Visible = true;
            signupUsuariotextBox.Visible = true;
            signupContraseñatextBox.Visible = true;
            signupRegistrarButton.Visible = true;
        }

        private void MostrarElementosLogin()
        {
            loginLabel.Visible = true;
            loginUsuarioLabel.Visible = true;
            loginContraseñaLabel.Visible = true;
            loginUsuariotextBox.Visible = true;
            loginContraseñatextBox.Visible = true;
            loginEntrarButton.Visible = true;
        }
        private void MostrarElementosUnsubscribe()
        {
            unsubscribeLbl.Visible = true;
            unsubscribeCorreoLbl.Visible = true;
            unsubscribeUsuarioLbl.Visible = true;
            unsubscribeContraseñaLbl.Visible = true;
            unsubscribeCorreotextBox.Visible = true;
            unsubscribeUsuariotextBox.Visible = true;
            unsubscribeContraseñatextBox.Visible = true;
            unsubscribeSarseBajaButton.Visible = true;
        }

        private void OcultarElementosSignup()
        {
            signupLabel.Visible = false;
            signupCorreoLabel.Visible = false;
            signupUsuarioLabel.Visible = false;
            signupContraseñaLabel.Visible = false;
            signupCorreotextBox.Text = "";
            signupCorreotextBox.Visible = false;
            signupUsuariotextBox.Text = "";
            signupUsuariotextBox.Visible = false;
            signupContraseñatextBox.Text = "";
            signupContraseñatextBox.Visible = false;
            signupRegistrarButton.Visible = false;
        }

        private void OcultarElementosLogin()
        {
            loginLabel.Visible = false;
            loginUsuarioLabel.Visible = false;
            loginContraseñaLabel.Visible = false;
            loginUsuariotextBox.Text = "";
            loginUsuariotextBox.Visible = false;
            loginContraseñatextBox.Text = "";
            loginContraseñatextBox.Visible = false;
            loginEntrarButton.Visible = false;
        }

        private void OcultarElementosUnsubscribe()
        {
            unsubscribeLbl.Visible = false;
            unsubscribeCorreoLbl.Visible = false;
            unsubscribeUsuarioLbl.Visible = false;
            unsubscribeContraseñaLbl.Visible = false;
            unsubscribeCorreotextBox.Text = "";
            unsubscribeCorreotextBox.Visible = false;
            unsubscribeUsuariotextBox.Text = "";
            unsubscribeUsuariotextBox.Visible = false;
            unsubscribeContraseñatextBox.Text = "";
            unsubscribeContraseñatextBox.Visible = false;
            unsubscribeSarseBajaButton.Visible = false;
        }
    }
}
