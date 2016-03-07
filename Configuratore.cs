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
        static public double TempoPercorrenza(double _lunghezzaTratto, VeicoloTipologia _veicoloTipologia, GuidatoreTipologia _guidatoreTipologia, double _velocitaMassimaConsentita)
        {
            // Due casi
            // - il veicolo passa il tratto di strada quando è ancora in accelerazione
            // - il veicolo ha tempo di accelerare e mantenere la velocità massima fino alla fine del tratto
            // Verificare anche che il veicolo possa raggiungere quella velocità

            double Vi = 0;
            double Vf = _velocitaMassimaConsentita;
            double a = 0;
            double tempoReazione = 0;

            switch (_veicoloTipologia)
            {
                case VeicoloTipologia.Camion:
                    a = DatiGenerali.VeicoloTipologia.Camion.AccelerazioneMax;
                    break;
                case VeicoloTipologia.Macchina:
                    a = DatiGenerali.VeicoloTipologia.Macchina.AccelerazioneMax;
                    break;
                case VeicoloTipologia.Moto:
                    a = DatiGenerali.VeicoloTipologia.Moto.AccelerazioneMax;
                    break;
            }

            switch (_guidatoreTipologia)
            {
                case GuidatoreTipologia.Brusco:
                    a = a * DatiGenerali.GuidatoreTipologia.Brusco.Accelerazione;
                    tempoReazione = DatiGenerali.GuidatoreTipologia.Brusco.TempoReazione;
                    break;
                case GuidatoreTipologia.Lento:
                    a = a * DatiGenerali.GuidatoreTipologia.Lento.Accelerazione;
                    tempoReazione = DatiGenerali.GuidatoreTipologia.Lento.TempoReazione;
                    break;
                case GuidatoreTipologia.Normale:
                    a = a * DatiGenerali.GuidatoreTipologia.Normale.Accelerazione;
                    tempoReazione = DatiGenerali.GuidatoreTipologia.Normale.TempoReazione;
                    break;
                case GuidatoreTipologia.Prudente:
                    a = a * DatiGenerali.GuidatoreTipologia.Prudente.Accelerazione;
                    tempoReazione = DatiGenerali.GuidatoreTipologia.Prudente.TempoReazione;
                    break;
            }

            double spazioPercorso = (Math.Pow(Vf, 2)- Math.Pow(Vi, 2)) / (2* a);
            double spazioRimanente = _lunghezzaTratto - spazioPercorso;
            double tempoImpiegato = 0;
            double tempoAccelerazione = 0;
            double tempoUniforme = 0;
            string tipologiaUscita;

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

            // Risultato in secondi del tempo impiegato per un veicolo 
            // che parte da fermo per percorrere il tratto di strada
            return tempoImpiegato;
        }
    }
}
