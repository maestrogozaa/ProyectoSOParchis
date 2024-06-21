using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ParchisClassLibrary1;
using static System.Windows.Forms.LinkLabel;

namespace WindowsFormsApplication1
{
    public partial class FormTablero : Form
    {
        Form2 formularioSala;
        Socket server;

        Color colorJugador;

        Tablero tablero;
        string nombreUsuario, nombreAdmin;
        int miTurno;
        int turno;
        int numeroJugadores;
        int dado1, dado2;
        int sumDados;
        bool partidaTerminada = false;
        bool haTirado = false;
        bool cierreAutomatico = false;
        public FormTablero(string nombreUsuario, string nombreAdmin, Socket server, Form2 formulario, int miTurno, int numeroJugadores)
        {
            InitializeComponent();
            this.nombreUsuario = nombreUsuario;
            this.nombreAdmin = nombreAdmin;
            this.server = server;
            this.formularioSala = formulario;
            nombreJugadorLbl.Text = nombreUsuario;
            this.miTurno = miTurno;
            this.turno = 1;
            this.numeroJugadores = numeroJugadores;
        }

        private void FormTablero_Load(object sender, EventArgs e)
        {
            this.mensajesJuegolistBox.Items.Clear();
            this.formularioSala.Hide();
            //Creamos la Classe para almacenar las Casillas
            tablero = new Tablero();


            //Recivimos del servidor el color del servidor.
            int recibidoColorServer = this.miTurno;
            //recibidoColorServer = Convert.ToInt32(misatgeServer);

            //Creamos los evntos para mover las fichas segun el color que nos ha dicho el servidor

            if (recibidoColorServer == 1)
            {
                teTocaLbl.Visible = true;
                TirarDaus.Visible = true;
                resultadoDado1.Visible = false;
                resultadoDado2.Visible = false;
                colorJugador = Color.Red;
                roja1.Tag = 1;
                roja1.Click += new EventHandler(this.ficha_Click);
                roja2.Tag = 2;
                roja2.Click += new EventHandler(this.ficha_Click);
                roja3.Tag = 3;
                roja3.Click += new EventHandler(this.ficha_Click);
                roja4.Tag = 4;
                roja4.Click += new EventHandler(this.ficha_Click);
            }
            else if (recibidoColorServer == 2)
            {
                colorJugador = Color.Green;

                verde1.Tag = 1;
                verde1.Click += new EventHandler(this.ficha_Click);
                verde2.Tag = 2;
                verde2.Click += new EventHandler(this.ficha_Click);
                verde3.Tag = 3;
                verde3.Click += new EventHandler(this.ficha_Click);
                verde4.Tag = 4;
                verde4.Click += new EventHandler(this.ficha_Click);
            }
            else if (recibidoColorServer == 3)
            {
                colorJugador = Color.Blue;

                azul1.Tag = 1;
                azul1.Click += new EventHandler(this.ficha_Click);
                azul2.Tag = 2;
                azul2.Click += new EventHandler(this.ficha_Click);
                azul3.Tag = 3;
                azul3.Click += new EventHandler(this.ficha_Click);
                azul4.Tag = 4;
                azul4.Click += new EventHandler(this.ficha_Click);
            }
            else if (recibidoColorServer == 4)
            {
                colorJugador = Color.Yellow;

                amarilla1.Tag = 1;
                amarilla1.Click += new EventHandler(this.ficha_Click);
                amarilla2.Tag = 2;
                amarilla2.Click += new EventHandler(this.ficha_Click);
                amarilla3.Tag = 3;
                amarilla3.Click += new EventHandler(this.ficha_Click);
                amarilla4.Tag = 4;
                amarilla4.Click += new EventHandler(this.ficha_Click);
            }

            //Ubicamos las fichas dentro de las casillas 
            //fichas rojas
            roja1.Location = tablero.casillas[0].posicion;
            roja2.Location = tablero.casillas[0].posicion;
            roja3.Location = tablero.casillas[0].posicion;
            roja4.Location = tablero.casillas[0].posicion;
            Torn1Lbl.Visible = true;
            Torn1Lbl.BackColor = Color.Red;

            if (this.numeroJugadores >= 2)
            {
                //fichas Verdes
                verde1.Location = tablero.casillas[1].posicion;
                verde2.Location = tablero.casillas[1].posicion;
                verde3.Location = tablero.casillas[1].posicion;
                verde4.Location = tablero.casillas[1].posicion;
                Torn2Lbl.Visible = true;
                Torn2Lbl.BackColor = Color.Green;
                label5.Visible = true;
            }
            if (this.numeroJugadores >= 3)
            {
                //fichas Azules
                azul1.Location = tablero.casillas[2].posicion;
                azul2.Location = tablero.casillas[2].posicion;
                azul3.Location = tablero.casillas[2].posicion;
                azul4.Location = tablero.casillas[2].posicion;
                Torn3Lbl.Visible = true;
                Torn3Lbl.BackColor = Color.Blue;
                label6.Visible = true;
            }
            if (this.numeroJugadores > 3)
            {
                //fichas Amarillas
                amarilla1.Location = tablero.casillas[3].posicion;
                amarilla2.Location = tablero.casillas[3].posicion;
                amarilla3.Location = tablero.casillas[3].posicion;
                amarilla4.Location = tablero.casillas[3].posicion;
                Torn4Lbl.Visible = true;
                Torn4Lbl.BackColor = Color.Yellow;
                label7.Visible = true;
            }
            panel1.Refresh();
            panel1.Invalidate();
            panel1.SendToBack();
        }
        private void ficha_Final(object sender, EventArgs e)
        {
            MessageBox.Show("Esta ficha ha llegado al final.");
        }

