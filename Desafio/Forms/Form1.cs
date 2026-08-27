using Desafio.Models;
using System.Text.Json;

namespace Desafio
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbxBuscar.Items.Clear();
            cbxBuscar.DropDownStyle = ComboBoxStyle.DropDownList;

            cbxBuscar.Items.AddRange(new string[]
            {
                "Nome",
                "CPF"
            });

            cbxBuscar.SelectedIndex = 0;

            DGVPessoas.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            DGVPessoas.MultiSelect = false;
            DGVPessoas.ReadOnly = true;
            DGVPessoas.AllowUserToAddRows = false;

            DGVPessoas.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
        }

        private async Task ListarPessoas()
        {
            using var http = new HttpClient();

            string url = "https://localhost:7234/api/Agenda";

            var response = await http.GetAsync(url);

            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();

            var resultado = JsonSerializer.Deserialize<ResponseAPI>(json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            DGVPessoas.DataSource = null;
            DGVPessoas.DataSource = resultado?.Pessoas;
        }

        private async Task BuscarPessoas(string busca, string TipoBusca)
        {
            using var http = new HttpClient();

            string url = $"https://localhost:7234/api/Agenda?busca={Uri.EscapeDataString(busca)}&TipoBusca={Uri.EscapeDataString(TipoBusca)}";

            var response = await http.GetAsync(url);

            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();

            var resultado = JsonSerializer.Deserialize<ResponseAPI>(
                json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            DGVPessoas.DataSource = null;
            DGVPessoas.DataSource = resultado?.Pessoas;
        }

        private async void btnListar_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            await ListarPessoas();
        }

        private async void btnCadastrar_Click(object sender, EventArgs e)
        {
            FormCadastro FormCadastro = new FormCadastro();

            var resultado = FormCadastro.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                await ListarPessoas();
            }
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            string busca = txtBuscar.Text.Trim();
            string TipoBusca = cbxBuscar.SelectedItem?.ToString() ?? "Nome";

            if (string.IsNullOrWhiteSpace(busca))
            {
                MessageBox.Show(
                    "Preencha o campo corretamente para  buscar!",
                    "Atenção",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (TipoBusca == "CPF")
            {
                if (busca.Length != 11 || !busca.All(char.IsDigit))
                {
                    MessageBox.Show(
                        "Digite um CPF com exatamente 11 dígitos!",
                        "Atenção",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }
            }

            await BuscarPessoas(busca, TipoBusca);
        }

        private async void btnExcluir_Click(object sender, EventArgs e)
        {
            if (DGVPessoas.CurrentRow == null)
            {
                MessageBox.Show("Selecione uma pessoa para excluir.");
                return;
            }

            var pessoa = (Pessoa)DGVPessoas.CurrentRow.DataBoundItem!;

            var confirmacao = MessageBox.Show(
                $"Deseja excluir {pessoa.Nome}?",
                "Confirmar exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacao != DialogResult.Yes)
                return;

            using var http = new HttpClient();

            string url = $"https://localhost:7234/api/Agenda/{pessoa.Id}";

            var response = await http.DeleteAsync(url);

            string json = await response.Content.ReadAsStringAsync();

            var resultado = JsonSerializer.Deserialize<ResponseAPI>(json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            if (resultado.Success == true)
            {
                MessageBox.Show("Pessoa excluída com sucesso!");
                await ListarPessoas();
            }
            else
            {
                MessageBox.Show(resultado?.Error ?? "Erro ao excluir pessoa.");
            }
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            if (DGVPessoas.CurrentRow == null)
            {
                MessageBox.Show("Selecione uma pessoa para edtiar.");
                return;
            }

            var PessoaSelecionada = (Pessoa)DGVPessoas.CurrentRow.DataBoundItem!;

            using var http = new HttpClient();

            string url = $"https://localhost:7234/api/Agenda/{PessoaSelecionada.Id}";

            var response = await http.GetAsync(url);

            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();

            var resultado = JsonSerializer.Deserialize<ResponsePessoa>(json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            if (resultado.Success != true || resultado.Pessoa == null)
            {
                MessageBox.Show("Erro ao carregar pessoa.");
                return;
            }

            FormCadastro FormCadastro = new FormCadastro(resultado.Pessoa);

            var dialog = FormCadastro.ShowDialog();

            if (dialog == DialogResult.OK)
            {
                await ListarPessoas();
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.UserClosing)
                return;

            var resposta = MessageBox.Show(
                "Deseja realmente sair do programa?",
                "Sair",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resposta == DialogResult.Yes)
            {
                Application.Exit();
                e.Cancel = false;
                return;
            }

            e.Cancel = true;
        }

        private void cbxBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBuscar.Clear();

            if (cbxBuscar.SelectedItem?.ToString() == "Nome")
            {
                txtBuscar.PlaceholderText = "Digite o nome";
            }
            else if (cbxBuscar.SelectedItem?.ToString() == "CPF")
            {
                txtBuscar.PlaceholderText = "Digite o CPF";
            }
        }
    }
}