using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParchisClassLibrary1
{
    public class FichasJugador
    {


        public int idFicha;
        public int posFicha;
        public bool aSalvo;
        public bool llegadoMeta;
        public bool estaInicio;
        public Color colorJugador = new Color();

        //En este Metodo creamos el objeto ficha del Usuario
        public FichasJugador(Color color, int id)
        {
            colorJugador = color;
            idFicha = id;

            if (colorJugador == Color.Yellow)
            {
                posFicha = 1;
            }
            else if (colorJugador == Color.Blue)
            {
                posFicha = 2;
            }
            else if (colorJugador == Color.Red)
            {
                posFicha = 3;
            }
            else if (posFicha == 0)
            {
                posFicha = 4;
            }

        }



        //Con este metodo movemos la ficha por el tablero
        public int ContadorCasillas(int sumDados)
        {
            posFicha += sumDados;


            return posFicha;
        }



    }
}
