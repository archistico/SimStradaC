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
            var Mamma = new Guidatore(GuidatoreTipologia.Prudente);
            var Emilie = new Guidatore(GuidatoreTipologia.Normale);

            var primo = new Veicolo(VeicoloTipologia.Macchina, Emilie, StradaDirezione.DX);
            var secondo = new Veicolo(VeicoloTipologia.Macchina, Emilie, StradaDirezione.DX, primo);
                        
            StringBuilder testoRisultati = new StringBuilder();

            var sem = new Semaforo(StradaDirezione.DX, 0, SemaforoLuce.Verde);

            // Inizio simulazione
            Tempo.Ora = 0;

            for (int i = 0; i < 200; i++)
            {
                sem.Ciclo();
                testoRisultati.AppendLine("--------------------------------");
                testoRisultati.AppendLine("Tempo: " + Converti.FormatoHMS(Tempo.Ora));
                testoRisultati.AppendLine("Luce : " + sem.semaforoLuce);
                
                Tempo.Ora += DatiGenerali.Simulazione.Intervallo;
            }
            
            tbRisultati.Text = testoRisultati.ToString();
        }
    }
}
