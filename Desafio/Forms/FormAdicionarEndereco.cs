using Desafio.Models;

namespace Desafio.Forms
{
    public partial class FormAdicionarEndereco : Form
    {
        private readonly List<Endereco> enderecos = new();

        private Endereco? EnderecoEdicao;

        public List<Endereco> Enderecos => enderecos;

        public FormAdicionarEndereco()
        {
            InitializeComponent();
        }

        public FormAdicionarEndereco(Endereco endereco) : this()
        {
            EnderecoEdicao = endereco;
        }

        private void FormAdicionarEndereco_Load(object sender, EventArgs e)
        {
            cbxEstados.Items.Clear();
            cbxEstados.DropDownStyle = ComboBoxStyle.DropDownList;

            cbxEstados.Items.AddRange(new string[]
            {
                "AC", "AL", "AP", "AM", "BA", "CE", "DF", "ES",
                "GO", "MA", "MT", "MS", "MG", "PA", "PB", "PR",
                "PE", "PI", "RJ", "RN", "RS", "RO", "RR", "SC",
                "SP", "SE", "TO"
            });

            if (EnderecoEdicao != null)
            {
                txtCEP.Text = EnderecoEdicao.Cep;
                txtLogradouro.Text = EnderecoEdicao.Logradouro;
                txtNumero.Text = EnderecoEdicao.Numero;
                txtComplemento.Text = EnderecoEdicao.Complemento;
                txtBairro.Text = EnderecoEdicao.Bairro;
                txtCidade.Text = EnderecoEdicao.Cidade;

                cbxEstados.SelectedItem = EnderecoEdicao.Estado;

                chkPrincipal.Checked = EnderecoEdicao.IsPrincipal;
            }
            else
            {
                cbxEstados.SelectedIndex = -1;
            }
        }

        private void btnSalvarNovoEnd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCEP.Text) ||
                string.IsNullOrWhiteSpace(txtLogradouro.Text) ||
                string.IsNullOrWhiteSpace(txtNumero.Text) ||
                string.IsNullOrWhiteSpace(txtBairro.Text) ||
                string.IsNullOrWhiteSpace(txtCidade.Text))
            {
                MessageBox.Show(
                    "Preencha CEP, logradouro, número, bairro e cidade.",
                    "Atenção",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (cbxEstados.SelectedItem == null)
            {
                MessageBox.Show(
                    "Selecione uma UF.",
                    "Atenção",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (chkPrincipal.Checked)
            {
                foreach (var endereco in enderecos)
                {
                    endereco.IsPrincipal = false;
                }
            }

            var EnderecoAtualizado = new Endereco
            {
                Id = EnderecoEdicao?.Id ?? 0,
                PessoaId = EnderecoEdicao?.PessoaId ?? 0,
                Cep = txtCEP.Text.Trim(),
                Logradouro = txtLogradouro.Text.Trim(),
                Numero = txtNumero.Text.Trim(),
                Complemento = txtComplemento.Text.Trim(),
                Bairro = txtBairro.Text.Trim(),
                Cidade = txtCidade.Text.Trim(),
                Estado = cbxEstados.SelectedItem.ToString()!,
                IsPrincipal = chkPrincipal.Checked
            };

            if (EnderecoEdicao != null)
            {
                enderecos.Add(EnderecoAtualizado);

                DialogResult = DialogResult.OK;
                Close();

                return;
            }

            enderecos.Add(EnderecoAtualizado);

            var resposta = MessageBox.Show(
                "Endereço cadastrado com sucesso!\n\nDeseja cadastrar outro endereço?",
                "Novo endereço",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resposta == DialogResult.Yes)
            {
                LimparCamposEndereco();
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void LimparCamposEndereco()
        {
            txtCEP.Clear();
            txtLogradouro.Clear();
            txtNumero.Clear();
            txtComplemento.Clear();
            txtBairro.Clear();
            txtCidade.Clear();

            cbxEstados.SelectedIndex = -1;

            chkPrincipal.Checked = false;
        }

        private void LimparEnd_Click(object sender, EventArgs e)
        {
            LimparCamposEndereco();
        }

        private void btnCancelarNovoEnd_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}