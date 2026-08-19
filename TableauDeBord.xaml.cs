using System.Windows;

namespace Ostinato_lab
{
    public partial class TableauDeBord : Window
    {
        public TableauDeBord()
        {
            InitializeComponent();
        }
        private void BtnVersEtape_Click(object sender, RoutedEventArgs e)
        {
            PageEtape suite = new PageEtape();
            suite.Show();
            this.Close();
        }
        private void BtnRetour_Click(object sender, RoutedEventArgs e)
        {
            // 1. On recrée une fenêtre MainWindow
            MainWindow precedent = new MainWindow();

            // 2. On l'affiche
            precedent.Show();

            // 3. On ferme le Tableau de bord actuel
            this.Close();
        }

    }
}

