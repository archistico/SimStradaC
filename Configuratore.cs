using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SimStradaC
{
    static class Configuratore
    {
        // <summary>Calcolo del tempo minimo di percorrenza</summary>
        static public double TempoMinimoPercorrenza(double _lunghezzaTratto, VeicoloTipologia _veicoloTipologia, GuidatoreTipologia _guidatoreTipologia, double _velocitaMassimaConsentita)
        {
            // Due casi
            // - il veicolo passa il tratto di strada quando è ancora in accelerazione
            // - il veicolo ha tempo di accelerare e mantenere la velocità massima fino alla fine del tratto

            double Vi = 0;
            double Vf = _velocitaMassimaConsentita;
            double a = 0;
            double tempoReazione = 0;
            double velocitaMaxVeicolo = 0;

            switch (_veicoloTipologia)
            {
                case VeicoloTipologia.Camion:
                    a = DatiGenerali.VeicoloTipologia.Camion.AccelerazioneMax;
                    velocitaMaxVeicolo = DatiGenerali.VeicoloTipologia.Camion.VelocitàMax;
                    break;
                case VeicoloTipologia.Macchina:
                    a = DatiGenerali.VeicoloTipologia.Macchina.AccelerazioneMax;
                    velocitaMaxVeicolo = DatiGenerali.VeicoloTipologia.Macchina.VelocitàMax;
                    break;
                case VeicoloTipologia.Moto:
                    a = DatiGenerali.VeicoloTipologia.Moto.AccelerazioneMax;
                    velocitaMaxVeicolo = DatiGenerali.VeicoloTipologia.Macchina.VelocitàMax;
                    break;
            }

            switch (_guidatoreTipologia)
            {
                case GuidatoreTipologia.Brusco:
                    a = a * DatiGenerali.GuidatoreTipologia.Brusco.Accelerazione;
                    tempoReazione = DatiGenerali.GuidatoreTipologia.Brusco.TempoReazione;
                    velocitaMaxVeicolo = velocitaMaxVeicolo * DatiGenerali.GuidatoreTipologia.Brusco.Velocità;
                    break;
                case GuidatoreTipologia.Lento:
                    a = a * DatiGenerali.GuidatoreTipologia.Lento.Accelerazione;
                    tempoReazione = DatiGenerali.GuidatoreTipologia.Lento.TempoReazione;
                    velocitaMaxVeicolo = velocitaMaxVeicolo * DatiGenerali.GuidatoreTipologia.Lento.Velocità;
                    break;
                case GuidatoreTipologia.Normale:
                    a = a * DatiGenerali.GuidatoreTipologia.Normale.Accelerazione;
                    tempoReazione = DatiGenerali.GuidatoreTipologia.Normale.TempoReazione;
                    velocitaMaxVeicolo = velocitaMaxVeicolo * DatiGenerali.GuidatoreTipologia.Normale.Velocità;
                    break;
                case GuidatoreTipologia.Prudente:
                    a = a * DatiGenerali.GuidatoreTipologia.Prudente.Accelerazione;
                    tempoReazione = DatiGenerali.GuidatoreTipologia.Prudente.TempoReazione;
                    velocitaMaxVeicolo = velocitaMaxVeicolo * DatiGenerali.GuidatoreTipologia.Prudente.Velocità;
                    break;
            }

            // Se la velocità massima consentita non è possibile raggiungerla con il veicolo allora 
            // imposto la velocità di percorrenza quella massima del veicolo
            if (Vf > velocitaMaxVeicolo)
            {
                Vf = velocitaMaxVeicolo;
            }

            double spazioPercorso = (Math.Pow(Vf, 2)- Math.Pow(Vi, 2)) / (2* a);
            double spazioRimanente = _lunghezzaTratto - spazioPercorso;
            double tempoImpiegato = 0;
            double tempoAccelerazione = 0;
            double tempoUniforme = 0;

            if (spazioRimanente > 0)
            {
                // Ho tempo di accelerare e poi continuare in moto uniforme
                tempoAccelerazione = (Vf - Vi) / a;
                tempoUniforme = spazioRimanente / Vf;
                tempoImpiegato = tempoAccelerazione + tempoUniforme;
            }
            else
            {
                // Sto ancora accelerando quando ho già percorso tutto il tratto
                tempoAccelerazione = Math.Sqrt((2 * _lunghezzaTratto / a));
                tempoImpiegato = tempoAccelerazione;
            }

            #if DEBUG
            Debug.WriteLine("-------------------------");
            Debug.WriteLine("CALCOLO TEMPO PERCORRENZA");
            Debug.WriteLine("Lunghezza tratto: " + Math.Round(_lunghezzaTratto, 2));
            Debug.WriteLine("Vf: " +Math.Round(Vf, 2));
            Debug.WriteLine("Vi: " + Math.Round(Vi, 2));
            Debug.WriteLine("a: " + Math.Round(a, 2));
            Debug.WriteLine("Tipologia di calcolo: " + ((Math.Round(spazioRimanente, 2)>0) ?"Accelerato + Uniforme":"Accelerato"));
            Debug.WriteLine("Spazio Percorso in accelerazione: " + Math.Round(spazioPercorso, 2));
            Debug.WriteLine("Spazio Rimanente: " + Math.Round(spazioRimanente, 2));
            Debug.WriteLine("Tempo reazione (non considerato): " + Math.Round(tempoReazione, 2));
            Debug.WriteLine("Tempo accelerazione: " + Math.Round(tempoAccelerazione, 2));
            Debug.WriteLine("Tempo velocità uniforme: " + Math.Round(tempoUniforme, 2));
            Debug.WriteLine("Tempo impiegato totale: " + Math.Round(tempoImpiegato, 2));
            #endif

            // Risultato in secondi del tempo impiegato per un veicolo 
            // che parte da fermo per percorrere il tratto di strada
            return tempoImpiegato;
        }
    }
}
