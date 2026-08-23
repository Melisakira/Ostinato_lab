using Ostinato_lab.Data;        // Trouve la connexion BDD
using System.Windows;

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
        }

        private void BtnConnexion_Click(object sender, RoutedEventArgs e)
        {
            TableauDeBord suite = new TableauDeBord();
            suite.Show();
            this.Close();
        }
    }
}
