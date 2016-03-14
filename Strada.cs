using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SimStradaC
{
    class Strada
    {
        private Corsia corsiaDX;
        private Corsia corsiaSX;
        private Semaforo semaforoDX;
        private Semaforo semaforoSX;

        public Strada(Corsia corsiadx, Corsia corsiasx, Semaforo semaforodx, Semaforo semaforosx)
        {
            corsiaDX = corsiadx;
            corsiaSX = corsiasx;

            if (corsiaDX.Lunghezza() != corsiaSX.Lunghezza())
            {
                throw new StradaException("Le corsie devono avere la stessa lunghezza");
            }

            semaforoDX = semaforodx;
            semaforoSX = semaforosx;

            Debug.WriteLine("---------------------------------------------------");
            Debug.WriteLine("Semaforo DX - posizione: " + Math.Round(semaforoDX.posizioneX,2));
            Debug.WriteLine("Semaforo SX - posizione: " + Math.Round(semaforoSX.posizioneX, 2));
        }

        public double Lunghezza()
        {
            return corsiaDX.Lunghezza();
        }
    }

    public class StradaException : Exception
    {
        public StradaException(string message)
            : base(message)
        {
        }
    }
}
