# SimStradaC
Simulazione traffico con semaforo

Assunti:
- non sono consentiti i sorpassi
- non si possono passare i limiti
- il guidatore può leggere la velocità del veicolo che precede
- moto uniformemente accelerato

Configurazione (Costanti.cs):

DatiGenerali

1. Semaforo
    * // [s]
    * DurataRosso = 60; 
    * DurataGiallo = 20; 
    * DurataVerde = 60;
    * DurataRitardo = 60;
2. Simulazione
    * // [s]
    * Intervallo = 1; 
3. GuidatoreTipologia
    * Normale
    * // [s]
    * TempoReazione = 1;
    * // [%]
    * Accelerazione = 0.70;
    * Decelerazione = 0.70;
    * Velocità = 0.70;
    * // [m]
    * DistanzaSicurezza = 3;
    * DistanzaFermi = 1.5;
    * // [m]
    * DistanzaVisione = 50;
    * Prudente
{
    // [s]
    TempoReazione = 0.85;
    // [%]
    Accelerazione = 0.65;
    Decelerazione = 0.75;
    Velocità = 0.65;
    // [m]
    DistanzaSicurezza = 15;
    DistanzaFermi = 1.5;
    // [m]
    DistanzaVisione = 60;
}
public struct Lento
{
    // [s]
    TempoReazione = 1.5;
    // [%]
    Accelerazione = 0.60;
    Decelerazione = 0.60;
    Velocità = 0.50;
    // [m]
    DistanzaSicurezza = 15;
    DistanzaFermi = 1;
    // [m]
    DistanzaVisione = 40;
}
public struct Brusco
{
    // [s]
    TempoReazione = 1;
    // [%]
    Accelerazione = 0.80;
    Decelerazione = 0.85;
    Velocità = 0.85;
    // [m]
    DistanzaSicurezza = 2;
    DistanzaFermi = 1;
    // [m]
    DistanzaVisione = 50;
}
        }
        public struct VeicoloTipologia
        {
            public struct Camion
            {
                // [m/s^2]
                AccelerazioneMax = 2;
                DecelerazioneMax = 5.5;
                // [m/s]
                VelocitàMax = 41;
                // [m]
                Lunghezza = 10;
                Larghezza = 2.5;
            }

            public struct Macchina
            {
                // [m/s^2]
                AccelerazioneMax = 2.75;
                DecelerazioneMax = 6.5;
                // [m/s]
                VelocitàMax = 55;
                // [m]
                Lunghezza = 5;
                Larghezza = 1.8;
            }

            public struct Moto
            {
                // [m/s^2]
                AccelerazioneMax = 9;
                DecelerazioneMax = 7;
                // [m/s]
                VelocitàMax = 66;
                // [m]
                Lunghezza = 1.8;
                Larghezza = 1;
            }
        }

        public struct Traffico
        {
            public struct Afflusso
            {
                // [macchine/sec]
                velocitàDX = 0.25;
                velocitàSX = 0.20;
                // [%]
                variazioneDX = 0.30;
                variazioneSX = 0.30;
            }
            public struct Tipologia
            {
                // [%] - Somma deve dare 1
                percentualeMoto = 0.15;
                percentualeMacchine = 0.65;
                percentualeCamion = 0.20;
            }
        }

        public struct StradaMisure
        {
            // [m/s] 
            // km/h in m/s -> x1000/3600
            velocitàMaxPercorrenza = 13.88;
            // [m]
            distanzaSemafori = 120;
            distanzaStradaDX = 200;
            distanzaStradaSX = 200;
        }
        
    }
    
}
