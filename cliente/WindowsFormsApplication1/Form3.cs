using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form3 : Form
    {
        Socket server;
        string nombreUsuario;
        public Form3(Socket server, string nombreUsuario)
        {
            InitializeComponent();
            this.server = server;
            this.nombreUsuario = nombreUsuario;
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void consultarBtn_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            dataGridView3.Rows.Clear();
            string consulta = consultasComboBox.Text;
            string mensaje;
            byte[] msg;
            switch (consulta) 
            {
                case "Listado de jugadores con los que he echado alguna partida.":                    
                    //Envío a la base de datos los datos introducidos
                    mensaje = $"13/1/{nombreUsuario}";
                    // Enviamos al servidor los datos tecleados
                    msg = Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                    break;

                case "Resultados de las partidas que jugué con un jugador (o jugadores) determinado.":
                    int cont = 0;
                    string nombres = "";
                    if (nombreJugador1TextBox.Text.Replace(" ", "").Length > 0)
                    {
                        cont++;
                        nombres += nombreJugador1TextBox.Text;
                        nombres += ",";
                    }
                    if (nombreJugador2TextBox.Text.Replace(" ", "").Length > 0)
                    {
                        cont++;
                        nombres += nombreJugador2TextBox.Text;
                        nombres += ",";
                    }
                    if (nombreJugador3TextBox.Text.Replace(" ", "").Length > 0)
                    {
                        cont++;
                        nombres += nombreJugador3TextBox.Text;
                        nombres += ",";
                    }
                    if (cont > 0)
                    {
                        nombres = nombres.Substring(0, nombres.Length - 1);
                        //Envío a la base de datos los datos introducidos
                        mensaje = $"13/2/{nombreUsuario}/{nombres}";
                        // Enviamos al servidor los datos tecleados
                        msg = Encoding.ASCII.GetBytes(mensaje);
                        server.Send(msg);
                    }
                    else MessageBox.Show("Debes introducir el nombre de un jugador, como mínimo.");
                    break;

                case "Lista de partidas jugadas en un periodo de tiempo dado.":

                    DateTime inicio = this.fechaInicioDateTimePicker.Value;
                    DateTime fin = this.fechaFinalDateTimePicker.Value;

                    if (inicio <= fin)
                    {
                        string [] fechaInicial = fechaInicioDateTimePicker.Text.Split('/');
                        string fechaInicialFormateada = fechaInicial[2] + '-' + fechaInicial[1] + '-' + fechaInicial[0];

                        string[] fechaFinal = fechaFinalDateTimePicker.Text.Split('/');
                        string fechaFinalFormateada = fechaFinal[2] + '-' + fechaFinal[1] + '-' + fechaFinal[0];

                        //Envío a la base de datos los datos introducidos
                        mensaje = $"13/3/{nombreUsuario}/{fechaInicialFormateada}|{fechaFinalFormateada}|";
                        // Enviamos al servidor los datos tecleados
                        msg = Encoding.ASCII.GetBytes(mensaje);
                        server.Send(msg);
                    }
                    else MessageBox.Show("La fecha inicial debe ser menor o igual a la fecha final.");                    
                    break;
            }
        }
        private void consultasComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;

            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            dataGridView3.Rows.Clear();

            string consulta = consultasComboBox.Text;
            switch (consulta)
            {
                case "Listado de jugadores con los que he echado alguna partida.":
                    dataGridView1.Visible = true;
                    consultarBtn.Visible = true;
                    nombreJugador1Lbl.Visible = false;
                    nombreJugador1TextBox.Visible = false;
                    nombreJugador2TextBox.Visible = false;
                    nombreJugador3TextBox.Visible = false;
                    fechaInicioLbl.Visible = false;
                    fechaFinalLbl.Visible = false;
                    fechaInicioDateTimePicker.Visible = false;
                    fechaFinalDateTimePicker.Visible = false;
                    break;

                case "Resultados de las partidas que jugué con un jugador (o jugadores) determinado.":
                    dataGridView2.Visible= true;
                    consultarBtn.Visible = true;
                    nombreJugador1Lbl.Visible = true;
                    nombreJugador1TextBox.Visible = true;
                    nombreJugador2TextBox.Visible = true;
                    nombreJugador3TextBox.Visible = true;
                    fechaInicioLbl.Visible = false;
                    fechaFinalLbl.Visible = false;
                    fechaInicioDateTimePicker.Visible = false;
                    fechaFinalDateTimePicker.Visible = false;
                    break;

                case "Lista de partidas jugadas en un periodo de tiempo dado.":
                    dataGridView3.Visible = true;
                    consultarBtn.Visible = true;
                    nombreJugador1Lbl.Visible = false;
                    nombreJugador1TextBox.Visible = false;
                    nombreJugador2TextBox.Visible = false;
                    nombreJugador3TextBox.Visible = false;
                    fechaInicioLbl.Visible = true;
                    fechaFinalLbl.Visible = true;
                    fechaInicioDateTimePicker.Visible = true;
                    fechaFinalDateTimePicker.Visible = true;
                    break;

                default:
                    nombreJugador1Lbl.Visible = false;
                    nombreJugador1TextBox.Visible = false;
                    nombreJugador2TextBox.Visible = false;
                    nombreJugador3TextBox.Visible = false;
                    fechaInicioLbl.Visible = false;
                    fechaFinalLbl.Visible = false;
                    fechaInicioDateTimePicker.Visible = false;
                    fechaFinalDateTimePicker.Visible = false;
                    consultarBtn.Visible = false;
                    break;

            }
        }
        public void EscribirMensajeConsultas(string mensaje)
        {
            MessageBox.Show(mensaje);
        }
        public void EscribirGrid(string jugadores)
        {
            dataGridView1.Visible = true;
            try
            {
                string[] jugadoresSala = jugadores.Split('-');

                if (this.InvokeRequired)
                {
                    this.Invoke(new Action<string>(EscribirGrid), new object[] { jugadores });
                }
                else
                {
                    dataGridView1.Rows.Clear();

                    foreach (string jugador in jugadoresSala)
                    {
                        if (!string.IsNullOrWhiteSpace(jugador))
                        {
                            dataGridView1.Rows.Add(jugador);
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
        public void EscribirGrid2(string info)
        {
            dataGridView2.Visible = true;

            string[] partidas = info.Split('*');

            dataGridView2.Rows.Clear();
            dataGridView2.Columns.Clear();

            if (partidas.Length > 0)
            {
                string[] primeraPartida = partidas[0].Split('|');
                dataGridView2.Columns.Add("Fecha", "Fecha");
                dataGridView2.Columns.Add("NJugadores", "Número de jugadores");
                dataGridView2.Columns.Add("Jugador1", "Jugador1");
                dataGridView2.Columns.Add("Jugador2", "Jugador2");
                dataGridView2.Columns.Add("Jugador3", "Jugador3");
                dataGridView2.Columns.Add("Jugador4", "Jugador4");
            }

            foreach (string partida in partidas)
            {
                string[] datosPartida = partida.Split('|');

                int indiceFila = dataGridView2.Rows.Add();

                for (int i = 0; i < datosPartida.Length; i++)
                {
                    dataGridView2.Rows[indiceFila].Cells[i].Value = datosPartida[i];
                }
            }

        }
        public void EscribirGrid3(string info)
        {
            dataGridView3.Visible = true;

            string[] partidas = info.Split('*');

            dataGridView3.Rows.Clear();
            dataGridView3.Columns.Clear();

            if (partidas.Length > 0)
            {
                string[] primeraPartida = partidas[0].Split('|');
                dataGridView3.Columns.Add("Fecha", "Fecha");
                dataGridView3.Columns.Add("NJugadores", "Número de jugadores");
                dataGridView3.Columns.Add("Jugador1", "Jugador1");
                dataGridView3.Columns.Add("Jugador2", "Jugador2");
                dataGridView3.Columns.Add("Jugador3", "Jugador3");
                dataGridView3.Columns.Add("Jugador4", "Jugador4");
            }

            foreach (string partida in partidas)
            {
                string[] datosPartida = partida.Split('|');

                int indiceFila = dataGridView3.Rows.Add();

                for (int i = 0; i < datosPartida.Length; i++)
                {
                    dataGridView3.Rows[indiceFila].Cells[i].Value = datosPartida[i];
                }
            }
        }

        public void AjustarDataGridView(DataGridView dataGridView)
        {
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridView.AllowUserToResizeColumns = false;
            dataGridView.AllowUserToResizeRows = false;
        }
    }
}
