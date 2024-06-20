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
        string nombreUsuario;


        public Form2(string nombreUsuario, Socket server)
        {
            InitializeComponent();
            usuarioLbl.Text = "Hola, '" + nombreUsuario + "'";
            this.server = server;
            this.nombreUsuario = nombreUsuario;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.DarkMagenta;
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

        public void EscribirNotificacion(string notificacion)
        {
            MessageBox.Show(notificacion);
        }   
        private void consultasBtn_Click(object sender, EventArgs e)
        {
            formularioConsultas = new Form3(server, nombreUsuario);
            formularioConsultas.ShowDialog();
        }
    }
}
