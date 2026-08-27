using API.Models;
using Microsoft.Data.Sqlite;
namespace API.Data
{
    public class TelefoneRepository(SqliteConnection connection, SqliteTransaction transaction)
    {
        private readonly SqliteConnection conexao = connection;
        private readonly SqliteTransaction transacao = transaction;
    
        public int Inserir(Telefone telefone)
        {
            string sql = @"INSERT INTO Telefones (PessoaId, DDD, Numero, Tipo) VALUES (@PessoaId, @DDD, @Numero, @Tipo)";

            using var cmd = conexao.CreateCommand();

            cmd.Transaction = transacao;
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@PessoaId", telefone.PessoaId);
            cmd.Parameters.AddWithValue("@DDD", telefone.DDD);
            cmd.Parameters.AddWithValue("@Numero", telefone.Numero);
            cmd.Parameters.AddWithValue("@Tipo", telefone.Tipo);
            cmd.ExecuteNonQuery();
            cmd.CommandText = "SELECT last_insert_rowid();";
            cmd.Parameters.Clear();
            int id = Convert.ToInt32(cmd.ExecuteScalar());

            return id;
        }
        public int Atualizar(Telefone telefone)
        {
            string sql = @"UPDATE Telefones SET DDD = @DDD, Numero = @Numero, Tipo = @Tipo WHERE Id = @Id";

            using var cmd = conexao.CreateCommand();

            cmd.Transaction = transacao;
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@DDD", telefone.DDD);
            cmd.Parameters.AddWithValue("@Numero", telefone.Numero);
            cmd.Parameters.AddWithValue("@Tipo", telefone.Tipo);
            cmd.Parameters.AddWithValue("@Id", telefone.Id);

            return cmd.ExecuteNonQuery();
        }
        public List<Telefone> Listar(int pessoaId)
        {
            var telefones = new List<Telefone>();

            string sql = "SELECT * FROM Telefones WHERE PessoaId = @PessoaId";

            using var cmd = conexao.CreateCommand();

            cmd.Transaction = transacao;
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@PessoaId", pessoaId);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var telefone = new Telefone
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    PessoaId = Convert.ToInt32(reader["PessoaId"]),
                    DDD = reader["DDD"].ToString(),
                    Numero = reader["Numero"].ToString(),
                    Tipo = reader["Tipo"].ToString()
                };
                telefones.Add(telefone);
            }
            return telefones;
        }
        public Telefone? ObterPorId(int id)
        {
            string sql = "SELECT * FROM Telefones WHERE Id = @Id";

            using var cmd = conexao.CreateCommand();

            cmd.Transaction = transacao;
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@Id", id);

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return new Telefone
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    PessoaId = Convert.ToInt32(reader["PessoaId"]),
                    DDD = reader["DDD"].ToString(),
                    Numero = reader["Numero"].ToString(),
                    Tipo = reader["Tipo"].ToString()
                };
            }

            return null;
        }
        public int Deletar(int id)
        {
            string sql = @"DELETE FROM Telefones WHERE Id = @Id";

            using var cmd = conexao.CreateCommand();

            cmd.Transaction = transacao;
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@Id", id);

            return cmd.ExecuteNonQuery();
        }
        public int DeletarPorPessoaId(int pessoaId)
        {
            string sql = @"DELETE FROM Telefones WHERE PessoaId = @PessoaId";

            using var cmd = conexao.CreateCommand();

            cmd.Transaction = transacao;
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@PessoaId", pessoaId);

            return cmd.ExecuteNonQuery();
        }
    }
}
