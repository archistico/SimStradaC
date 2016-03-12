using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimStradaC
{
    class Corsia
    {
        private List<CorsiaParte> corsia;
        
        public List<CorsiaParte> Lista
        {
            get
            { return corsia; }
            set
            { corsia = value; }
        }

        public double Lunghezza()
        {
            double risultato = 0;
            foreach (CorsiaParte c in corsia)
            {
                risultato += c.Lunghezza;
            }

            return risultato;
        }

        public Corsia(List<CorsiaParte> _corsiaLista)
        {
            corsia = _corsiaLista;
        }
    }
}
