using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimStradaC
{
    public enum VeicoloTipologia { Camion, Macchina, Moto };
    public enum GuidatoreTipologia { Normale, Prudente, Lento, Brusco };
    public enum SemaforoLuce { Verde, Giallo, Rosso }
    public enum CorsiaDirezione { DX, SX }

    static public class Converti
    {
        static public double ToMS(double kmh)
        {
            return Math.Round(kmh * 1000 / 3600, 2);
        }

        static public double ToKMH(double ms)
        {
            return Math.Round(ms * 3600 / 1000, 2);
        }

        static public string FormatoHMS(double secondi)
        {
            double _secondi = secondi % 60;
            int minuti = (int)((secondi / 60)%60);
            int ore = (int)secondi/3600;

            return string.Format("{0:00}:{1:00}:{2:F2}", ore, minuti, Math.Round(_secondi, 2));
        }
    }

    static public class Tempo
    {
        static private double _ora;

        static public double Ora
        {
            get { return Math.Round(_ora, 2); }
            set { _ora = value; }
        }
    }

    public struct DatiGenerali
    {
        public struct Semaforo
        {
            // [s]
            public const double DurataGiallo = 10;
            public const double DurataVerde = 45;
            public const double DurataSovrapposizioneRosso = 15;
            public const double DurataSicurezza = 5;

            public const double DurataRosso = DurataVerde+DurataGiallo+2*DurataSovrapposizioneRosso;
        }

        public struct Simulazione
        {
            // [s]
            public const double Intervallo = 1;
        }

            public struct GuidatoreTipologia
        {
            public struct Normale
            {
                // [s]
                public const double TempoReazione = 1;
                // [%]
                public const double Accelerazione = 0.70;
                public const double Decelerazione = 0.70;
                public const double Velocità = 0.70;
                // [m]
                public const double DistanzaSicurezza = 3;
                public const double DistanzaFermi = 1.5;
                // [m]
                public const double DistanzaVisione = 50;
            }
            public struct Prudente
            {
                // [s]
                public const double TempoReazione = 0.85;
                // [%]
                public const double Accelerazione = 0.65;
                public const double Decelerazione = 0.75;
                public const double Velocità = 0.65;
                // [m]
                public const double DistanzaSicurezza = 15;
                public const double DistanzaFermi = 1.5;
                // [m]
                public const double DistanzaVisione = 60;
            }
            public struct Lento
            {
                // [s]
                public const double TempoReazione = 1.5;
                // [%]
                public const double Accelerazione = 0.60;
                public const double Decelerazione = 0.60;
                public const double Velocità = 0.50;
                // [m]
                public const double DistanzaSicurezza = 15;
                public const double DistanzaFermi = 1;
                // [m]
                public const double DistanzaVisione = 40;
            }
            public struct Brusco
            {
                // [s]
                public const double TempoReazione = 1;
                // [%]
                public const double Accelerazione = 0.80;
                public const double Decelerazione = 0.85;
                public const double Velocità = 0.85;
                // [m]
                public const double DistanzaSicurezza = 2;
                public const double DistanzaFermi = 1;
                // [m]
                public const double DistanzaVisione = 50;
            }
        }
        public struct VeicoloTipologia
        {
            public struct Camion
            {
                // [m/s^2]
                public const double AccelerazioneMax = 0.75;
                public const double DecelerazioneMax = 5.5;
                // [m/s]
                public const double VelocitàMax = 41;
                // [m]
                public const double Lunghezza = 10;
                public const double Larghezza = 2.5;
            }

            public struct Macchina
            {
                // [m/s^2]
                public const double AccelerazioneMax = 2.85;
                public const double DecelerazioneMax = 9;
                // [m/s]
                public const double VelocitàMax = 55;
                // [m]
                public const double Lunghezza = 5;
                public const double Larghezza = 1.8;
            }

            public struct Moto
            {
                // [m/s^2]
                public const double AccelerazioneMax = 6.25;
                public const double DecelerazioneMax = 6.5;
                // [m/s]
                public const double VelocitàMax = 66;
                // [m]
                public const double Lunghezza = 1.8;
                public const double Larghezza = 1;
            }
        }

        public struct Traffico
        {
            public struct Afflusso
            {
                // [macchine/sec]
                public const double velocitàDX = 0.25;
                public const double velocitàSX = 0.20;
                // [%]
                public const double variazioneDX = 0.30;
                public const double variazioneSX = 0.30;
            }
            public struct Tipologia
            {
                // [%] - Somma deve dare 1
                public const double percentualeMoto = 0.15;
                public const double percentualeMacchine = 0.65;
                public const double percentualeCamion = 0.20;
            }
        }

        public struct StradaMisure
        {
            // [m/s] 
            // km/h in m/s -> x1000/3600
            public const double velocitàMaxPercorrenza = 13.88;
            // [m]
            public const double distanzaSemafori = 120;
            public const double distanzaStradaDX = 200;
            public const double distanzaStradaSX = 200;
        }
        
    }
    
}
