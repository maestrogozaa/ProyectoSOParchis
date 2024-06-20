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

        private void AjustarDataGridView(DataGridView dataGridView)
        {
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridView.AllowUserToResizeColumns = false;
            dataGridView.AllowUserToResizeRows = false;
        }

        private void listaConectadosBtn_Click(object sender, EventArgs e)
        {
            //Envío a la base de datos los datos introducidos
            string mensaje = $"6/";
            // Enviamos al servidor los datos tecleados
            byte[] msg = Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }

        private void consultasBtn_Click(object sender, EventArgs e)
        {
            formularioConsultas = new Form3(server, nombreUsuario);
            formularioConsultas.ShowDialog();
        }
    }
}
