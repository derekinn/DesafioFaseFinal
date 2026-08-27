using Microsoft.Data.Sqlite;

namespace API.Data
{
    public class IniciarDB
    {
        public static void CriarTabelas()
        {
            string connectionString = "Data Source=BancoDados.db;";
            using var connection = new SqliteConnection(connectionString);
            connection.Open();

            string query = @"
                CREATE TABLE IF NOT EXISTS Pessoas(
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nome TEXT NOT NULL,
                    CPF TEXT NOT NULL UNIQUE,
                    DataNascimento DATE NOT NULL,
                    Email TEXT NOT NULL
                );

                CREATE TABLE IF NOT EXISTS Telefones(
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    PessoaId INTEGER NOT NULL,
                    DDD TEXT NOT NULL,
                    Numero TEXT NOT NULL,
                    Tipo TEXT NOT NULL,
                    FOREIGN KEY (PessoaId) REFERENCES Pessoas(Id) ON DELETE CASCADE
                );

                CREATE TABLE IF NOT EXISTS Enderecos(
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    PessoaId INTEGER NOT NULL,
                    CEP TEXT NOT NULL,
                    Logradouro TEXT NOT NULL,
                    Numero TEXT NOT NULL,
                    Complemento TEXT,
                    Bairro TEXT NOT NULL,
                    Cidade TEXT NOT NULL,
                    Estado TEXT NOT NULL,
                    IsPrincipal INTEGER NOT NULL DEFAULT 0,
                    FOREIGN KEY (PessoaId) REFERENCES Pessoas(Id) ON DELETE CASCADE
                );";

            using var command = new SqliteCommand(query, connection);
            command.ExecuteNonQuery();
        }
    }
}
