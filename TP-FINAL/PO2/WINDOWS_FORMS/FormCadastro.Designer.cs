namespace WINDOWS_FORMS
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
            this.lblInputNome = new System.Windows.Forms.Label();
            this.lblInputSenha = new System.Windows.Forms.Label();
            this.lblInputStatus = new System.Windows.Forms.Label();
            this.txtBoxNome = new System.Windows.Forms.TextBox();
            this.txtBoxSenha = new System.Windows.Forms.TextBox();
            this.chkBoxStatus = new System.Windows.Forms.CheckBox();
            this.btnRetorna = new System.Windows.Forms.Button();
            this.btnCadastrarUsuario = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblInputNome
            // 
            this.lblInputNome.AutoSize = true;
            this.lblInputNome.Location = new System.Drawing.Point(66, 60);
            this.lblInputNome.Name = "lblInputNome";
            this.lblInputNome.Size = new System.Drawing.Size(35, 13);
            this.lblInputNome.TabIndex = 0;
            this.lblInputNome.Text = "Nome";
            this.lblInputNome.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblInputSenha
            // 
            this.lblInputSenha.AutoSize = true;
            this.lblInputSenha.Location = new System.Drawing.Point(66, 94);
            this.lblInputSenha.Name = "lblInputSenha";
            this.lblInputSenha.Size = new System.Drawing.Size(38, 13);
            this.lblInputSenha.TabIndex = 1;
            this.lblInputSenha.Text = "Senha";
            // 
            // lblInputStatus
            // 
            this.lblInputStatus.AutoSize = true;
            this.lblInputStatus.Location = new System.Drawing.Point(66, 132);
            this.lblInputStatus.Name = "lblInputStatus";
            this.lblInputStatus.Size = new System.Drawing.Size(37, 13);
            this.lblInputStatus.TabIndex = 2;
            this.lblInputStatus.Text = "Status";
            // 
            // txtBoxNome
            // 
            this.txtBoxNome.Location = new System.Drawing.Point(168, 57);
            this.txtBoxNome.Name = "txtBoxNome";
            this.txtBoxNome.Size = new System.Drawing.Size(100, 20);
            this.txtBoxNome.TabIndex = 3;
            // 
            // txtBoxSenha
            // 
            this.txtBoxSenha.Location = new System.Drawing.Point(168, 91);
            this.txtBoxSenha.Name = "txtBoxSenha";
            this.txtBoxSenha.Size = new System.Drawing.Size(100, 20);
            this.txtBoxSenha.TabIndex = 5;
            // 
            // chkBoxStatus
            // 
            this.chkBoxStatus.AutoSize = true;
            this.chkBoxStatus.Location = new System.Drawing.Point(168, 132);
            this.chkBoxStatus.Name = "chkBoxStatus";
            this.chkBoxStatus.Size = new System.Drawing.Size(50, 17);
            this.chkBoxStatus.TabIndex = 6;
            this.chkBoxStatus.Text = "Ativo";
            this.chkBoxStatus.UseVisualStyleBackColor = true;
            // 
            // btnRetorna
            // 
            this.btnRetorna.Location = new System.Drawing.Point(69, 191);
            this.btnRetorna.Name = "btnRetorna";
            this.btnRetorna.Size = new System.Drawing.Size(75, 23);
            this.btnRetorna.TabIndex = 7;
            this.btnRetorna.Text = "Cancelar";
            this.btnRetorna.UseVisualStyleBackColor = true;
            this.btnRetorna.Click += new System.EventHandler(this.btnRetorna_Click);
            // 
            // btnCadastrarUsuario
            // 
            this.btnCadastrarUsuario.Location = new System.Drawing.Point(193, 191);
            this.btnCadastrarUsuario.Name = "btnCadastrarUsuario";
            this.btnCadastrarUsuario.Size = new System.Drawing.Size(75, 23);
            this.btnCadastrarUsuario.TabIndex = 8;
            this.btnCadastrarUsuario.Text = "Cadastrar";
            this.btnCadastrarUsuario.UseVisualStyleBackColor = true;
            this.btnCadastrarUsuario.Click += new System.EventHandler(this.btnCadastrarUsuario_Click);
            // 
            // FormCadastro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 282);
            this.Controls.Add(this.btnCadastrarUsuario);
            this.Controls.Add(this.btnRetorna);
            this.Controls.Add(this.chkBoxStatus);
            this.Controls.Add(this.txtBoxSenha);
            this.Controls.Add(this.txtBoxNome);
            this.Controls.Add(this.lblInputStatus);
            this.Controls.Add(this.lblInputSenha);
            this.Controls.Add(this.lblInputNome);
            this.Name = "FormCadastro";
            this.Text = "Cadastrar Usuário";
            this.Load += new System.EventHandler(this.FormCadastro_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInputNome;
        private System.Windows.Forms.Label lblInputSenha;
        private System.Windows.Forms.Label lblInputStatus;
        private System.Windows.Forms.TextBox txtBoxNome;
        private System.Windows.Forms.TextBox txtBoxSenha;
        private System.Windows.Forms.CheckBox chkBoxStatus;
        private System.Windows.Forms.Button btnRetorna;
        private System.Windows.Forms.Button btnCadastrarUsuario;
    }
}