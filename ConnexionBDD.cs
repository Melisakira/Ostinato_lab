using MySql.Data.MySqlClient; // Utilise le package installé

public class ConnexionBDD
{
    private static string connectionString = "Server=localhost;Port=3308;Database=ostinato_lab;User Id =root;Password=;";

    public static MySqlConnection ObtenirConnexion()
    {
        return new MySqlConnection(connectionString);
    }
}

