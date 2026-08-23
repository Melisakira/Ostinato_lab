using System.Windows;

namespace Ostinato_lab.Views
{
    public partial class TableauDeBord : Window
    {
        public TableauDeBord()
        {
            InitializeComponent();
        }

        // Bouton "Retour à la page d'accueil" : Reste inchangé selon votre logique actuelle
        private void BtnRetour_Click(object sender, RoutedEventArgs e)
        {
            // Votre code existant pour réinitialiser ou rafraîchir l'accueil s'il y en a un
        }

        // Bouton "Reprendre là où j'en étais" : Ouvre PageFormation
        private void BtnVersEtape_Click(object sender, RoutedEventArgs e)
        {
            OuvrirPageFormation();
        }

        // Bouton "Ma Formation" dans le menu latéral : Ouvre PageFormation
        private void BtnMaFormation_Click(object sender, RoutedEventArgs e)
        {
            OuvrirPageFormation();
        }

        // Méthode factorisée pour gérer l'ouverture de la page
        private void OuvrirPageFormation()
        {
            PageFormation pageFormation = new PageFormation();
            pageFormation.Show();
            this.Close(); // Ferme le Tableau de bord actuel
        }
    }
}
