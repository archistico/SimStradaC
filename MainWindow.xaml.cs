using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;

namespace SimStradaC
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Creazione guidatori
            var Mamma = new Guidatore(GuidatoreTipologia.Prudente);
            var Emilie = new Guidatore(GuidatoreTipologia.Normale);

            // Creazioni veicoli
            var primo = new Veicolo(VeicoloTipologia.Macchina, Emilie, StradaDirezione.DX);
            var secondo = new Veicolo(VeicoloTipologia.Macchina, Emilie, StradaDirezione.DX, primo);
                        
            // Calcolo tempo di percorrenza
            double tempoMinimoDiPercorrenza = Configuratore.TempoMinimoPercorrenza(120, VeicoloTipologia.Macchina, GuidatoreTipologia.Normale, 17.8);
            double durataSovrapposizioneRosso = Utilita.ApprossimaMaggiore(tempoMinimoDiPercorrenza, 5) + DatiGenerali.Semaforo.DurataSicurezza;

            // Creazione semaforo
            var sem = new Semaforo(StradaDirezione.DX, 0, SemaforoLuce.Verde, DatiGenerali.Semaforo.DurataVerde, DatiGenerali.Semaforo.DurataGiallo, durataSovrapposizioneRosso, DatiGenerali.Semaforo.DurataSicurezza);

            // Inizio simulazione
            Tempo.Ora = 0;

            // Per i risultati
            StringBuilder testoRisultati = new StringBuilder();

            // SIMULAZIONE PER X VOLTE L'INTERVALLO DEFINITO
            for (int i = 0; i < 200; i++)
            {
                sem.Ciclo();
                testoRisultati.AppendLine("--------------------------------");
                testoRisultati.AppendLine("Tempo: " + Converti.FormatoHMS(Tempo.Ora));
                testoRisultati.AppendLine("Luce : " + sem.semaforoLuce);
                
                Tempo.Ora += DatiGenerali.Simulazione.Intervallo;
            }
                     
            // Visualizza i risultati
            tbRisultati.Text = testoRisultati.ToString();
        }
    }
}
