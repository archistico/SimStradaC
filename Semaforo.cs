using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SimStradaC
{
    class Semaforo
    {
        public StradaDirezione stradaDirezione;
        public double posizioneX;
        public SemaforoLuce semaforoLuce;
        public double durataRosso;
        public double durataGiallo;
        public double durataVerde;
        public double durataSovrapposizioneRosso;
        public double durataSicurezza;
        public double durataTotale;

        private double tempoUltimoCambiamento;

        public void Debugga()
        {
            Debug.WriteLine("------------------");
            Debug.WriteLine("CREAZIONE SEMAFORO");
            Debug.WriteLine("Durata verde: " + Math.Round(durataVerde, 2));
            Debug.WriteLine("Durata giallo: " + Math.Round(durataGiallo, 2));
            Debug.WriteLine("Durata rosso: " + Math.Round(durataRosso, 2));
            Debug.WriteLine("Durata sovrapposizione rosso: " + Math.Round(durataSovrapposizioneRosso, 2));
            Debug.WriteLine("Durata sicurezza: " + Math.Round(durataSicurezza, 2));
            Debug.WriteLine("Durata totale ciclo: " + Math.Round(durataTotale, 2));
        }

        public Semaforo(StradaDirezione _stradaDirezione, double _posizioneX, SemaforoLuce _semaforoLuce)
        {
            stradaDirezione = _stradaDirezione;
            posizioneX = _posizioneX;
            semaforoLuce = _semaforoLuce;
            durataRosso = DatiGenerali.Semaforo.DurataRosso;
            durataGiallo = DatiGenerali.Semaforo.DurataGiallo;
            durataVerde = DatiGenerali.Semaforo.DurataVerde;
            durataSovrapposizioneRosso = DatiGenerali.Semaforo.DurataSovrapposizioneRosso;
            durataSicurezza = DatiGenerali.Semaforo.DurataSicurezza;
            durataTotale = durataVerde + durataGiallo + durataRosso;
            Debugga();
        }

        public Semaforo(StradaDirezione _stradaDirezione, double _posizioneX, SemaforoLuce _semaforoLuce, double _durataVerde, double _durataGiallo, double _durataSovrapposizioneRosso, double _durataSicurezza)
        {
            stradaDirezione = _stradaDirezione;
            posizioneX = _posizioneX;
            semaforoLuce = _semaforoLuce;
            durataGiallo = _durataGiallo;
            durataVerde = _durataVerde;
            durataSovrapposizioneRosso = _durataSovrapposizioneRosso;
            durataSicurezza = _durataSicurezza;
            durataRosso = durataVerde + durataGiallo + 2 * durataSovrapposizioneRosso + 2 * durataSicurezza;
            durataTotale = durataVerde + durataGiallo + durataRosso;
            Debugga();
        }

        public void Ciclo()
        {
            switch (semaforoLuce)
            {
                case SemaforoLuce.Verde:
                    if (Tempo.Ora - tempoUltimoCambiamento >= durataVerde)
                    {
                        semaforoLuce = SemaforoLuce.Giallo;
                        tempoUltimoCambiamento = Tempo.Ora;
                    }
                    break;
                case SemaforoLuce.Giallo:
                    if (Tempo.Ora - tempoUltimoCambiamento >= durataGiallo)
                    {
                        semaforoLuce = SemaforoLuce.Rosso;
                        tempoUltimoCambiamento = Tempo.Ora;
                    }
                    break;
                case SemaforoLuce.Rosso:
                    if (Tempo.Ora - tempoUltimoCambiamento >= durataRosso)
                    {
                        semaforoLuce = SemaforoLuce.Verde;
                        tempoUltimoCambiamento = Tempo.Ora;
                    }
                    break;
            }
        }
    }
}
