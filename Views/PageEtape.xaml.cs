using System.Windows;

namespace Ostinato_lab.Views
{
    public partial class PageEtape : Window
    {
        public PageEtape()
        {
            InitializeComponent();
        }

        // Action du bouton "← Retour au Module 2" -> Ouvre PageFormation
        private void BtnRetourModule_Click(object sender, RoutedEventArgs e)
        {
            PageFormation pageFormation = new PageFormation();
            pageFormation.Show();
            this.Close();
        }

        // MODIFICATION : Action du bouton "Commencer l'exercice →" -> Ouvre PageTentative
        private void BtnCommencerExercice_Click(object sender, RoutedEventArgs e)
        {
            PageTentative pageTentative = new PageTentative();
            pageTentative.Show();
            this.Close(); // Ferme la page de l'étape
        }

        // Action du menu latéral "Mes Jalons"
        private void BtnJalons_Click(object sender, RoutedEventArgs e)
        {
            // Ajoutez votre logique pour les jalons ici si nécessaire
        }
    }
}
