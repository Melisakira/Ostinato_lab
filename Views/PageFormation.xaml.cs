using System.Windows;

namespace Ostinato_lab.Views
{
    public partial class PageFormation : Window
    {
        public PageFormation()
        {
            InitializeComponent();

            // On charge les formations dès l'ouverture de la page
            ChargerFormations();
        }

        private void ChargerFormations()
        {
            try
            {
                // Note : Ligne commentée temporairement pour éviter un crash si "ListeFormations" n'existe pas dans le XAML
                // ListeFormations.ItemsSource = FormationDAL.ObtenirToutesLesFormations();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des formations : {ex.Message}", "Erreur");
            }
        }

        // Action du bouton "Reprendre ce module" -> Ouvre PageEtape
        private void ReprendreModule_Click(object sender, RoutedEventArgs e)
        {
            PageEtape pageEtape = new PageEtape();
            pageEtape.Show();
            this.Close();
        }

        // Action du bouton "Retour à la page d'accueil" -> Ouvre TableauDeBord
        private void RetourAccueil_Click(object sender, RoutedEventArgs e)
        {
            TableauDeBord tableauDeBord = new TableauDeBord();
            tableauDeBord.Show();
            this.Close();
        }
    }
}