        //Fem que avançi una ficha (Si y solo si, es su turno, y ademas ha lanzado los dados primero)
        private void ficha_Click(object sender, EventArgs e)
        {
            if (this.miTurno == turno)
            {
                if (this.haTirado)
                {
                    PictureBox pic = (PictureBox)sender;
                    int j = (int)pic.Tag;
                    int i = 0;
                    int NouId;
                    //Busco la posicio actual de la ficha
                    while (pic.Location != tablero.casillas[i].posicion)
                    {
                        i++;
                    }
                    tablero.casillas[i].ocupacion--;
                    //Miro el color de la ficha
                    if (colorJugador == Color.Red)
                    {
                        NouId = tablero.casillas[i].idRojo + sumDados;

                        //Comprovamos si la ficha a llegado al final
                        if (NouId >= 73)
                        {
                            NouId = 73;
                            pic.Click += new EventHandler(this.ficha_Final);
                        }
                        //reinicia la vairable i a 0 i aixi no tens que comprobar que arriba al fianl del ficher
                        i = 0;
                        //Busco la cassilla objetivo
                        bool encontrado = false;
                        while (!encontrado)
                        {

                            if (i < tablero.casillas.Length) //Aquest if serveix per comprovar que la i no estigui fora del rang del Array casillas
                            {
                                if (NouId == tablero.casillas[i].idRojo)
                                {
                                    encontrado = true;
                                }
                                else
                                {
                                    i++;
                                }
                            }
                            else
                            {
                                i = 0;
                            }
                        }


                    }
                    else if (colorJugador == Color.Green)
                    {
                        NouId = tablero.casillas[i].idVerde + sumDados;

                        //Comprovamo si la ficha a llegado al final
                        if (NouId >= 73)
                        {
                            NouId = 73;
                            pic.Click += new EventHandler(this.ficha_Final);
                        }
                        //reinicia la vairable i a 0 i aixi no tens que comprobar que arriba al fianl del ficher
                        i = 0;
                        //Busco la cassilla objetivo
                        bool encontrado = false;
                        while (!encontrado)
                        {

                            if (i < tablero.casillas.Length) //Aquest if serveix per comprovar que la i no estigui fora del rang del Array casillas
                            {
                                if (NouId == tablero.casillas[i].idVerde)
                                {
                                    encontrado = true;
                                }
                                else
                                {
                                    i++;
                                }
                            }
                            else
                            {
                                i = 0;
                            }
                        }
                    }
                    else if (colorJugador == Color.Blue)
                    {
                        NouId = tablero.casillas[i].idAzul + sumDados;
                        //Comprovamos si la ficha a llegado al final
                        if (NouId >= 73)
                        {
                            NouId = 73;
                            pic.Click += new EventHandler(this.ficha_Final);
                        }
                        //reinicia la vairable i a 0 i aixi no tens que comprobar que arriba al fianl del ficher
                        i = 0;
                        //Busco la cassilla objetivo
                        bool encontrado = false;
                        while (!encontrado)
                        {

                            if (i < tablero.casillas.Length) //Aquest if serveix per comprovar que la i no estigui fora del rang del Array casillas
                            {
                                if (NouId == tablero.casillas[i].idAzul)
                                {
                                    encontrado = true;
                                }
                                else
                                {
                                    i++;
                                }
                            }
                            else
                            {
                                i = 0;
                            }
                        }
                    }
                    else
                    {
                        NouId = tablero.casillas[i].idAmarillo + sumDados;
                        //Comprovamos si la ficha a llegado al final
                        if (NouId >= 73)
                        {
                            NouId = 73;
                            pic.Click += new EventHandler(this.ficha_Final);
                        }
                        //reinicia la vairable i a 0 i aixi no tens que comprobar que arriba al fianl del ficher
                        i = 0;
                        //Busco la cassilla objetivo
                        bool encontrado = false;
                        while (!encontrado)
                        {

                            if (i < tablero.casillas.Length) //Aquest if serveix per comprovar que la i no estigui fora del rang del Array casillas
                            {
                                if (NouId == tablero.casillas[i].idAmarillo)
                                {
                                    encontrado = true;
                                }
                                else
                                {
                                    i++;
                                }
                            }
                            else
                            {
                                i = 0;
                            }
                        }
                    }
                    //Miramos si podemos eliminar alguna ficha
                    if (tablero.casillas[i].ocupacion >= 2)
                    {
                        OcupacionMayor2(tablero.casillas[i]);
                    }

                    //Ponemos la ficha en la nueva casilla
                    pic.Location = tablero.casillas[i].posicion;
                    tablero.casillas[i].ocupacion++;

                    //Miramos si la partida a acabado
                    AcabaPartida();

                    panel1.Refresh();
                    panel1.Invalidate();
                    panel1.SendToBack();
                    this.haTirado = false;

                    //Preparamos el tablero para el siguiente turno
                    foreach (Casillas cas in tablero.casillas)
                    {
                        cas.ocupacion = 0;
                    }

                    //numServei/num A qui Toca / (indice Fiches Jugador Red (////))/(indice Fiches Jugador Blau (////)(indice Fiches Jugador Groc (////))(indice Fiches Jugador Verd (////))/
                    string mensaje = $"20/{turno}/{nombreAdmin}/{PosFichas()}";
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                }
                else
                {
                    MessageBox.Show("Primero debes tirar los dados.");
                }
            }
            else
            {
                MessageBox.Show("No es tu turno.");
            }
        }

