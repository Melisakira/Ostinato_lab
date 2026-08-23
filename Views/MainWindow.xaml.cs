using System.Windows;

namespace Ostinato_lab
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void BtnConnexion_Click(object sender, RoutedEventArgs e)
        {
            TableauDeBord suite = new TableauDeBord();
            suite.Show();
            this.Close();
        }
    }
}