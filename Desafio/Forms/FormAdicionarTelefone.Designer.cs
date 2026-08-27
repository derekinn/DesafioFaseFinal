namespace Desafio.Forms
{
    partial class FormAdicionarTelefone
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
            label17 = new Label();
            LimparTel = new Button();
            txtDDD = new TextBox();
            txtNumCel = new TextBox();
            label15 = new Label();
            label14 = new Label();
            label13 = new Label();
            btnCancelarNovoTel = new Button();
            btnSalvarNovoTel = new Button();
            cbxTiposTelefone = new ComboBox();
            SuspendLayout();
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label17.ForeColor = SystemColors.HotTrack;
            label17.Location = new Point(155, 20);
            label17.Name = "label17";
            label17.Size = new Size(90, 22);
            label17.TabIndex = 6;
            label17.Text = "Telefone";
            // 
            // LimparTel
            // 
            LimparTel.Location = new Point(240, 154);
            LimparTel.Name = "LimparTel";
            LimparTel.Size = new Size(57, 23);
            LimparTel.TabIndex = 3;
            LimparTel.Text = "Limpar";
            LimparTel.UseVisualStyleBackColor = true;
            LimparTel.Click += LimparTel_Click;
            // 
            // txtDDD
            // 
            txtDDD.Font = new Font("Segoe UI", 7F);
            txtDDD.Location = new Point(60, 91);
            txtDDD.MaxLength = 3;
            txtDDD.Name = "txtDDD";
            txtDDD.Size = new Size(63, 20);
            txtDDD.TabIndex = 0;
            // 
            // txtNumCel
            // 
            txtNumCel.Font = new Font("Segoe UI", 7F);
            txtNumCel.Location = new Point(150, 91);
            txtNumCel.MaxLength = 9;
            txtNumCel.Name = "txtNumCel";
            txtNumCel.Size = new Size(147, 20);
            txtNumCel.TabIndex = 1;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Arial Narrow", 11F, FontStyle.Bold);
            label15.Location = new Point(150, 68);
            label15.Name = "label15";
            label15.Size = new Size(57, 20);
            label15.TabIndex = 8;
            label15.Text = "Número";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Arial Narrow", 11F, FontStyle.Bold);
            label14.Location = new Point(60, 131);
            label14.Name = "label14";
            label14.Size = new Size(37, 20);
            label14.TabIndex = 9;
            label14.Text = "Tipo";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Arial Narrow", 11F, FontStyle.Bold);
            label13.Location = new Point(60, 68);
            label13.Name = "label13";
            label13.Size = new Size(36, 20);
            label13.TabIndex = 7;
            label13.Text = "DDD";
            // 
            // btnCancelarNovoTel
            // 
            btnCancelarNovoTel.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancelarNovoTel.ForeColor = SystemColors.ControlText;
            btnCancelarNovoTel.Location = new Point(209, 312);
            btnCancelarNovoTel.Name = "btnCancelarNovoTel";
            btnCancelarNovoTel.Size = new Size(88, 43);
            btnCancelarNovoTel.TabIndex = 5;
            btnCancelarNovoTel.Text = "Cancelar";
            btnCancelarNovoTel.UseVisualStyleBackColor = true;
            btnCancelarNovoTel.Click += btnCancelarNovoTel_Click;
            // 
            // btnSalvarNovoTel
            // 
            btnSalvarNovoTel.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSalvarNovoTel.ForeColor = SystemColors.ControlText;
            btnSalvarNovoTel.Location = new Point(89, 312);
            btnSalvarNovoTel.Name = "btnSalvarNovoTel";
            btnSalvarNovoTel.Size = new Size(88, 43);
            btnSalvarNovoTel.TabIndex = 4;
            btnSalvarNovoTel.Text = "Salvar";
            btnSalvarNovoTel.UseVisualStyleBackColor = true;
            btnSalvarNovoTel.Click += btnSalvarNovoTel_Click;
            // 
            // cbxTiposTelefone
            // 
            cbxTiposTelefone.FormattingEnabled = true;
            cbxTiposTelefone.Location = new Point(60, 154);
            cbxTiposTelefone.Name = "cbxTiposTelefone";
            cbxTiposTelefone.Size = new Size(124, 23);
            cbxTiposTelefone.TabIndex = 2;
            // 
            // FormAdicionarTelefone
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 369);
            Controls.Add(cbxTiposTelefone);
            Controls.Add(btnCancelarNovoTel);
            Controls.Add(btnSalvarNovoTel);
            Controls.Add(label17);
            Controls.Add(LimparTel);
            Controls.Add(txtDDD);
            Controls.Add(txtNumCel);
            Controls.Add(label15);
            Controls.Add(label14);
            Controls.Add(label13);
            Name = "FormAdicionarTelefone";
            Text = "FormAdicionarTelefone";
            Load += FormAdicionarTelefone_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label17;
        private Button LimparTel;
        private TextBox txtDDD;
        private TextBox txtNumCel;
        private Label label15;
        private Label label14;
        private Label label13;
        private Button btnCancelarNovoTel;
        private Button btnSalvarNovoTel;
        private ComboBox cbxTiposTelefone;
    }
}