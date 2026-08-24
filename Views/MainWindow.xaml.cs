using Ostinato_lab.Data;        // Trouve la connexion BDD
using System.Windows;
using System.Windows.Controls;

namespace Ostinato_lab.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Appel de la méthode de test intégrée
            ConnexionBDD.TesterConnexion();

            Ostinato_lab.Controllers.FormationDAL.TesterSecuriteAccesAdmin();
        }

        private void BtnConnexion_Click(object sender, RoutedEventArgs e)
        {
            // 1. On lit quel profil est sélectionné à l'écran
            var combo = (ComboBox)FindName("ProfilSelect");
            string profilSelectionne = (combo?.SelectedItem as ComboBoxItem)?.Content.ToString();

            // 2. LOGIQUE DE LA 3E COUCHE (Aiguillage et sécurité visuelle)
            if (profilSelectionne == "Un apprenant")
            {
                System.Diagnostics.Debug.WriteLine("[3E COUCHE - PRÉSENTATION] Profil Apprenant détecté. Redirection autorisée vers le Tableau de Bord TDAH.");

                // Tout est en ordre, on ouvre l'espace apprenant existant
                TableauDeBord suite = new TableauDeBord();
                suite.Show();
                this.Close();
            }
            else
            {
                // Si c'est un Formateur ou un Admin, on bloque l'accès pour protéger l'interface TDAH
                System.Diagnostics.Debug.WriteLine($"[3E COUCHE - SÉCURITÉ] Tentative de connexion : {profilSelectionne}. Accès refusé sur ce terminal Apprenant.");

                // On affiche une boîte de message claire à l'écran
                MessageBox.Show($"Accès refusé.\nCette interface est strictement configurée pour l'espace d'apprentissage sans distraction (Apprenants).\n\nLes espaces pour les formateurs et administrateurs ne sont pas accessibles depuis cette application.",
                                "Contrôle d'accès Présentation",
                                MessageBoxButton.OK,
                                MessageBoxImage.Warning);
            }
        }
    }
}