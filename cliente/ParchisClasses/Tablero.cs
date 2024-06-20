using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace ParchisClassLibrary1
{
    public class Tablero
    {
        public Casillas[] casillas;

        public Tablero()
        {
            //Creamos el tablero
            casillas = new Casillas[104];
            StreamReader sR = new StreamReader("Coordenadas_Casillas.txt");
            
            string linia = sR.ReadLine();
            string[] trozos;
            int indice = 0;
            while (linia != "" && linia != null)
            {
                Casillas casilla = new Casillas();
                trozos = linia.Split('/');
                casilla.posicion = new Point(Convert.ToInt32(trozos[0]), Convert.ToInt32(trozos[1]));
                casilla.idRojo = Convert.ToInt32(trozos[2]);
                casilla.idVerde = Convert.ToInt32(trozos[3]);
                casilla.idAzul = Convert.ToInt32(trozos[4]);
                casilla.idAmarillo = Convert.ToInt32(trozos[5]);
                if (indice >= 0 && indice <= 3)
                {
                    casilla.ocupacion = 4;
                }
                else
                {
                    casilla.ocupacion = 0;
                }
                if (trozos[6] == "S")
                {
                    casilla.casSalvado = true;
                }

                casillas[indice] = casilla;
                indice++;
                linia = sR.ReadLine();
            }
            sR.Close();
        }
    }
}
