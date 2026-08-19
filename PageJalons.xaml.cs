using System.Windows;

namespace Ostinato_lab
{
    public partial class PageJalons : Window
    {
        public PageJalons()
        {
            InitializeComponent();
        }

        // Action lors du clic sur le bouton Messagerie
        private void BtnMessagerie_Click(object sender, RoutedEventArgs e)
        {
            // IMPORTANT : Remplacez "PageMessagerie" ci-dessous par le nom exact 
            // de votre fichier XAML créé pour l'écran de messagerie.
            PageMessagerie suite = new PageMessagerie();
            suite.Show();
            this.Close();
        }
    }
}

