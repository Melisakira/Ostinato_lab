using MySql.Data.MySqlClient; // Utilise le package installé

public class ConnexionBDD
{
    private static string connectionString = "Server=localhost;Database=ostinato_lab;User Id =root;Password=;";

    public static MySqlConnection ObtenirConnexion()
    {
        MySqlConnection conn = new MySqlConnection(connectionString);
        conn.Open(); // ouvre ici pour que la connexion soit prête à l'emploi
        return conn;
    }
}

