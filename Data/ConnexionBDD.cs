using MySql.Data.MySqlClient;
using System.Diagnostics; // Indispensable pour écrire dans la console de Visual Studio

namespace Ostinato_lab.Data
{
    public class ConnexionBDD
    {
        private static string connectionString = "Server=localhost;Port=3308;Database=ostinato_lab;User Id=root;Password=;";

        public static MySqlConnection ObtenirConnexion()
        {
            return new MySqlConnection(connectionString);
        }

        // 🧪 Méthode intégrée pour exécuter le Test n°1 et générer votre screen
        public static bool TesterConnexion()
        {
            using MySqlConnection conn = ObtenirConnexion();
            try
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM utilisateur;"; // Utilise la table présente dans votre DAL

                using MySqlCommand cmd = new MySqlCommand(query, conn);
                int nbFormations = Convert.ToInt32(cmd.ExecuteScalar());

                Debug.WriteLine("==================================================");
                Debug.WriteLine("[SUCCÈS BDD] Connexion établie sur le port 3308 !");
                Debug.WriteLine($"Nombre d'utilisateurs trouvés : {nbFormations}");
                Debug.WriteLine("==================================================");

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("==================================================");
                Debug.WriteLine("[ÉCHEC BDD] La connexion a échoué !");
                Debug.WriteLine($"Erreur : {ex.Message}");
                Debug.WriteLine("==================================================");

                return false;
            }
        }
    }
}
