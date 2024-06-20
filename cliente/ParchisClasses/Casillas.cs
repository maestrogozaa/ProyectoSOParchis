using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ParchisClassLibrary1
{
    public class Casillas
    {
        //Caractiristicas de una sola casilla
        public int idRojo, idVerde, idAzul, idAmarillo;
        public int ocupacion;
        public bool casSalvado;
        public Point posicion = new Point();
    }
}
