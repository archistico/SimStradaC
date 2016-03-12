using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimStradaC
{
    class CorsiaParte
    {
        private double velocitàMassima;
        private double lunghezza;
        private double larghezza;

        public double VelocitàMassima
        {
            get
            { return velocitàMassima; }
            set
            { velocitàMassima = value; }
        }

        public double Lunghezza
        {
            get
            { return lunghezza; }
            set
            { lunghezza = value; }
        }

        public double Larghezza
        {
            get
            { return larghezza; }
            set
            { larghezza = value; }
        }

        public CorsiaParte(double _velocitàMassima, double _lunghezza, double _larghezza)
        {
            velocitàMassima = _velocitàMassima;
            lunghezza = _lunghezza;
            larghezza = _larghezza;
        }
    }
}
