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
            var primo = new Veicolo(VeicoloTipologia.Macchina, Emilie);
            var secondo = new Veicolo(VeicoloTipologia.Macchina, Emilie);

            // Calcolo tempo di percorrenza
            double tempoMinimoDiPercorrenza = Configuratore.TempoMinimoPercorrenza(120, VeicoloTipologia.Macchina, GuidatoreTipologia.Normale, 17.8);
            double durataSovrapposizioneRosso = Utilita.ApprossimaMaggiore(tempoMinimoDiPercorrenza, 5) + DatiGenerali.Semaforo.DurataSicurezza;

            // Creazione semaforo
            var semDX = new Semaforo(150, SemaforoLuce.Verde, DatiGenerali.Semaforo.DurataVerde, DatiGenerali.Semaforo.DurataGiallo, durataSovrapposizioneRosso, DatiGenerali.Semaforo.DurataSicurezza);
            var semSX = new Semaforo(200, SemaforoLuce.Verde, DatiGenerali.Semaforo.DurataVerde, DatiGenerali.Semaforo.DurataGiallo, durataSovrapposizioneRosso, DatiGenerali.Semaforo.DurataSicurezza);

            // Creazione corsie parti
            var cpDX1 = new CorsiaParte(19.44, 100, 3);     // 70 km/h
            var cpDX2 = new CorsiaParte(13.88, 50, 3);      // 50 km/h
            var cpDX3 = new CorsiaParte(8.33, 50, 3);       // 30 km/h   --- DEFINIRLE IN COSTANTI SIMULAZIONE ---
            var cpDX4 = new CorsiaParte(13.88, 50, 3);      // 50 km/h
            var cpDX5 = new CorsiaParte(19.44, 100, 3);     // 70 km/h

            // Creazione corsia DX
            var cDX = new Corsia(new List<CorsiaParte> { cpDX1, cpDX2, cpDX3, cpDX4, cpDX5 });

            // Creazione corsia SX
            var cSX = new Corsia(new List<CorsiaParte> { cpDX1, cpDX2, cpDX3, cpDX4, cpDX5 });

            Debug.WriteLine("Conteggio numero partia corsia: " + cSX.Lista.Count());
            Debug.WriteLine("Lunghezza corsia: " + cSX.Lunghezza());

            // Creazione coda
            var codaDX = new Coda(new Queue<Veicolo>(new[] { primo, secondo }));

            Debug.WriteLine("Numero Veicoli in coda: " + codaDX.codaVeicoli.Count()); 

            // Creazione strada
            var strada = new Strada(cDX, cSX, semDX, semSX);
            Debug.WriteLine("Lunghezza strada: " + strada.Lunghezza());



            // Inizio simulazione
            Tempo.Ora = 0;

            // Per i risultati
            StringBuilder testoRisultati = new StringBuilder();

            // SIMULAZIONE PER X VOLTE L'INTERVALLO DEFINITO
            for (int i = 0; i < 200; i++)
            {
                semDX.Ciclo();
                testoRisultati.AppendLine("--------------------------------");
                testoRisultati.AppendLine("Tempo: " + Converti.FormatoHMS(Tempo.Ora));
                testoRisultati.AppendLine("Luce : " + semDX.semaforoLuce);

                Tempo.Ora += DatiGenerali.Simulazione.Intervallo;
            }

            // Visualizza i risultati
            tbRisultati.Text = testoRisultati.ToString();
        }
    }
}
