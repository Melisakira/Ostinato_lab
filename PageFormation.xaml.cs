using System.Windows;

namespace Ostinato_lab
{
    public partial class PageFormation : Window
    {
        public PageFormation()
        {
            InitializeComponent();
        }

        // Action du bouton "Reprendre ce module" -> Ouvre PageEtape
        private void ReprendreModule_Click(object sender, RoutedEventArgs e)
        {
            PageEtape pageEtape = new PageEtape();
            pageEtape.Show();
            this.Close(); // Ferme la page actuelle (optionnel)
        }

        // Action du bouton "Retour à la page d'accueil" -> Ouvre TableauDeBord
        private void RetourAccueil_Click(object sender, RoutedEventArgs e)
        {
            TableauDeBord tableauDeBord = new TableauDeBord();
            tableauDeBord.Show();
            this.Close(); // Ferme la page actuelle (optionnel)
        }
    }
}
