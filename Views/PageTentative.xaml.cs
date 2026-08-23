using System.Windows;

namespace Ostinato_lab.Views
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class PageTentative : Window
    {
        public PageTentative()
        {
            InitializeComponent();
        }

        // Action pour le bouton "← Retour à l'étape" et "Annuler"
        private void BtnRetourEtape_Click(object sender, RoutedEventArgs e)
        {
            PageEtape precedent = new PageEtape();
            precedent.Show();
            this.Close();
        }

        // Action pour le bouton de menu latéral "Mes Jalons"
        private void BtnMesJalons_Click(object sender, RoutedEventArgs e)
        {
            PageJalons suite = new PageJalons();
            suite.Show();
            this.Close();
        }
    }
}