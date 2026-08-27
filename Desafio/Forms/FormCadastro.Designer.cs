namespace Desafio
{
    partial class FormCadastro
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
            label1 = new Label();
            label2 = new Label();
            btnSalvar = new Button();
            txtCPF = new TextBox();
            txtEmail = new TextBox();
            txtNome = new TextBox();
            dtpDataNascimento = new DateTimePicker();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            btnCancelar = new Button();
            DGVEnderecos = new DataGridView();
            DGVTelefones = new DataGridView();
            btnRemoverEnd = new Button();
            btnAdicionarTel = new Button();
            btnAdicionarEnd = new Button();
            btnRemoverTel = new Button();
            btnAlterarEnd = new Button();
            btnAlterarTel = new Button();
            label16 = new Label();
            label17 = new Label();
            label18 = new Label();
            ((System.ComponentModel.ISupportInitialize)DGVEnderecos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DGVTelefones).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Rounded MT Bold", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(158, 9);
            label1.Name = "label1";
            label1.Size = new Size(279, 32);
            label1.TabIndex = 14;
            label1.Text = "Cadastro de Pessoa";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial Narrow", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(114, 75);
            label2.Name = "label2";
            label2.Size = new Size(44, 20);
            label2.TabIndex = 16;
            label2.Text = "Nome";
            // 
            // btnSalvar
            // 
            btnSalvar.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSalvar.Location = new Point(127, 654);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(105, 37);
            btnSalvar.TabIndex = 12;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // txtCPF
            // 
            txtCPF.Font = new Font("Segoe UI", 7F);
            txtCPF.Location = new Point(288, 98);
            txtCPF.MaxLength = 11;
            txtCPF.Name = "txtCPF";
            txtCPF.Size = new Size(147, 20);
            txtCPF.TabIndex = 1;
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 7F);
            txtEmail.Location = new Point(114, 151);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(147, 20);
            txtEmail.TabIndex = 2;
            // 
            // txtNome
            // 
            txtNome.Font = new Font("Segoe UI", 7F);
            txtNome.Location = new Point(114, 98);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(147, 20);
            txtNome.TabIndex = 0;
            // 
            // dtpDataNascimento
            // 
            dtpDataNascimento.Font = new Font("Segoe UI", 8F);
            dtpDataNascimento.Format = DateTimePickerFormat.Short;
            dtpDataNascimento.Location = new Point(288, 151);
            dtpDataNascimento.Name = "dtpDataNascimento";
            dtpDataNascimento.Size = new Size(147, 22);
            dtpDataNascimento.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial Narrow", 11F, FontStyle.Bold);
            label3.Location = new Point(288, 75);
            label3.Name = "label3";
            label3.Size = new Size(34, 20);
            label3.TabIndex = 17;
            label3.Text = "CPF";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial Narrow", 11F, FontStyle.Bold);
            label4.Location = new Point(114, 131);
            label4.Name = "label4";
            label4.Size = new Size(43, 20);
            label4.TabIndex = 18;
            label4.Text = "Email";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial Narrow", 11F, FontStyle.Bold);
            label5.Location = new Point(288, 128);
            label5.Name = "label5";
            label5.Size = new Size(129, 20);
            label5.TabIndex = 19;
            label5.Text = "Data de Nascimento";
            // 
            // btnCancelar
            // 
            btnCancelar.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancelar.Location = new Point(301, 654);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(105, 37);
            btnCancelar.TabIndex = 13;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // DGVEnderecos
            // 
            DGVEnderecos.Location = new Point(32, 216);
            DGVEnderecos.Name = "DGVEnderecos";
            DGVEnderecos.Size = new Size(490, 150);
            DGVEnderecos.TabIndex = 4;
            // 
            // DGVTelefones
            // 
            DGVTelefones.Location = new Point(32, 440);
            DGVTelefones.Name = "DGVTelefones";
            DGVTelefones.Size = new Size(490, 150);
            DGVTelefones.TabIndex = 8;
            // 
            // btnRemoverEnd
            // 
            btnRemoverEnd.Location = new Point(371, 372);
            btnRemoverEnd.Name = "btnRemoverEnd";
            btnRemoverEnd.Size = new Size(100, 30);
            btnRemoverEnd.TabIndex = 7;
            btnRemoverEnd.Text = "Remover";
            btnRemoverEnd.UseVisualStyleBackColor = true;
            btnRemoverEnd.Click += btnRemoverEnd_Click;
            // 
            // btnAdicionarTel
            // 
            btnAdicionarTel.Location = new Point(86, 596);
            btnAdicionarTel.Name = "btnAdicionarTel";
            btnAdicionarTel.Size = new Size(100, 30);
            btnAdicionarTel.TabIndex = 9;
            btnAdicionarTel.Text = "Adicionar";
            btnAdicionarTel.UseVisualStyleBackColor = true;
            btnAdicionarTel.Click += btnAdicionarTel_Click;
            // 
            // btnAdicionarEnd
            // 
            btnAdicionarEnd.Location = new Point(86, 372);
            btnAdicionarEnd.Name = "btnAdicionarEnd";
            btnAdicionarEnd.Size = new Size(100, 30);
            btnAdicionarEnd.TabIndex = 5;
            btnAdicionarEnd.Text = "Adicionar";
            btnAdicionarEnd.UseVisualStyleBackColor = true;
            btnAdicionarEnd.Click += btnAdicionarEnd_Click;
            // 
            // btnRemoverTel
            // 
            btnRemoverTel.Location = new Point(371, 596);
            btnRemoverTel.Name = "btnRemoverTel";
            btnRemoverTel.Size = new Size(100, 30);
            btnRemoverTel.TabIndex = 11;
            btnRemoverTel.Text = "Remover";
            btnRemoverTel.UseVisualStyleBackColor = true;
            btnRemoverTel.Click += btnRemoverTel_Click;
            // 
            // btnAlterarEnd
            // 
            btnAlterarEnd.Location = new Point(232, 372);
            btnAlterarEnd.Name = "btnAlterarEnd";
            btnAlterarEnd.Size = new Size(100, 30);
            btnAlterarEnd.TabIndex = 6;
            btnAlterarEnd.Text = "Alterar";
            btnAlterarEnd.UseVisualStyleBackColor = true;
            btnAlterarEnd.Click += btnAlterarEnd_Click;
            // 
            // btnAlterarTel
            // 
            btnAlterarTel.Location = new Point(232, 596);
            btnAlterarTel.Name = "btnAlterarTel";
            btnAlterarTel.Size = new Size(100, 30);
            btnAlterarTel.TabIndex = 10;
            btnAlterarTel.Text = "Alterar";
            btnAlterarTel.UseVisualStyleBackColor = true;
            btnAlterarTel.Click += btnAlterarTel_Click;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label16.ForeColor = SystemColors.HotTrack;
            label16.Location = new Point(232, 51);
            label16.Name = "label16";
            label16.Size = new Size(79, 22);
            label16.TabIndex = 15;
            label16.Text = "Pessoa";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label17.ForeColor = SystemColors.HotTrack;
            label17.Location = new Point(232, 415);
            label17.Name = "label17";
            label17.Size = new Size(90, 22);
            label17.TabIndex = 21;
            label17.Text = "Telefone";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label18.ForeColor = SystemColors.HotTrack;
            label18.Location = new Point(232, 191);
            label18.Name = "label18";
            label18.Size = new Size(100, 22);
            label18.TabIndex = 20;
            label18.Text = "Endereço";
            // 
            // FormCadastro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(554, 696);
            Controls.Add(label18);
            Controls.Add(label17);
            Controls.Add(label16);
            Controls.Add(btnAlterarTel);
            Controls.Add(btnAlterarEnd);
            Controls.Add(btnRemoverTel);
            Controls.Add(btnAdicionarEnd);
            Controls.Add(btnAdicionarTel);
            Controls.Add(btnRemoverEnd);
            Controls.Add(DGVTelefones);
            Controls.Add(DGVEnderecos);
            Controls.Add(btnCancelar);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(dtpDataNascimento);
            Controls.Add(txtNome);
            Controls.Add(txtEmail);
            Controls.Add(txtCPF);
            Controls.Add(btnSalvar);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormCadastro";
            Text = "Cadastro de Pessoa";
            Load += FormCadastro_Load;
            ((System.ComponentModel.ISupportInitialize)DGVEnderecos).EndInit();
            ((System.ComponentModel.ISupportInitialize)DGVTelefones).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Button btnSalvar;
        private TextBox txtCPF;
        private TextBox txtEmail;
        private TextBox txtNome;
        private DateTimePicker dtpDataNascimento;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button btnCancelar;
        private DataGridView DGVEnderecos;
        private DataGridView DGVTelefones;
        private Button btnRemoverEnd;
        private Button btnAdicionarTel;
        private Button btnAdicionarEnd;
        private Button btnRemoverTel;
        private Button btnAlterarEnd;
        private Button btnAlterarTel;
        private Label label16;
        private Label label17;
        private Label label18;
    }
}