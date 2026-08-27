using API.Data;
using API.Models;
using Microsoft.Data.Sqlite;

namespace API.Services
{
    public class AgendaService
    {
        public int SalvarPessoa(Pessoa pessoa)
        {
            pessoa.Validar();

            using var cn = new SqliteConnection();
            cn.ConnectionString = "Data Source=BancoDados.db";
            cn.Open();

            using var trans = cn.BeginTransaction();

            try
            {
                var PessoaRepository = new PessoaRepository(cn, trans);
                var EnderecoRepository = new EnderecoRepository(cn, trans);
                var TelefoneRepository = new TelefoneRepository(cn, trans);

                int id = PessoaRepository.Inserir(pessoa);

                foreach (var endereco in pessoa.Enderecos)
                {
                    endereco.PessoaId = id;
                    EnderecoRepository.Inserir(endereco);
                }

                foreach (var telefone in pessoa.Telefones)
                {
                    telefone.PessoaId = id;
                    TelefoneRepository.Inserir(telefone);
                }

                trans.Commit();
                return id;
            }
            catch
            {
                trans.Rollback();
                throw;
            }
        }
        public Pessoa? ObterPessoaCompleta(int id)
        {
            using var cn = new SqliteConnection("Data Source=BancoDados.db");
            cn.Open();

            var PessoaRepository = new PessoaRepository(cn, null);
            var EnderecoRepository = new EnderecoRepository(cn, null);
            var TelefoneRepository = new TelefoneRepository(cn, null);

            var pessoa = PessoaRepository.ObterPorId(id);

            if (pessoa == null)
            {
                return null;
            }

            pessoa.Enderecos = EnderecoRepository.Listar(id);
            pessoa.Telefones = TelefoneRepository.Listar(id);

            return pessoa;
        }
        public List<Pessoa> ListarPessoas()
        {
            using var cn = new SqliteConnection("Data Source=BancoDados.db");
            cn.Open();

            var PessoaRepository = new PessoaRepository(cn, null);

            return PessoaRepository.Listar();
        }
        public int DeletarPessoa(int id)
        {
            using var cn = new SqliteConnection("Data Source=BancoDados.db");
            cn.Open();

            using var trans = cn.BeginTransaction();
            try
            {
                var PessoaRepository = new PessoaRepository(cn, trans);
                int result = PessoaRepository.Deletar(id);
                trans.Commit();
                return result;
            }
            catch
            {
                trans.Rollback();
                throw;
            }
        }
        public int AtualizarPessoa(Pessoa pessoa)
        {
            pessoa.Validar();

            using var cn = new SqliteConnection("Data Source=BancoDados.db");
            cn.Open();

            using var trans = cn.BeginTransaction();

            try
            {
                var PessoaRepository = new PessoaRepository(cn, trans);
                var EnderecoRepository = new EnderecoRepository(cn, trans);
                var TelefoneRepository = new TelefoneRepository(cn, trans);

                int PessoaAtualizada = PessoaRepository.Atualizar(pessoa);

                if (PessoaAtualizada == 0)
                {
                    trans.Rollback();
                    return 0;
                }

                TelefoneRepository.DeletarPorPessoaId(pessoa.Id);

                foreach (var telefone in pessoa.Telefones)
                {
                    telefone.PessoaId = pessoa.Id;
                    TelefoneRepository.Inserir(telefone);
                }

                EnderecoRepository.DeletarPorPessoaId(pessoa.Id);

                foreach (var endereco in pessoa.Enderecos)
                {
                    endereco.PessoaId = pessoa.Id;
                    EnderecoRepository.Inserir(endereco);
                }

                trans.Commit();
                return 1;
            }
            catch
            {
                trans.Rollback();
                throw;
            }
        }
        public int AdicionarTelefone(int pessoaId, Telefone telefone)
        {
            telefone.Validar();

            using var cn = new SqliteConnection("Data Source=BancoDados.db");
            cn.Open();

            using var trans = cn.BeginTransaction();

            try
            {
                var TelefoneRepository = new TelefoneRepository(cn, trans);

                telefone.PessoaId = pessoaId;

                int id = TelefoneRepository.Inserir(telefone);

                trans.Commit();

                return id;
            }
            catch
            {
                trans.Rollback();
                throw;
            }
        }
        public int AtualizarTelefone(int id, Telefone telefone)
        {
            telefone.Validar();

            using var cn = new SqliteConnection("Data Source=BancoDados.db");
            cn.Open();

            using var trans = cn.BeginTransaction();

            try
            {
                var TelefoneRepository = new TelefoneRepository(cn, trans);

                telefone.Id = id;

                int TelefoneAtualizado = TelefoneRepository.Atualizar(telefone);

                trans.Commit();

                return TelefoneAtualizado;
            }
            catch
            {
                trans.Rollback();
                throw;
            }
        }
        public int DeletarTelefone(int id)
        {
            using var cn = new SqliteConnection("Data Source=BancoDados.db");
            cn.Open();

            using var trans = cn.BeginTransaction();
            try
            {
                var TelefoneRepository = new TelefoneRepository(cn, trans);
                int result = TelefoneRepository.Deletar(id);
                trans.Commit();
                return result;
            }
            catch
            {
                trans.Rollback();
                throw;
            }
        }
        public Telefone? ObterTelefone(int id)
        {
            using var cn = new SqliteConnection("Data Source=BancoDados.db");
            cn.Open();

            var trans = cn.BeginTransaction();

            try
            {
                var TelefoneRepository = new TelefoneRepository(cn, trans);

                var telefone = TelefoneRepository.ObterPorId(id);

                trans.Commit();

                return telefone;
            }
            catch
            {
                trans.Rollback();
                throw;
            }
        }
        public int AdicionarEndereco(int pessoaId, Endereco endereco)
        {
            endereco.Validar();

            using var cn = new SqliteConnection("Data Source=BancoDados.db");
            cn.Open();

            using var trans = cn.BeginTransaction();
            try
            {
                var EnderecoRepository = new EnderecoRepository(cn, trans);

                if (endereco.IsPrincipal == true)
                {
                    EnderecoRepository.RemoverPrincipalDaPessoa(pessoaId);
                }

                endereco.PessoaId = pessoaId;

                int id = EnderecoRepository.Inserir(endereco);

                trans.Commit();

                return id;
            }
            catch
            {
                trans.Rollback();
                throw;
            }
        }
        public int AtualizarEndereco(int id, Endereco endereco)
        {
            endereco.Validar();

            using var cn = new SqliteConnection("Data Source=BancoDados.db");
            cn.Open();

            using var trans = cn.BeginTransaction();

            try
            {
                var EnderecoRepository = new EnderecoRepository(cn, trans);

                var BuscarEndereco = EnderecoRepository.ObterPorId(id);

                if (BuscarEndereco == null)
                {
                    trans.Rollback();
                    return 0;
                }

                endereco.Id = id;
                endereco.PessoaId = BuscarEndereco.PessoaId;

                if (endereco.IsPrincipal)
                {
                    EnderecoRepository.RemoverPrincipalDaPessoa(endereco.PessoaId);
                }

                int EnderecoAtualizado = EnderecoRepository.Atualizar(endereco);

                trans.Commit();

                return EnderecoAtualizado;
            }
            catch
            {
                trans.Rollback();
                throw;
            }
        }
        public int DeletarEndereco(int id)
        {
            using var cn = new SqliteConnection("Data Source=BancoDados.db");
            cn.Open();

            using var trans = cn.BeginTransaction();

            try
            {
                var EnderecoRepository = new EnderecoRepository(cn, trans);

                var endereco = EnderecoRepository.ObterPorId(id);

                if (endereco == null)
                {
                    trans.Rollback();
                    return 0;
                }

                var EnderecosDaPessoa = EnderecoRepository.Listar(endereco.PessoaId);

                if (EnderecosDaPessoa.Count == 1)
                {
                    throw new Exception("A pessoa deve possuir ao menos um endereço!");
                }

                if (endereco.IsPrincipal == true)
                {
                    throw new Exception("Defina outro endereço como principal antes de deletar esse!");
                }

                int linhas = EnderecoRepository.Deletar(id);

                trans.Commit();

                return linhas;
            }
            catch
            {
                trans.Rollback();
                throw;
            }
        }
        public Endereco ObterEndereco(int id)
        {
            using var cn = new SqliteConnection("Data Source=BancoDados.db");
            cn.Open();

            using var trans = cn.BeginTransaction();

            try
            {
                var enderecoRepository = new EnderecoRepository(cn, trans);

                var endereco = enderecoRepository.ObterPorId(id);

                trans.Commit();

                return endereco;
            }
            catch
            {
                trans.Rollback();
                throw;
            }
        }
        public List<Pessoa> BuscarPessoas(string? busca, string? TipoBusca)
        {
            using var cn = new SqliteConnection("Data Source=BancoDados.db");
            cn.Open();

            var PessoaRepository = new PessoaRepository(cn, null);

            return PessoaRepository.Buscar(busca, TipoBusca);
        }
    }
}
