namespace Desafio.Forms
{
    partial class FormAdicionarEndereco
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtNumero = new TextBox();
            label12 = new Label();
            chkPrincipal = new CheckBox();
            txtLogradouro = new TextBox();
            txtCidade = new TextBox();
            txtBairro = new TextBox();
            txtComplemento = new TextBox();
            txtCEP = new TextBox();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            btnSalvarNovoEnd = new Button();
            btnCancelarNovoEnd = new Button();
            label18 = new Label();
            LimparEnd = new Button();
            cbxEstados = new ComboBox();
            SuspendLayout();
            // 
            // txtNumero
            // 
            txtNumero.Font = new Font("Segoe UI", 7F);
            txtNumero.Location = new Point(373, 119);
            txtNumero.Name = "txtNumero";
            txtNumero.Size = new Size(74, 20);
            txtNumero.TabIndex = 2;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Arial Narrow", 11F, FontStyle.Bold);
            label12.Location = new Point(373, 96);
            label12.Name = "label12";
            label12.Size = new Size(57, 20);
            label12.TabIndex = 14;
            label12.Text = "Número";
            // 
            // chkPrincipal
            // 
            chkPrincipal.AutoSize = true;
            chkPrincipal.Font = new Font("Arial Narrow", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            chkPrincipal.Location = new Point(202, 229);
            chkPrincipal.Name = "chkPrincipal";
            chkPrincipal.Size = new Size(125, 20);
            chkPrincipal.TabIndex = 7;
            chkPrincipal.Text = "Endereço Principal";
            chkPrincipal.UseVisualStyleBackColor = true;
            // 
            // txtLogradouro
            // 
            txtLogradouro.Font = new Font("Segoe UI", 7F);
            txtLogradouro.Location = new Point(202, 119);
            txtLogradouro.Name = "txtLogradouro";
            txtLogradouro.Size = new Size(147, 20);
            txtLogradouro.TabIndex = 1;
            // 
            // txtCidade
            // 
            txtCidade.Font = new Font("Segoe UI", 7F);
            txtCidade.Location = new Point(202, 179);
            txtCidade.Name = "txtCidade";
            txtCidade.Size = new Size(147, 20);
            txtCidade.TabIndex = 4;
            // 
            // txtBairro
            // 
            txtBairro.Font = new Font("Segoe UI", 7F);
            txtBairro.Location = new Point(28, 179);
            txtBairro.Name = "txtBairro";
            txtBairro.Size = new Size(147, 20);
            txtBairro.TabIndex = 3;
            // 
            // txtComplemento
            // 
            txtComplemento.Font = new Font("Segoe UI", 7F);
            txtComplemento.Location = new Point(28, 229);
            txtComplemento.Name = "txtComplemento";
            txtComplemento.Size = new Size(147, 20);
            txtComplemento.TabIndex = 6;
            // 
            // txtCEP
            // 
            txtCEP.Font = new Font("Segoe UI", 7F);
            txtCEP.Location = new Point(28, 119);
            txtCEP.MaxLength = 8;
            txtCEP.Name = "txtCEP";
            txtCEP.Size = new Size(147, 20);
            txtCEP.TabIndex = 0;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Arial Narrow", 11F, FontStyle.Bold);
            label11.Location = new Point(373, 156);
            label11.Name = "label11";
            label11.Size = new Size(51, 20);
            label11.TabIndex = 17;
            label11.Text = "Estado";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Arial Narrow", 11F, FontStyle.Bold);
            label10.Location = new Point(202, 156);
            label10.Name = "label10";
            label10.Size = new Size(52, 20);
            label10.TabIndex = 16;
            label10.Text = "Cidade";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Arial Narrow", 11F, FontStyle.Bold);
            label9.Location = new Point(28, 156);
            label9.Name = "label9";
            label9.Size = new Size(47, 20);
            label9.TabIndex = 15;
            label9.Text = "Bairro";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Arial Narrow", 11F, FontStyle.Bold);
            label8.Location = new Point(28, 206);
            label8.Name = "label8";
            label8.Size = new Size(94, 20);
            label8.TabIndex = 18;
            label8.Text = "Complemento";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Arial Narrow", 11F, FontStyle.Bold);
            label7.Location = new Point(202, 96);
            label7.Name = "label7";
            label7.Size = new Size(82, 20);
            label7.TabIndex = 13;
            label7.Text = "Logradouro";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Arial Narrow", 11F, FontStyle.Bold);
            label6.Location = new Point(28, 96);
            label6.Name = "label6";
            label6.Size = new Size(34, 20);
            label6.TabIndex = 12;
            label6.Text = "CEP";
            // 
            // btnSalvarNovoEnd
            // 
            btnSalvarNovoEnd.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSalvarNovoEnd.ForeColor = SystemColors.ControlText;
            btnSalvarNovoEnd.Location = new Point(121, 334);
            btnSalvarNovoEnd.Name = "btnSalvarNovoEnd";
            btnSalvarNovoEnd.Size = new Size(88, 43);
            btnSalvarNovoEnd.TabIndex = 9;
            btnSalvarNovoEnd.Text = "Salvar";
            btnSalvarNovoEnd.UseVisualStyleBackColor = true;
            btnSalvarNovoEnd.Click += btnSalvarNovoEnd_Click;
            // 
            // btnCancelarNovoEnd
            // 
            btnCancelarNovoEnd.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancelarNovoEnd.ForeColor = SystemColors.ControlText;
            btnCancelarNovoEnd.Location = new Point(239, 334);
            btnCancelarNovoEnd.Name = "btnCancelarNovoEnd";
            btnCancelarNovoEnd.Size = new Size(88, 43);
            btnCancelarNovoEnd.TabIndex = 10;
            btnCancelarNovoEnd.Text = "Cancelar";
            btnCancelarNovoEnd.UseVisualStyleBackColor = true;
            btnCancelarNovoEnd.Click += btnCancelarNovoEnd_Click;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label18.ForeColor = SystemColors.HotTrack;
            label18.Location = new Point(184, 32);
            label18.Name = "label18";
            label18.Size = new Size(100, 22);
            label18.TabIndex = 11;
            label18.Text = "Endereço";
            // 
            // LimparEnd
            // 
            LimparEnd.Location = new Point(392, 225);
            LimparEnd.Name = "LimparEnd";
            LimparEnd.Size = new Size(55, 24);
            LimparEnd.TabIndex = 8;
            LimparEnd.Text = "Limpar";
            LimparEnd.UseVisualStyleBackColor = true;
            LimparEnd.Click += LimparEnd_Click;
            // 
            // cbxEstados
            // 
            cbxEstados.FormattingEnabled = true;
            cbxEstados.Location = new Point(373, 179);
            cbxEstados.Name = "cbxEstados";
            cbxEstados.Size = new Size(74, 23);
            cbxEstados.TabIndex = 5;
            // 
            // FormAdicionarEndereco
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(476, 395);
            Controls.Add(cbxEstados);
            Controls.Add(LimparEnd);
            Controls.Add(label18);
            Controls.Add(btnCancelarNovoEnd);
            Controls.Add(btnSalvarNovoEnd);
            Controls.Add(txtNumero);
            Controls.Add(label12);
            Controls.Add(chkPrincipal);
            Controls.Add(txtLogradouro);
            Controls.Add(txtCidade);
            Controls.Add(txtBairro);
            Controls.Add(txtComplemento);
            Controls.Add(txtCEP);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Name = "FormAdicionarEndereco";
            Text = "AdicionarEndereco";
            Load += FormAdicionarEndereco_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNumero;
        private Label label12;
        private CheckBox chkPrincipal;
        private TextBox txtLogradouro;
        private TextBox txtCidade;
        private TextBox txtBairro;
        private TextBox txtComplemento;
        private TextBox txtCEP;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Button btnSalvarNovoEnd;
        private Button btnCancelarNovoEnd;
        private Label label18;
        private Button LimparEnd;
        private ComboBox cbxEstados;
    }
}