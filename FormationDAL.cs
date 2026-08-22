using MySql.Data.MySqlClient;

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
            string requete = "SELECT idFormation, titre, description, niveau FROM Formation";
            MySqlCommand cmd = new MySqlCommand(requete, conn);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                formations.Add(new Formation
                {
                    IdFormation = reader.GetInt32("idFormation"),
                    Titre = reader.GetString("titre"),
                    Description = reader.GetString("description"),
                    Niveau = reader.GetString("niveau")
                });
            }
        }
        return formations;
    }
}