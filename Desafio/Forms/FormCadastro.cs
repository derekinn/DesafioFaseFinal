using Desafio.Forms;
using Desafio.Models;
using System.Text;
using System.Text.Json;

namespace Desafio
{
    public partial class FormCadastro : Form
    {
        private readonly List<Endereco> enderecos = new();
        private readonly List<Telefone> telefones = new();

        private Pessoa? PessoaEdicao;

        public FormCadastro()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        public FormCadastro(Pessoa pessoa) : this()
        {
            PessoaEdicao = pessoa;

            txtNome.Text = pessoa.Nome;
            txtCPF.Text = pessoa.CPF;
            txtEmail.Text = pessoa.Email;

            dtpDataNascimento.Value =
                pessoa.DataNascimento.ToDateTime(TimeOnly.MinValue);

            enderecos.AddRange(pessoa.Enderecos);
            telefones.AddRange(pessoa.Telefones);

            AtualizarGridEnderecos();
            AtualizarGridTelefones();
        }

        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            if (enderecos.Count == 0)
            {
                MessageBox.Show(
                    "Cadastre pelo menos um endereço antes de salvar.",
                    "Atenção",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (!enderecos.Any(e => e.IsPrincipal))
            {
                MessageBox.Show(
                    "Defina um endereço como principal antes de salvar.",
                    "Atenção",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            var pessoa = new Pessoa
            {
                Nome = txtNome.Text.Trim(),
                CPF = txtCPF.Text.Trim(),
                DataNascimento = DateOnly.FromDateTime(dtpDataNascimento.Value),
                Email = txtEmail.Text.Trim(),
                Enderecos = new List<Endereco>(),
                Telefones = new List<Telefone>()
            };

            pessoa.Enderecos.AddRange(enderecos);

            pessoa.Telefones.AddRange(telefones);

            if (PessoaEdicao != null)
            {
                pessoa.Id = PessoaEdicao.Id;
            }

            string json = JsonSerializer.Serialize(pessoa);

            using var http = new HttpClient();

            var conteudo = new StringContent(
                json,
                Encoding.UTF8,
                "application/json"
            );

            HttpResponseMessage response;

            if (PessoaEdicao == null)
            {
                response = await http.PostAsync("https://localhost:7234/api/Agenda", conteudo);
            }

            else
            {
                response = await http.PutAsync($"https://localhost:7234/api/Agenda/{pessoa.Id}", conteudo);
            }

            string resposta =await response.Content.ReadAsStringAsync();

            var resultado =
                JsonSerializer.Deserialize<ResponseAPI>(
                    resposta,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

            if (resultado?.Success == true)
            {
                MessageBox.Show(
                    PessoaEdicao == null
                        ? "Pessoa cadastrada com sucesso!"
                        : "Pessoa atualizada com sucesso!",
                    "Sucesso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show(
                    resultado?.Error ??
                    (PessoaEdicao == null
                        ? "Erro ao cadastrar pessoa."
                        : "Erro ao atualizar pessoa."),
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAdicionarEnd_Click(object sender, EventArgs e)
        {
            using var form =
                new FormAdicionarEndereco();

            if (form.ShowDialog() == DialogResult.OK)
            {
                foreach (var endereco in form.Enderecos)
                {
                    if (endereco.IsPrincipal)
                    {
                        foreach (var existente in enderecos)
                        {
                            existente.IsPrincipal = false;
                        }
                    }

                    enderecos.Add(endereco);
                }

                AtualizarGridEnderecos();
            }
        }

        private void btnAlterarEnd_Click(object sender, EventArgs e)
        {
            if (DGVEnderecos.CurrentRow == null)
            {
                MessageBox.Show(
                    "Selecione um endereço para alterar.",
                    "Atenção",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            var endereco = DGVEnderecos.CurrentRow.DataBoundItem as Endereco;

            if (endereco == null)
                return;

            using var form = new FormAdicionarEndereco(endereco);

            if (form.ShowDialog() == DialogResult.OK)
            {
                var EnderecoAtualizado = form.Enderecos.FirstOrDefault();

                if (EnderecoAtualizado == null)
                    return;

                if (EnderecoAtualizado.IsPrincipal)
                {
                    foreach (var OutroEndereco in enderecos)
                    {
                        OutroEndereco.IsPrincipal = false;
                    }
                }

                endereco.Cep = EnderecoAtualizado.Cep;
                endereco.Logradouro = EnderecoAtualizado.Logradouro;
                endereco.Numero = EnderecoAtualizado.Numero;
                endereco.Complemento = EnderecoAtualizado.Complemento;
                endereco.Bairro = EnderecoAtualizado.Bairro;
                endereco.Cidade = EnderecoAtualizado.Cidade;
                endereco.Estado = EnderecoAtualizado.Estado;
                endereco.IsPrincipal = EnderecoAtualizado.IsPrincipal;

                AtualizarGridEnderecos();
            }
        }

        private void btnRemoverEnd_Click(object sender, EventArgs e)
        {
            if (DGVEnderecos.CurrentRow == null)
            {
                MessageBox.Show(
                    "Selecione um endereço para remover.",
                    "Atenção",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            var endereco = DGVEnderecos.CurrentRow.DataBoundItem as Endereco;

            if (endereco == null)
                return;

            if (enderecos.Count == 1)
            {
                MessageBox.Show(
                    "A pessoa deve possuir pelo menos um endereço.",
                    "Atenção",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }
            if (endereco.IsPrincipal)
            {
                MessageBox.Show(
                    "Defina outro endereço como principal antes de removê-lo.",
                    "Atenção",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }
            var confirmacao = MessageBox.Show(
                "Tem certeza que deseja remover este endereço?",
                "Confirmar remoção",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacao != DialogResult.Yes)
                return;

            enderecos.Remove(endereco);

            AtualizarGridEnderecos();
        }
        private void AtualizarGridEnderecos()
        {
            DGVEnderecos.DataSource = null;
            DGVEnderecos.DataSource = enderecos;

            if (DGVEnderecos.Columns.Count == 0)
                return;

            if (DGVEnderecos.Columns.Contains("Id"))
                DGVEnderecos.Columns["Id"]!.Visible = false;

            if (DGVEnderecos.Columns.Contains("PessoaId"))
                DGVEnderecos.Columns["PessoaId"]!.Visible = false;

            DGVEnderecos.Columns["Cep"]!.HeaderText = "CEP";
            DGVEnderecos.Columns["Logradouro"]!.HeaderText = "Rua";
            DGVEnderecos.Columns["Numero"]!.HeaderText = "Nº";
            DGVEnderecos.Columns["Complemento"]!.HeaderText = "Complemento";
            DGVEnderecos.Columns["Bairro"]!.HeaderText = "Bairro";
            DGVEnderecos.Columns["Cidade"]!.HeaderText = "Cidade";
            DGVEnderecos.Columns["Estado"]!.HeaderText = "UF";
            DGVEnderecos.Columns["IsPrincipal"]!.HeaderText = "Principal";
        }
        private void btnAdicionarTel_Click(object sender, EventArgs e)
        {
            using var form = new FormAdicionarTelefone();

            if (form.ShowDialog() == DialogResult.OK)
            {
                telefones.AddRange(form.Telefones);

                AtualizarGridTelefones();
            }
        }
        private void btnAlterarTel_Click(object sender, EventArgs e)
        {
            if (DGVTelefones.CurrentRow == null)
            {
                MessageBox.Show(
                    "Selecione um telefone para alterar.",
                    "Atenção",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            var telefone = DGVTelefones.CurrentRow.DataBoundItem as Telefone;

            if (telefone == null)
            {
                MessageBox.Show(
                    "Não foi possível obter o telefone selecionado.",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            using var form = new FormAdicionarTelefone(telefone);

            if (form.ShowDialog() == DialogResult.OK)
            {
                AtualizarGridTelefones();
            }
        }

        private void btnRemoverTel_Click(object sender, EventArgs e)
        {
            if (DGVTelefones.CurrentRow == null)
            {
                MessageBox.Show(
                    "Selecione um telefone para remover.",
                    "Atenção",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            var telefone = DGVTelefones.CurrentRow.DataBoundItem as Telefone;

            if (telefone == null)
                return;

            var confirmacao = MessageBox.Show(
                "Tem certeza que deseja remover este telefone?",
                "Confirmar remoção",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacao != DialogResult.Yes)
                return;

            telefones.Remove(telefone);

            AtualizarGridTelefones();
        }

        private void AtualizarGridTelefones()
        {
            DGVTelefones.DataSource = null;
            DGVTelefones.DataSource = telefones;

            if (DGVTelefones.Columns.Count == 0)
                return;

            if (DGVTelefones.Columns.Contains("Id"))
                DGVTelefones.Columns["Id"]!.Visible = false;

            if (DGVTelefones.Columns.Contains("PessoaId"))
                DGVTelefones.Columns["PessoaId"]!.Visible = false;

            DGVTelefones.Columns["DDD"]!.HeaderText = "DDD";
            DGVTelefones.Columns["Numero"]!.HeaderText = "Número";
            DGVTelefones.Columns["Tipo"]!.HeaderText = "Tipo";
        }
        private void FormCadastro_Load(object sender, EventArgs e)
        {
            ConfigurarGridEnderecos();
            ConfigurarGridTelefones();
        }

        private void ConfigurarGridEnderecos()
        {
            DGVEnderecos.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            DGVEnderecos.AllowUserToAddRows = false;
            DGVEnderecos.ReadOnly = true;
            DGVEnderecos.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            DGVEnderecos.MultiSelect = false;
        }

        private void ConfigurarGridTelefones()
        {
            DGVTelefones.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            DGVTelefones.AllowUserToAddRows = false;
            DGVTelefones.ReadOnly = true;
            DGVTelefones.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            DGVTelefones.MultiSelect = false;
        }
    }
}