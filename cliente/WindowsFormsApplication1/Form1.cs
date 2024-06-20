﻿using System;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        int puerto = 9070;
        Socket server;
        Thread atender;
        Form2 formulario;

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
                // Los usuarios reciben la respuesta a la consulta realizada
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
        public void EscribirNotificacion(string notificacion)
        {
            formulario.EscribirNotificacion(notificacion);
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