        public void AcabaPartida()
        {
            if (tablero.casillas[79].ocupacion == 4)
            {
                MessageBox.Show("Ha ganado el Rojo!");
                this.partidaTerminada = true;

                //Enviamos el mensaje al servidor del ganador para que el lo ponga a la tabla de SQL y lo envie a los otros jugadores
                //incidce servicio / fecha del juego / nombre del ganador
                string fecha = DateTime.Today.ToString("yyyy/MM/dd");
                string mensaje = $"22/{fecha}-{nombreAdmin}";
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
                this.partidaTerminada = true;
                this.Close();
            }
            else if (tablero.casillas[87].ocupacion == 4)
            {
                MessageBox.Show("Ha ganado el Verde!");
                this.partidaTerminada = true;

                //Enviamos el mensaje al servidor del ganador para que el lo ponga a la tabla de SQL y lo envie a los otros jugadores
                //incidce servicio / fecha del juego / nombre del ganador
                string fecha = DateTime.Today.ToString("yyyy/MM/dd");
                string mensaje = $"22/{fecha}-{nombreAdmin}";
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
                this.partidaTerminada = true;
                this.Close();
            }
            else if (tablero.casillas[95].ocupacion == 4)
            {
                MessageBox.Show("Ha ganado el Azul!");
                this.partidaTerminada = true;

                //Enviamos el mensaje al servidor del ganador para que el lo ponga a la tabla de SQL y lo envie a los otros jugadores
                //incidce servicio / fecha del juego / nombre del ganador
                string fecha = DateTime.Today.ToString("yyyy/MM/dd");
                string mensaje = $"22/{fecha}-{nombreAdmin}";
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
                this.partidaTerminada = true;
                this.Close();
            }
            else if (tablero.casillas[103].ocupacion == 4)
            {
                MessageBox.Show("Ha ganado el Amarillo!");
                this.partidaTerminada = true;

                //Enviamos el mensaje al servidor del ganador para que el lo ponga a la tabla de SQL y lo envie a los otros jugadores
                //incidce servicio / fecha del juego / nombre del ganador

                string fecha = DateTime.Today.ToString("yyyy/MM/dd");
                string mensaje = $"22/{fecha}-{nombreAdmin}";
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
                this.partidaTerminada = true;
                this.Close();
            }
            
        }
        //Buscamos que ficha esta en la misma casilla que nosotros y si es de diferente color la eliminamos
        public void OcupacionMayor2(Casillas casilla)
        {
            bool encontrado = false;
            string linia = PosFichas();
            string[] trozos = linia.Split('/');

            int j = 0;
            //Traspasem la lista de string id a int
            int[] ids = trozos.Select(int.Parse).ToArray();

            j = 0;
            while (!encontrado)
            {
                if (0 <= j && j <= 3 && ids[j] == casilla.idRojo) //Comprovamos si es una ficha Roja
                {
                    encontrado = true;
                    if (colorJugador != Color.Red)
                    {
                        //Buscamos la ficha que esta en el mismo color y la ponemos en la casilla casa
                        if (roja1.Location == casilla.posicion && casilla.casSalvado == false)
                            roja1.Location = tablero.casillas[0].posicion;
                        else if (roja2.Location == casilla.posicion && casilla.casSalvado == false)
                            roja2.Location = tablero.casillas[0].posicion;
                        else if (roja3.Location == casilla.posicion && casilla.casSalvado == false)
                            roja3.Location = tablero.casillas[0].posicion;
                        else if (casilla.casSalvado == false)
                            roja4.Location = tablero.casillas[0].posicion;

                        casilla.ocupacion--;
                        MessageBox.Show("La ficha Roja ha sido eliminada.");
                        return;
                    }
                    else
                    {
                        //Aqui posem lo de posar les fiches en paralel
                        return;
                    }
                }
                else if (4 <= j && j <= 7 && ids[j] == casilla.idVerde) //Comprovamos si es una Ficha Verde
                {
                    encontrado = true;
                    if (colorJugador != Color.Green)
                    {
                        //Buscamos la ficha que esta en el mismo color y la ponemos en la casilla casa
                        if (verde1.Location == casilla.posicion && casilla.casSalvado == false)
                            verde1.Location = tablero.casillas[1].posicion;
                        else if (verde2.Location == casilla.posicion && casilla.casSalvado == false)
                            verde2.Location = tablero.casillas[1].posicion;
                        else if (verde3.Location == casilla.posicion && casilla.casSalvado == false)
                            verde3.Location = tablero.casillas[1].posicion;
                        else if (casilla.casSalvado == false)
                            verde4.Location = tablero.casillas[1].posicion;

                        casilla.ocupacion--;
                        MessageBox.Show("La ficha Verde ha sido eliminada.");
                        return;
                    }
                    else
                    {
                        //Aqui posem lo de posar les fiches en paralel
                        return;
                    }
                }
                else if (8 <= j && j <= 11 && ids[j] == casilla.idAzul) //Comprovamos si es una ficha Azul
                {
                    encontrado = true;
                    if (colorJugador != Color.Blue)
                    {
                        //Buscamos la ficha que esta en el mismo color y la ponemos en la casilla casa
                        if (azul1.Location == casilla.posicion && casilla.casSalvado == false)
                            azul1.Location = tablero.casillas[2].posicion;
                        else if (azul2.Location == casilla.posicion && casilla.casSalvado == false)
                            azul2.Location = tablero.casillas[2].posicion;
                        else if (azul3.Location == casilla.posicion && casilla.casSalvado == false)
                            azul3.Location = tablero.casillas[2].posicion;
                        else if (casilla.casSalvado == false)
                            azul4.Location = tablero.casillas[2].posicion;

                        casilla.ocupacion--;
                        MessageBox.Show("La ficha Azul ha sido eliminada.");
                        return;
                    }
                    else
                    {
                        //Aqui posem lo de posar les fiches en paralel
                        return;
                    }
                }
                else if (12 <= j && j <= 15 && ids[j] == casilla.idAmarillo) //Comprovamos si es una ficha Amarilla
                {
                    encontrado = true;
                    if (colorJugador != Color.Yellow)
                    {
                        //Buscamos la ficha que esta en el mismo color y la ponemos en la casilla casa
                        if (amarilla1.Location == casilla.posicion && casilla.casSalvado == false)
                            amarilla1.Location = tablero.casillas[3].posicion;
                        else if (amarilla2.Location == casilla.posicion && casilla.casSalvado == false)
                            amarilla2.Location = tablero.casillas[3].posicion;
                        else if (amarilla3.Location == casilla.posicion && casilla.casSalvado == false)
                            amarilla3.Location = tablero.casillas[3].posicion;
                        else if (casilla.casSalvado == false)
                            amarilla4.Location = tablero.casillas[3].posicion;

                        casilla.ocupacion--;
                        MessageBox.Show("La ficha Amarilla ha sido eliminada.");
                        return;
                    }
                    else
                    {
                        //Aqui posem lo de posar les fiches en paralel
                        return;
                    }
                }
                else
                {
                    j++;
                }
            }

        }

