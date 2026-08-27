using Microsoft.Data.Sqlite;
using API.Models;

namespace API.Data
{
    public class EnderecoRepository(SqliteConnection connection, SqliteTransaction transaction)
    {
        private readonly SqliteConnection conexao = connection;
        private readonly SqliteTransaction transacao = transaction;

        public int Inserir(Endereco endereco)
        {
            string sql = @"INSERT INTO Enderecos (PessoaId, Cep, Logradouro, Numero, Complemento, Bairro, Cidade, Estado, IsPrincipal) 
                           VALUES (@PessoaId, @Cep, @Logradouro, @Numero, @Complemento, @Bairro, @Cidade, @Estado, @IsPrincipal)";

            using var cmd = conexao.CreateCommand();

            cmd.Transaction = transacao;
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@PessoaId", endereco.PessoaId);
            cmd.Parameters.AddWithValue("@Cep", endereco.Cep);
            cmd.Parameters.AddWithValue("@Logradouro", endereco.Logradouro);
            cmd.Parameters.AddWithValue("@Numero", endereco.Numero);
            cmd.Parameters.AddWithValue("@Complemento", (object?)endereco.Complemento ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Bairro", endereco.Bairro);
            cmd.Parameters.AddWithValue("@Cidade", endereco.Cidade);
            cmd.Parameters.AddWithValue("@Estado", endereco.Estado);
            cmd.Parameters.AddWithValue("@IsPrincipal", endereco.IsPrincipal ? 1 : 0);
            cmd.ExecuteNonQuery();
            cmd.CommandText = "SELECT last_insert_rowid();";
            cmd.Parameters.Clear();
            int id = Convert.ToInt32(cmd.ExecuteScalar());

            return id;
        }
        public List<Endereco> Listar(int pessoaId)
        {
            var enderecos = new List<Endereco>();

            string sql = "SELECT * FROM Enderecos WHERE PessoaId = @PessoaId";

            using var cmd = conexao.CreateCommand();
            cmd.Transaction = transacao;

            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@PessoaId", pessoaId);

            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var endereco = new Endereco
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    PessoaId = Convert.ToInt32(reader["PessoaId"]),
                    Cep = reader["Cep"].ToString(),
                    Logradouro = reader["Logradouro"].ToString(),
                    Numero = reader["Numero"].ToString(),
                    Complemento = reader["Complemento"].ToString(),
                    Bairro = reader["Bairro"].ToString(),
                    Cidade = reader["Cidade"].ToString(),
                    Estado = reader["Estado"].ToString(),
                    IsPrincipal = Convert.ToBoolean(reader["IsPrincipal"])
                };

                enderecos.Add(endereco);
            }

            return enderecos;
        }
        public int Atualizar(Endereco endereco)
        {
            string sql = @"UPDATE Enderecos SET Cep = @Cep, Logradouro = @Logradouro, Numero = @Numero, Complemento = @Complemento, 
                           Bairro = @Bairro, Cidade = @Cidade, Estado = @Estado, IsPrincipal = @IsPrincipal WHERE Id = @Id";

            using var cmd = conexao.CreateCommand();

            cmd.Transaction = transacao;
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@Cep", endereco.Cep);
            cmd.Parameters.AddWithValue("@Logradouro", endereco.Logradouro);
            cmd.Parameters.AddWithValue("@Numero", endereco.Numero);
            cmd.Parameters.AddWithValue("@Complemento",(object?) endereco.Complemento ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Bairro", endereco.Bairro);
            cmd.Parameters.AddWithValue("@Cidade", endereco.Cidade);
            cmd.Parameters.AddWithValue("@Estado", endereco.Estado);
            cmd.Parameters.AddWithValue("@IsPrincipal", endereco.IsPrincipal ? 1 : 0);
            cmd.Parameters.AddWithValue("@Id", endereco.Id);

            return cmd.ExecuteNonQuery();
        }
        public int Deletar(int id)
        {
            string sql = @"DELETE FROM Enderecos WHERE Id = @Id";

            using var cmd = conexao.CreateCommand();

            cmd.Transaction = transacao;
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@Id", id);

            return cmd.ExecuteNonQuery();
        }
        public int DeletarPorPessoaId(int pessoaId)
        {
            string sql = @"DELETE FROM Enderecos WHERE PessoaId = @PessoaId";

            using var cmd = conexao.CreateCommand();

            cmd.Transaction = transacao;
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@PessoaId", pessoaId);

            return cmd.ExecuteNonQuery();
        }
        public void RemoverPrincipalDaPessoa(int pessoaId)
        {
            string sql = @"UPDATE Enderecos SET IsPrincipal = 0 WHERE PessoaId = @PessoaId";

            using var cmd = conexao.CreateCommand();

            cmd.Transaction = transacao;
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@PessoaId", pessoaId);

            cmd.ExecuteNonQuery();
        }
        public Endereco ObterPorId(int id)
        {
            string sql = "SELECT * FROM Enderecos WHERE Id = @Id";

            using var cmd = conexao.CreateCommand();

            cmd.Transaction = transacao;
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@Id", id);

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return new Endereco
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    PessoaId = Convert.ToInt32(reader["PessoaId"]),
                    Cep = reader["Cep"].ToString(),
                    Logradouro = reader["Logradouro"].ToString(),
                    Numero = reader["Numero"].ToString(),
                    Complemento = reader["Complemento"].ToString(),
                    Bairro = reader["Bairro"].ToString(),
                    Cidade = reader["Cidade"].ToString(),
                    Estado = reader["Estado"].ToString(),
                    IsPrincipal = Convert.ToBoolean(reader["IsPrincipal"])
                };
            }

            return null;
        }
    }
}
