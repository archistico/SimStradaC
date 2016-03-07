using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimStradaC
{
    class Veicolo
    {
        private Guidatore guidatore;
        private VeicoloTipologia veicoloTipologia;
        private Veicolo veicoloPrecede;

        public double accelerazioneMax;
        public double decelerazioneMax;
        public double velocitàMax;

        public double velocità;
        public double posizioneX;

        private enum MarciaTipologia { Fermo, Accelerazione, Crociera, Decelerazione };
        public enum AzioneTipologia { Accellera, Frena, Mantieni };

        private void SetParametriGenerali()
        {
            if (veicoloTipologia == VeicoloTipologia.Camion)
            {
                accelerazioneMax = DatiGenerali.VeicoloTipologia.Camion.AccelerazioneMax * guidatore.PercentualeAccelerazione;
                decelerazioneMax = DatiGenerali.VeicoloTipologia.Camion.DecelerazioneMax * guidatore.PercentualeDecelerazione;
                velocitàMax = DatiGenerali.VeicoloTipologia.Camion.VelocitàMax * guidatore.PercentualeVelocità;
            }
            else if (veicoloTipologia == VeicoloTipologia.Macchina)
            {
                accelerazioneMax = DatiGenerali.VeicoloTipologia.Macchina.AccelerazioneMax * guidatore.PercentualeAccelerazione;
                decelerazioneMax = DatiGenerali.VeicoloTipologia.Macchina.DecelerazioneMax * guidatore.PercentualeDecelerazione;
                velocitàMax = DatiGenerali.VeicoloTipologia.Macchina.VelocitàMax * guidatore.PercentualeVelocità;
            }
            else if (veicoloTipologia == VeicoloTipologia.Moto)
            {
                accelerazioneMax = DatiGenerali.VeicoloTipologia.Moto.AccelerazioneMax * guidatore.PercentualeAccelerazione;
                decelerazioneMax = DatiGenerali.VeicoloTipologia.Moto.DecelerazioneMax * guidatore.PercentualeDecelerazione;
                velocitàMax = DatiGenerali.VeicoloTipologia.Moto.VelocitàMax * guidatore.PercentualeVelocità;
            }
            else
            {
                accelerazioneMax = 0;
                decelerazioneMax = 0;
                velocitàMax = 0;
            }
        }
        
        public Veicolo(VeicoloTipologia _veicoloTipologia, Guidatore _guidatore, StradaDirezione _stradaDirezione, Veicolo _veicoloPrecede)
        {
            veicoloTipologia = _veicoloTipologia;
            guidatore = _guidatore;
            veicoloPrecede = _veicoloPrecede;

            SetParametriGenerali();
        }

        public Veicolo(VeicoloTipologia _veicoloTipologia, Guidatore _guidatore, StradaDirezione _stradaDirezione)
        {
            veicoloTipologia = _veicoloTipologia;
            guidatore = _guidatore;
            veicoloPrecede = null;

            SetParametriGenerali();
        }

        public void Azione(AzioneTipologia azione)
        {
            if (azione == AzioneTipologia.Mantieni)
            {
                // Stessa velocità precedente
                posizioneX = Math.Round(posizioneX + velocità * DatiGenerali.Simulazione.Intervallo, 2);
            }
            else if (azione == AzioneTipologia.Accellera)
            {
                posizioneX = Math.Round(posizioneX + velocità * DatiGenerali.Simulazione.Intervallo + 0.5 * accelerazioneMax * Math.Pow(DatiGenerali.Simulazione.Intervallo, 2), 2);
                velocità = Math.Round(velocità + accelerazioneMax * DatiGenerali.Simulazione.Intervallo, 2);
            }
            else if (azione == AzioneTipologia.Frena)
            {
                posizioneX = Math.Round(posizioneX + velocità * DatiGenerali.Simulazione.Intervallo - 0.5 * decelerazioneMax * Math.Pow(DatiGenerali.Simulazione.Intervallo, 2), 2);
                if (velocità - decelerazioneMax * DatiGenerali.Simulazione.Intervallo >= 0)
                    velocità = Math.Round(velocità - decelerazioneMax * DatiGenerali.Simulazione.Intervallo, 2);
                else
                    velocità = 0;
            }
                        
        }
    }
}
