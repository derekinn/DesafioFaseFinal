using Desafio.Models;

namespace Desafio.Forms
{
    public partial class FormAdicionarTelefone : Form
    {
        private readonly List<Telefone> telefones = new();

        private Telefone? TelefoneEdicao;

        public List<Telefone> Telefones => telefones;

        public FormAdicionarTelefone()
        {
            InitializeComponent();
        }
        public FormAdicionarTelefone(Telefone telefone) : this()
        {
            TelefoneEdicao = telefone;
        }

        private void FormAdicionarTelefone_Load(object sender, EventArgs e)
        {
            cbxTiposTelefone.Items.Clear();
            cbxTiposTelefone.DropDownStyle = ComboBoxStyle.DropDownList;

            cbxTiposTelefone.Items.Add("Pessoal");
            cbxTiposTelefone.Items.Add("Comercial");
            cbxTiposTelefone.Items.Add("Whatsapp");

            if (TelefoneEdicao != null)
            {
                txtDDD.Text = TelefoneEdicao.DDD;
                txtNumCel.Text = TelefoneEdicao.Numero;

                cbxTiposTelefone.SelectedItem = TelefoneEdicao.Tipo;
            }
            else
            {
                cbxTiposTelefone.SelectedIndex = 0;
            }
        }

        private void btnSalvarNovoTel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDDD.Text) ||
                string.IsNullOrWhiteSpace(txtNumCel.Text))
            {
                MessageBox.Show(
                    "DDD e número são obrigatórios.",
                    "Atenção",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (TelefoneEdicao != null)
            {
                TelefoneEdicao.DDD = txtDDD.Text.Trim();
                TelefoneEdicao.Numero = txtNumCel.Text.Trim();
                TelefoneEdicao.Tipo =
                    cbxTiposTelefone.SelectedItem?.ToString() ?? "Pessoal";

                DialogResult = DialogResult.OK;
                Close();

                return;
            }

            var NovoTelefone = new Telefone
            {
                DDD = txtDDD.Text.Trim(),
                Numero = txtNumCel.Text.Trim(),
                Tipo = cbxTiposTelefone.SelectedItem?.ToString() ?? "Pessoal"
            };

            telefones.Add(NovoTelefone);

            var resposta = MessageBox.Show(
                "Telefone cadastrado com sucesso!\n\nDeseja cadastrar outro telefone?",
                "Novo telefone",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resposta == DialogResult.Yes)
            {
                LimparCamposTelefone();

                txtDDD.Focus();

                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void LimparCamposTelefone()
        {
            txtDDD.Clear();
            txtNumCel.Clear();

            cbxTiposTelefone.SelectedIndex = 0;
        }

        private void LimparTel_Click(object sender, EventArgs e)
        {
            LimparCamposTelefone();
        }

        private void btnCancelarNovoTel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}