        //Buscamos la posicion de las fichas
        string PosFichas()
        {
            string indicesFichas;
            int idVerde1 = 0, idVerde2 = 0, idVerde3 = 0, idVerde4 = 0, idAzul1 = 0, idAzul2 = 0, idAzul3 = 0, idAzul4 = 0, idAmarilla1 = 0, idAmarilla2 = 0, idAmarilla3 = 0, idAmarilla4 = 0;
            int i = 0;
            while (roja1.Location != tablero.casillas[i].posicion)
            {
                i++;
            }
            int idRoja1 = tablero.casillas[i].idRojo;


            i = 0;
            while (roja2.Location != tablero.casillas[i].posicion)
            {
                i++;
            }
            int idRoja2 = tablero.casillas[i].idRojo;


            i = 0;
            while (roja3.Location != tablero.casillas[i].posicion)
            {
                i++;
            }
            int idRoja3 = tablero.casillas[i].idRojo;

            i = 0;
            while (roja4.Location != tablero.casillas[i].posicion)
            {
                i++;
            }
            int idRoja4 = tablero.casillas[i].idRojo;


            // Aqui en els condicionals es te que comprovar quants jugadors hi han
            if (numeroJugadores == 4) //es comprova si hi ha 4 jugadors en la partida
            {
                i = 0;
                while (amarilla1.Location != tablero.casillas[i].posicion)
                {
                    i++;
                }
                idAmarilla1 = tablero.casillas[i].idAmarillo;


                i = 0;
                while (amarilla2.Location != tablero.casillas[i].posicion)
                {
                    i++;
                }
                idAmarilla2 = tablero.casillas[i].idAmarillo;


                i = 0;
                while (amarilla3.Location != tablero.casillas[i].posicion)
                {
                    i++;
                }
                idAmarilla3 = tablero.casillas[i].idAmarillo;


                i = 0;
                while (amarilla4.Location != tablero.casillas[i].posicion)
                {
                    i++;
                }
                idAmarilla4 = tablero.casillas[i].idAmarillo;

            }
            if (numeroJugadores >= 3) //es comproba si hi ha 3 jugadors
            {
                i = 0;
                while (azul1.Location != tablero.casillas[i].posicion)
                {
                    i++;
                }
                idAzul1 = tablero.casillas[i].idAzul;


                i = 0;
                while (azul2.Location != tablero.casillas[i].posicion)
                {
                    i++;
                }
                idAzul2 = tablero.casillas[i].idAzul;


                i = 0;
                while (azul3.Location != tablero.casillas[i].posicion)
                {
                    i++;
                }
                idAzul3 = tablero.casillas[i].idAzul;


                i = 0;
                while (amarilla4.Location != tablero.casillas[i].posicion)
                {
                    i++;
                }
                idAzul4 = tablero.casillas[i].idAzul;

            }
            if (numeroJugadores >= 2) //es comprova si hi ha 2 jugadors
            {
                i = 0;
                while (verde1.Location != tablero.casillas[i].posicion)
                {
                    i++;
                }
                idVerde1 = tablero.casillas[i].idVerde;


                i = 0;
                while (verde2.Location != tablero.casillas[i].posicion)
                {
                    i++;
                }
                idVerde2 = tablero.casillas[i].idVerde;


                i = 0;
                while (verde3.Location != tablero.casillas[i].posicion)
                {
                    i++;
                }
                idVerde3 = tablero.casillas[i].idVerde;


                i = 0;
                while (verde4.Location != tablero.casillas[i].posicion)
                {
                    i++;
                }
                idVerde4 = tablero.casillas[i].idVerde;


            }
            indicesFichas = $"{idRoja1}/{idRoja2}/{idRoja3}/{idRoja4}/{idVerde1}/{idVerde2}/{idVerde3}/{idVerde4}/{idAzul1}/{idAzul2}/{idAzul3}/{idAzul4}/{idAmarilla1}/{idAmarilla2}/{idAmarilla3}/{idAmarilla4}";
            return indicesFichas;
        }
        //Aquesta Funcio Tires els Daus Per fer avançar les fitches
        private void TirarDaus_Click_1(object sender, EventArgs e)
        {
            this.haTirado = true;
            teTocaLbl.Visible = false;
            haSalidoLbl.Visible = true;
            TirarDaus.Visible = false;

            sumDados = 0;
            Random rand = new Random();

            dado1 = rand.Next(1, 7);
            dado2 = rand.Next(1, 7);
            sumDados = dado1 + dado2;

            string ruta1 = "dado" + dado1 + ".png";
            string ruta2 = "dado" + dado2 + ".png";

            resultadoDado1.Visible = true;
            resultadoDado2.Visible = true;

            resultadoDado1.Image = Image.FromFile(ruta1);
            resultadoDado1.SizeMode = PictureBoxSizeMode.StretchImage;
            resultadoDado2.Image = Image.FromFile(ruta2);
            resultadoDado2.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        public void EscribirChatJuego(string emisorMensaje, string mensaje)
        {
            mensajesJuegolistBox.Items.Add(emisorMensaje + ": " + mensaje);
        }
        public void NotificarAbandono(string mensaje)
        {
            MessageBox.Show(mensaje + "\nLa partida ha finalizado.");
            this.cierreAutomatico = true;
            this.Close();
            this.formularioSala.Show();
        }
        public void ActualizarJuego(int turno, string posiciones)
        {
            this.turno = turno;
            teTocaLbl.Visible = false;
            haSalidoLbl.Visible = false;
            TirarDaus.Visible = false;
            resultadoDado1.Visible = false;
            resultadoDado2.Visible = false;

            CambiarColorLabelsTurnos();

            ActualizarPosiciones(posiciones);

            panel1.Refresh();
            panel1.Invalidate();
            panel1.SendToBack();

            if (this.miTurno == this.turno)
            {
                TirarDaus.Visible = true;
                teTocaLbl.Visible = true;
            }
        }
        public void CambiarColorLabelsTurnos()
        {
            switch (numeroJugadores)
            {
                case 1:
                    Torn1Lbl.BackColor = Color.Red;
                    break;
                case 2:
                    switch (turno)
                    {
                        case 1:
                            Torn1Lbl.BackColor = Color.Red;
                            Torn2Lbl.BackColor = Color.Green;
                            break;
                        case 2:
                            Torn1Lbl.BackColor = Color.Green;
                            Torn2Lbl.BackColor = Color.Red;
                            break;
                    }
                    break;
                case 3:
                    switch (turno)
                    {
                        case 1:
                            Torn1Lbl.BackColor = Color.Red;
                            Torn2Lbl.BackColor = Color.Green;
                            Torn3Lbl.BackColor = Color.Blue;
                            break;
                        case 2:
                            Torn1Lbl.BackColor = Color.Green;
                            Torn2Lbl.BackColor = Color.Blue;
                            Torn3Lbl.BackColor = Color.Red;
                            break;
                        case 3:
                            Torn1Lbl.BackColor = Color.Blue;
                            Torn2Lbl.BackColor = Color.Red;
                            Torn3Lbl.BackColor = Color.Green;
                            break;
                    }
                    break;
                case 4:
                    switch (turno)
                    {
                        case 1:
                            Torn1Lbl.BackColor = Color.Red;
                            Torn2Lbl.BackColor = Color.Green;
                            Torn3Lbl.BackColor = Color.Blue;
                            Torn4Lbl.BackColor = Color.Yellow;
                            break;
                        case 2:
                            Torn1Lbl.BackColor = Color.Green;
                            Torn2Lbl.BackColor = Color.Blue;
                            Torn3Lbl.BackColor = Color.Yellow;
                            Torn4Lbl.BackColor = Color.Red;
                            break;
                        case 3:
                            Torn1Lbl.BackColor = Color.Blue;
                            Torn2Lbl.BackColor = Color.Yellow;
                            Torn3Lbl.BackColor = Color.Red;
                            Torn4Lbl.BackColor = Color.Green;
                            break;
                        case 4:
                            Torn1Lbl.BackColor = Color.Yellow;
                            Torn2Lbl.BackColor = Color.Red;
                            Torn3Lbl.BackColor = Color.Green;
                            Torn4Lbl.BackColor = Color.Blue;
                            break;
                    }
                    break;
            }
        }

        //En esta funcion actualizamos en el panel las posiciones de los pictures box que recibimos del Server
        void ActualizarPosiciones(string nouIdFichas)
        {
            string[] trozos = nouIdFichas.Split('|');
            int i = 0;
            int[] ids = trozos.Select(int.Parse).ToArray();

            //Actualitzem al posicio de les fiches
            //fiches rojas
            while (ids[0] != tablero.casillas[i].idRojo)
            {
                i++;
            }
            roja1.Location = tablero.casillas[i].posicion;
            tablero.casillas[i].ocupacion++;
            i = 0;
            while (ids[1] != tablero.casillas[i].idRojo)
            {
                i++;
            }
            roja2.Location = tablero.casillas[i].posicion;
            tablero.casillas[i].ocupacion++;
            i = 0;
            while (ids[2] != tablero.casillas[i].idRojo)
            {
                i++;
            }
            roja3.Location = tablero.casillas[i].posicion;
            tablero.casillas[i].ocupacion++;
            i = 0;
            while (ids[3] != tablero.casillas[i].idRojo)
            {
                i++;
            }
            roja4.Location = tablero.casillas[i].posicion;
            tablero.casillas[i].ocupacion++;
            i = 0;

            //fichas verdes
            if (numeroJugadores >= 2)
            {
                while (ids[4] != tablero.casillas[i].idVerde)
                {
                    i++;
                }
                verde1.Location = tablero.casillas[i].posicion;
                tablero.casillas[i].ocupacion++;
                i = 0;
                while (ids[5] != tablero.casillas[i].idVerde)
                {
                    i++;
                }
                verde2.Location = tablero.casillas[i].posicion;
                tablero.casillas[i].ocupacion++;
                i = 0;
                while (ids[6] != tablero.casillas[i].idVerde)
                {
                    i++;
                }
                verde3.Location = tablero.casillas[i].posicion;
                tablero.casillas[i].ocupacion++;
                i = 0;
                while (ids[7] != tablero.casillas[i].idVerde)
                {
                    i++;
                }
                verde4.Location = tablero.casillas[i].posicion;
                tablero.casillas[i].ocupacion++;
                i = 0;
            }


            //fichas blaves
            if (numeroJugadores >= 3)
            {
                while (ids[8] != tablero.casillas[i].idAzul)
                {
                    i++;
                }
                azul1.Location = tablero.casillas[i].posicion;
                tablero.casillas[i].ocupacion++;
                i = 0;
                while (ids[9] != tablero.casillas[i].idAzul)
                {
                    i++;
                }
                azul2.Location = tablero.casillas[i].posicion;
                tablero.casillas[i].ocupacion++;
                i = 0;
                while (ids[10] != tablero.casillas[i].idAzul)
                {
                    i++;
                }
                azul3.Location = tablero.casillas[i].posicion;
                tablero.casillas[i].ocupacion++;
                i = 0;
                while (ids[11] != tablero.casillas[i].idAzul)
                {
                    i++;
                }
                azul4.Location = tablero.casillas[i].posicion;
                tablero.casillas[i].ocupacion++;
                i = 0;
            }


            //fichas Amarillas
            if (numeroJugadores == 4)
            {
                while (ids[12] != tablero.casillas[i].idAmarillo)
                {
                    i++;
                }
                amarilla1.Location = tablero.casillas[i].posicion;
                tablero.casillas[i].ocupacion++;
                i = 0;
                while (ids[13] != tablero.casillas[i].idAmarillo)
                {
                    i++;
                }
                amarilla2.Location = tablero.casillas[i].posicion;
                tablero.casillas[i].ocupacion++;
                i = 0;
                while (ids[14] != tablero.casillas[i].idAmarillo)
                {
                    i++;
                }
                amarilla3.Location = tablero.casillas[i].posicion;
                tablero.casillas[i].ocupacion++;
                i = 0;
                while (ids[15] != tablero.casillas[i].idAmarillo)
                {
                    i++;
                }
                amarilla4.Location = tablero.casillas[i].posicion;
            }            
        }

        private void FormTablero_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.partidaTerminada)
            {
                MessageBox.Show("La partida ha terminado.");
                this.Hide();
                this.formularioSala.Show();
            }
            else
            {
                if (!this.cierreAutomatico)
                {
                    DialogResult result = MessageBox.Show("La partida no ha terminado aún." + "\n¿Deseas terminar?", "Terminar partida", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        string mensaje = $"21/{nombreUsuario}/{nombreAdmin}";

                        byte[] msg = Encoding.ASCII.GetBytes(mensaje);
                        server.Send(msg);
                    }
                    else
                    {
                        MessageBox.Show("La partida no ha terminado aún.");
                        e.Cancel = true; // Cancela el cierre del formulario
                        return;
                    }
                }
            }
        }
        private void enviarMensajeJuegoBtn_Click(object sender, EventArgs e)
        {
            string texto = escribirMensajesJuegoTextBox.Text;

            if (texto.Replace(" ", "").Length > 0)
            {
                if (texto.Length <= 500)
                {
                    //Envío a la base de datos los datos introducidos
                    string mensaje = $"11/1/{nombreAdmin}/{nombreUsuario}/{texto}";

                    // Enviamos al servidor los datos tecleados
                    byte[] msg = Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);

                    escribirMensajesJuegoTextBox.Text = "";
                }
                else MessageBox.Show("El mensaje excede el límite de caracteres. (máx. 500 caracteres)");
            }
            else MessageBox.Show("Debes escribir algo.");
        }
    }
}
