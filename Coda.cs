using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimStradaC
{
    class Coda
    {
        private Queue<Veicolo> coda;
            
        public Queue<Veicolo> codaVeicoli
        {
            get { return coda; }
            set { coda = value; }
        }
        
        public Coda(Queue<Veicolo> _coda)
        {
            coda = _coda;
        }

        //public struct Traffico
        //{
        //    public struct Afflusso
        //    {
        //        // [macchine/sec]
        //        public const double frequenzaDX = 0.25;
        //        public const double frequenzaSX = 0.20;
        //        // [%]
        //        public const double variazioneDX = 0.30;
        //        public const double variazioneSX = 0.30;
        //    }
        //    public struct Tipologia
        //    {
        //        // [%] - Somma deve dare 1
        //        public const double percentualeMoto = 0.15;
        //        public const double percentualeMacchine = 0.65;
        //        public const double percentualeCamion = 0.20;
        //    }
        //}
    }
}
