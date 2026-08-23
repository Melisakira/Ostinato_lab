using MySql.Data.MySqlClient;
using Ostinato_lab.Data;          // Indispensable pour trouver ConnexionBDD

namespace Ostinato_lab.Controllers
{
    public class Formation
    {
        public int IdFormation { get; set; }
        public string Titre { get; set; }
        public string Description { get; set; }
        public string Niveau { get; set; }
    }

    public class FormationDAL
    {
        public static List<Formation> ObtenirToutesLesFormations()
        {
            List<Formation> formations = new List<Formation>();

            using (MySqlConnection conn = ConnexionBDD.ObtenirConnexion())
            {
                conn.Open();
                string requete = "SELECT id, titre, description, niveau FROM Formation";
                MySqlCommand cmd = new MySqlCommand(requete, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    formations.Add(new Formation
                    {
                        IdFormation = reader.GetInt32("id"),
                        Titre = reader.GetString("titre"),
                        Description = reader.GetString("description"),
                        Niveau = reader.GetString("niveau")
                    });
                }
            }
            return formations;
        }

        // 🧪 TEST N°2 : Validation de la règle de sécurité de la couche métier
        public static void TesterSecuriteAccesAdmin()
        {
            System.Diagnostics.Debug.WriteLine("\n==================================================");
            System.Diagnostics.Debug.WriteLine("[DÉBUT TEST N°2] Contrôle des Accès Logique Métier");
            System.Diagnostics.Debug.WriteLine("Règle : Seul le rôle 'ADMINISTRATEUR' est autorisé");
            System.Diagnostics.Debug.WriteLine("==================================================");

            // Tableau contenant les noms exacts que vous avez encodés dans votre script SQL
            string[] utilisateursATester = { "Brand", "Dupont", "Durand" };

            using (MySqlConnection conn = ConnexionBDD.ObtenirConnexion())
            {
                try
                {
                    conn.Open();

                    foreach (string nomClient in utilisateursATester)
                    {
                        // Requête pour extraire le rôle de l'utilisateur en fonction de son nom
                        string query = "SELECT role FROM utilisateur WHERE nom = @nom;";

                        using MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@nom", nomClient);
                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            string roleObtenu = result.ToString();

                            // Application stricte de la règle de gestion de sécurité (Couche Métier)
                            if (roleObtenu == "ADMINISTRATEUR")
                            {
                                System.Diagnostics.Debug.WriteLine($"[ACCÈS ACCORDÉ] {nomClient} | Rôle : {roleObtenu} -> Autorisé sur l'espace Admin.");
                            }
                            else
                            {
                                System.Diagnostics.Debug.WriteLine($"[ACCÈS REFUSÉ] {nomClient} | Rôle : {roleObtenu} -> Accès interdit (Espace restreint).");
                            }
                        }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine($"[ERREUR] Utilisateur '{nomClient}' absent de la base de données.");
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"[ERREUR CRITIQUE] Échec du test métier : {ex.Message}");
                }
            }

            System.Diagnostics.Debug.WriteLine("==================================================\n");
        }
    }
}
