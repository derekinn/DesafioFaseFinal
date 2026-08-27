using API.Models;
using Microsoft.Data.Sqlite;

namespace API.Data
{
    public class PessoaRepository(SqliteConnection connection, SqliteTransaction transaction)
    {
        private readonly SqliteConnection conexao = connection;
        private readonly SqliteTransaction transacao = transaction;

        public int Inserir(Pessoa pessoa)
        {
            string sql = @"
                INSERT INTO Pessoas 
                (Nome, CPF, DataNascimento, Email) 
                VALUES 
                (@Nome, @CPF, @DataNascimento, @Email)";

            using var cmd = conexao.CreateCommand();

            cmd.Transaction = transacao;
            cmd.CommandText = sql;

            cmd.Parameters.AddWithValue("@Nome", pessoa.Nome);
            cmd.Parameters.AddWithValue("@CPF", pessoa.CPF);
            cmd.Parameters.AddWithValue("@DataNascimento", pessoa.DataNascimento);
            cmd.Parameters.AddWithValue("@Email", pessoa.Email);

            cmd.ExecuteNonQuery();

            cmd.CommandText = "SELECT last_insert_rowid();";
            cmd.Parameters.Clear();

            int id = Convert.ToInt32(cmd.ExecuteScalar());

            return id;
        }

        public List<Pessoa> Listar()
        {
            var pessoas = new List<Pessoa>();

            string sql = "SELECT * FROM Pessoas";

            using var cmd = conexao.CreateCommand();

            cmd.Transaction = transacao;
            cmd.CommandText = sql;

            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var pessoa = new Pessoa
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Nome = reader["Nome"].ToString(),
                    CPF = reader["CPF"].ToString(),
                    DataNascimento = DateOnly.Parse(
                        reader["DataNascimento"].ToString()!
                    ),
                    Email = reader["Email"].ToString()
                };

                pessoas.Add(pessoa);
            }

            return pessoas;
        }

        public int Atualizar(Pessoa pessoa)
        {
            string sql = @"
                UPDATE Pessoas 
                SET 
                    Nome = @Nome, 
                    CPF = @CPF, 
                    DataNascimento = @DataNascimento, 
                    Email = @Email 
                WHERE Id = @Id";

            using var cmd = conexao.CreateCommand();

            cmd.Transaction = transacao;
            cmd.CommandText = sql;

            cmd.Parameters.AddWithValue("@Nome", pessoa.Nome);
            cmd.Parameters.AddWithValue("@CPF", pessoa.CPF);
            cmd.Parameters.AddWithValue(
                "@DataNascimento",
                pessoa.DataNascimento.ToString("yyyy-MM-dd")
            );
            cmd.Parameters.AddWithValue("@Email", pessoa.Email);
            cmd.Parameters.AddWithValue("@Id", pessoa.Id);

            return cmd.ExecuteNonQuery();
        }

        public int Deletar(int id)
        {
            string sql = "DELETE FROM Pessoas WHERE Id = @Id";

            using var cmd = conexao.CreateCommand();

            cmd.Transaction = transacao;
            cmd.CommandText = sql;

            cmd.Parameters.AddWithValue("@Id", id);

            return cmd.ExecuteNonQuery();
        }

        public Pessoa? ObterPorId(int id)
        {
            string sql = "SELECT * FROM Pessoas WHERE Id = @Id";

            using var cmd = conexao.CreateCommand();

            cmd.Transaction = transacao;
            cmd.CommandText = sql;

            cmd.Parameters.AddWithValue("@Id", id);

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return new Pessoa
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Nome = reader["Nome"].ToString(),
                    CPF = reader["CPF"].ToString(),
                    DataNascimento = DateOnly.Parse(
                        reader["DataNascimento"].ToString()!
                    ),
                    Email = reader["Email"].ToString()
                };
            }

            return null;
        }

        public List<Pessoa> Buscar(string? busca, string? tipoBusca)
        {
            var pessoas = new List<Pessoa>();

            string sql;

            if (tipoBusca == "CPF")
            {
                sql = @"
                    SELECT * 
                    FROM Pessoas
                    WHERE CPF = @Busca";
            }
            else
            {
                sql = @"
                    SELECT * 
                    FROM Pessoas
                    WHERE Nome LIKE @Filtro";
            }

            using var cmd = conexao.CreateCommand();

            cmd.Transaction = transacao;
            cmd.CommandText = sql;

            cmd.Parameters.AddWithValue(
                "@Busca",
                busca ?? string.Empty
            );

            cmd.Parameters.AddWithValue(
                "@Filtro",
                $"%{busca}%"
            );

            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var pessoa = new Pessoa
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Nome = reader["Nome"].ToString(),
                    CPF = reader["CPF"].ToString(),
                    DataNascimento = DateOnly.Parse(
                        reader["DataNascimento"].ToString()!
                    ),
                    Email = reader["Email"].ToString()
                };

                pessoas.Add(pessoa);
            }

            return pessoas;
        }
    }
}