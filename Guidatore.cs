using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimStradaC
{
    class Guidatore
    {
        public readonly GuidatoreTipologia tipologia;
        public double PercentualeAccelerazione;
        public double PercentualeDecelerazione;
        public double PercentualeVelocità;
        public double TempoReazione;
        public double DistanzaSicurezza;
        public double DistanzaFermi;

        public Guidatore(GuidatoreTipologia _tipologia)
        {
            tipologia = _tipologia;
            if (tipologia == GuidatoreTipologia.Normale)
            {
                PercentualeAccelerazione = DatiGenerali.GuidatoreTipologia.Normale.Accelerazione;
                PercentualeDecelerazione = DatiGenerali.GuidatoreTipologia.Normale.Decelerazione;
                PercentualeVelocità = DatiGenerali.GuidatoreTipologia.Normale.Velocità;
                TempoReazione = DatiGenerali.GuidatoreTipologia.Normale.TempoReazione;
                DistanzaSicurezza = DatiGenerali.GuidatoreTipologia.Normale.DistanzaSicurezza;
                DistanzaFermi = DatiGenerali.GuidatoreTipologia.Normale.DistanzaFermi;
            }
            else if (tipologia == GuidatoreTipologia.Lento)
            {
                PercentualeAccelerazione = DatiGenerali.GuidatoreTipologia.Lento.Accelerazione;
                PercentualeDecelerazione = DatiGenerali.GuidatoreTipologia.Lento.Decelerazione;
                PercentualeVelocità = DatiGenerali.GuidatoreTipologia.Lento.Velocità;
                TempoReazione = DatiGenerali.GuidatoreTipologia.Lento.TempoReazione;
                DistanzaSicurezza = DatiGenerali.GuidatoreTipologia.Lento.DistanzaSicurezza;
                DistanzaFermi = DatiGenerali.GuidatoreTipologia.Lento.DistanzaFermi;
            }
            else if (tipologia == GuidatoreTipologia.Brusco)
            {
                PercentualeAccelerazione = DatiGenerali.GuidatoreTipologia.Brusco.Accelerazione;
                PercentualeDecelerazione = DatiGenerali.GuidatoreTipologia.Brusco.Decelerazione;
                PercentualeVelocità = DatiGenerali.GuidatoreTipologia.Brusco.Velocità;
                TempoReazione = DatiGenerali.GuidatoreTipologia.Brusco.TempoReazione;
                DistanzaSicurezza = DatiGenerali.GuidatoreTipologia.Brusco.DistanzaSicurezza;
                DistanzaFermi = DatiGenerali.GuidatoreTipologia.Brusco.DistanzaFermi;
            }
            else if (tipologia == GuidatoreTipologia.Prudente)
            {
                PercentualeAccelerazione = DatiGenerali.GuidatoreTipologia.Prudente.Accelerazione;
                PercentualeDecelerazione = DatiGenerali.GuidatoreTipologia.Prudente.Decelerazione;
                PercentualeVelocità = DatiGenerali.GuidatoreTipologia.Prudente.Velocità;
                TempoReazione = DatiGenerali.GuidatoreTipologia.Prudente.TempoReazione;
                DistanzaSicurezza = DatiGenerali.GuidatoreTipologia.Prudente.DistanzaSicurezza;
                DistanzaFermi = DatiGenerali.GuidatoreTipologia.Prudente.DistanzaFermi;
            }
            else
            {
                PercentualeAccelerazione = DatiGenerali.GuidatoreTipologia.Normale.Accelerazione;
                PercentualeDecelerazione = DatiGenerali.GuidatoreTipologia.Normale.Decelerazione;
                PercentualeVelocità = DatiGenerali.GuidatoreTipologia.Normale.Velocità;
                TempoReazione = DatiGenerali.GuidatoreTipologia.Normale.TempoReazione;
                DistanzaSicurezza = DatiGenerali.GuidatoreTipologia.Normale.DistanzaSicurezza;
                DistanzaFermi = DatiGenerali.GuidatoreTipologia.Normale.DistanzaFermi;
            }

        }

       
    }
}
