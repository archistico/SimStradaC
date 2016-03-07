using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimStradaC
{
    public static class Utilita
    {
        public static double ApprossimaMaggiore(double valore, int step)
        {
            double risultato = Math.Round(valore/(double)step)*step;
            if (risultato < valore)
            {
                risultato += step;
            }
            return risultato;
        }
    }
}
