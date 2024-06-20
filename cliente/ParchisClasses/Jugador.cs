using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ParchisClassLibrary1
{
    public class Jugador
    {
        public FichasJugador[] fichas = new FichasJugador[4];

        public Jugador(Color color)
        {
            for (int i = 0; i < 4; i++)
            {
                fichas[i] = new FichasJugador(color, i + 1);
            }
        }
    }
}
