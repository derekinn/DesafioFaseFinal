namespace Desafio
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnListar = new Button();
            DGVPessoas = new DataGridView();
            btnCadastrar = new Button();
            btnExcluir = new Button();
            btnEditar = new Button();
            btnSair = new Button();
            btnBuscar = new Button();
            txtBuscar = new TextBox();
            cbxBuscar = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)DGVPessoas).BeginInit();
            SuspendLayout();
            // 
            // btnListar
            // 
            btnListar.Location = new Point(299, 524);
            btnListar.Name = "btnListar";
            btnListar.Size = new Size(99, 42);
            btnListar.TabIndex = 5;
            btnListar.Text = "Listar";
            btnListar.UseVisualStyleBackColor = true;
            btnListar.Click += btnListar_Click;
            // 
            // DGVPessoas
            // 
            DGVPessoas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVPessoas.Location = new Point(23, 56);
            DGVPessoas.Name = "DGVPessoas";
            DGVPessoas.Size = new Size(652, 445);
            DGVPessoas.TabIndex = 2;
            // 
            // btnCadastrar
            // 
            btnCadastrar.Location = new Point(23, 524);
            btnCadastrar.Name = "btnCadastrar";
            btnCadastrar.Size = new Size(109, 42);
            btnCadastrar.TabIndex = 3;
            btnCadastrar.Text = "Cadastrar";
            btnCadastrar.UseVisualStyleBackColor = true;
            btnCadastrar.Click += btnCadastrar_Click;
            // 
            // btnExcluir
            // 
            btnExcluir.Location = new Point(429, 524);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(109, 42);
            btnExcluir.TabIndex = 6;
            btnExcluir.Text = "Excluir";
            btnExcluir.UseVisualStyleBackColor = true;
            btnExcluir.Click += btnExcluir_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(159, 524);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(109, 42);
            btnEditar.TabIndex = 4;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnSair
            // 
            btnSair.Location = new Point(566, 524);
            btnSair.Name = "btnSair";
            btnSair.Size = new Size(109, 42);
            btnSair.TabIndex = 7;
            btnSair.Text = "Sair";
            btnSair.UseVisualStyleBackColor = true;
            btnSair.Click += btnSair_Click;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(489, 12);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(74, 23);
            btnBuscar.TabIndex = 1;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(192, 12);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "                            Coloque nome ou CPF";
            txtBuscar.Size = new Size(291, 23);
            txtBuscar.TabIndex = 0;
            // 
            // cbxBuscar
            // 
            cbxBuscar.FormattingEnabled = true;
            cbxBuscar.Location = new Point(101, 12);
            cbxBuscar.Name = "cbxBuscar";
            cbxBuscar.Size = new Size(85, 23);
            cbxBuscar.TabIndex = 8;
            cbxBuscar.SelectedIndexChanged += cbxBuscar_SelectedIndexChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(705, 578);
            Controls.Add(btnBuscar);
            Controls.Add(txtBuscar);
            Controls.Add(cbxBuscar);
            Controls.Add(btnSair);
            Controls.Add(btnEditar);
            Controls.Add(btnExcluir);
            Controls.Add(btnCadastrar);
            Controls.Add(DGVPessoas);
            Controls.Add(btnListar);
            Name = "Form1";
            Text = "Pessoas";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)DGVPessoas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnListar;
        private TextBox txtBuscar;
        private DataGridView DGVPessoas;
        private Button btnCadastrar;
        private Button btnExcluir;
        private Button btnBuscar;
        private Button btnEditar;
        private Button btnSair;
        private ComboBox cbxBuscar;
    }
}
