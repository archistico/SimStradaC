using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimStradaC
{
    class Strada
    {
        private Corsia corsiaDX;
        private Corsia corsiaSX;

        public Strada(Corsia corsiadx, Corsia corsiasx)
        {
            corsiaDX = corsiadx;
            corsiaSX = corsiasx;

            if (corsiaDX.Lunghezza() != corsiaSX.Lunghezza())
            {
                throw new StradaException("Le corsie devono avere la stessa lunghezza");
            }
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
