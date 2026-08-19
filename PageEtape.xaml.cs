using System.Windows;

namespace Ostinato_lab
{
    public partial class PageEtape : Window
    {
        public PageEtape()
        {
            InitializeComponent();
        }

        // 1. Menu latéral : Ouvre la page des Jalons
        private void BtnJalons_Click(object sender, RoutedEventArgs e)
        {
            PageJalons suite = new PageJalons();
            suite.Show();
            this.Close();
        }

        // 2. Bouton Retour : Revient sur le Tableau de bord
        private void BtnRetour_Click(object sender, RoutedEventArgs e)
        {
            TableauDeBord precedent = new TableauDeBord();
            precedent.Show();
            this.Close();
        }

        // 3. Bouton Commencer l'exercice : Ouvre la page Tentative
        private void BtnCommencerExercice_Click(object sender, RoutedEventArgs e)
        {
            PageTentative exercice = new PageTentative();
            exercice.Show();
            this.Close();
        }
    }
}
