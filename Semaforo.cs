using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimStradaC
{
    class Semaforo
    {
        public StradaDirezione stradaDirezione;
        public double posizioneX;
        public SemaforoLuce semaforoLuce;

        private double tempoUltimoCambiamento;

        public Semaforo(StradaDirezione _stradaDirezione, double _posizioneX, SemaforoLuce _semaforoLuce)
        {
            stradaDirezione = _stradaDirezione;
            posizioneX = _posizioneX;
            semaforoLuce = _semaforoLuce;

            
        }

        public bool Verifica()
        {

            return true;
        }

        public void Ciclo()
        {
            switch (semaforoLuce)
            {
                case SemaforoLuce.Verde:
                    if (Tempo.Ora - tempoUltimoCambiamento >= DatiGenerali.Semaforo.DurataVerde)
                    {
                        semaforoLuce = SemaforoLuce.Giallo;
                        tempoUltimoCambiamento = Tempo.Ora;
                    }
                    break;
                case SemaforoLuce.Giallo:
                    if (Tempo.Ora - tempoUltimoCambiamento >= DatiGenerali.Semaforo.DurataGiallo)
                    {
                        semaforoLuce = SemaforoLuce.Rosso;
                        tempoUltimoCambiamento = Tempo.Ora;
                    }
                    break;
                case SemaforoLuce.Rosso:
                    if (Tempo.Ora - tempoUltimoCambiamento >= DatiGenerali.Semaforo.DurataRosso)
                    {
                        semaforoLuce = SemaforoLuce.Verde;
                        tempoUltimoCambiamento = Tempo.Ora;
                    }
                    break;
            }
        }
    }
}
