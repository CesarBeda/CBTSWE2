namespace WINDOWS_FORMS
{
    partial class FormEditar
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
            this.btnEditarUsuario = new System.Windows.Forms.Button();
            this.btnRetorna = new System.Windows.Forms.Button();
            this.chkBoxStatusEditado = new System.Windows.Forms.CheckBox();
            this.txtBoxSenhaEditada = new System.Windows.Forms.TextBox();
            this.txtBoxNomeEditado = new System.Windows.Forms.TextBox();
            this.lblInputStatus = new System.Windows.Forms.Label();
            this.lblInputSenha = new System.Windows.Forms.Label();
            this.lblInputNome = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnEditarUsuario
            // 
            this.btnEditarUsuario.Location = new System.Drawing.Point(193, 222);
            this.btnEditarUsuario.Name = "btnEditarUsuario";
            this.btnEditarUsuario.Size = new System.Drawing.Size(75, 23);
            this.btnEditarUsuario.TabIndex = 16;
            this.btnEditarUsuario.Text = "Editar";
            this.btnEditarUsuario.UseVisualStyleBackColor = true;
            this.btnEditarUsuario.Click += new System.EventHandler(this.btnEditarUsuario_Click);
            // 
            // btnRetorna
            // 
            this.btnRetorna.Location = new System.Drawing.Point(69, 222);
            this.btnRetorna.Name = "btnRetorna";
            this.btnRetorna.Size = new System.Drawing.Size(75, 23);
            this.btnRetorna.TabIndex = 15;
            this.btnRetorna.Text = "Cancelar";
            this.btnRetorna.UseVisualStyleBackColor = true;
            // 
            // chkBoxStatusEditado
            // 
            this.chkBoxStatusEditado.AutoSize = true;
            this.chkBoxStatusEditado.Location = new System.Drawing.Point(168, 163);
            this.chkBoxStatusEditado.Name = "chkBoxStatusEditado";
            this.chkBoxStatusEditado.Size = new System.Drawing.Size(50, 17);
            this.chkBoxStatusEditado.TabIndex = 14;
            this.chkBoxStatusEditado.Text = "Ativo";
            this.chkBoxStatusEditado.UseVisualStyleBackColor = true;
            // 
            // txtBoxSenhaEditada
            // 
            this.txtBoxSenhaEditada.Location = new System.Drawing.Point(168, 122);
            this.txtBoxSenhaEditada.Name = "txtBoxSenhaEditada";
            this.txtBoxSenhaEditada.Size = new System.Drawing.Size(100, 20);
            this.txtBoxSenhaEditada.TabIndex = 13;
            // 
            // txtBoxNomeEditado
            // 
            this.txtBoxNomeEditado.Location = new System.Drawing.Point(168, 88);
            this.txtBoxNomeEditado.Name = "txtBoxNomeEditado";
            this.txtBoxNomeEditado.Size = new System.Drawing.Size(100, 20);
            this.txtBoxNomeEditado.TabIndex = 12;
            // 
            // lblInputStatus
            // 
            this.lblInputStatus.AutoSize = true;
            this.lblInputStatus.Location = new System.Drawing.Point(66, 163);
            this.lblInputStatus.Name = "lblInputStatus";
            this.lblInputStatus.Size = new System.Drawing.Size(37, 13);
            this.lblInputStatus.TabIndex = 11;
            this.lblInputStatus.Text = "Status";
            // 
            // lblInputSenha
            // 
            this.lblInputSenha.AutoSize = true;
            this.lblInputSenha.Location = new System.Drawing.Point(66, 125);
            this.lblInputSenha.Name = "lblInputSenha";
            this.lblInputSenha.Size = new System.Drawing.Size(38, 13);
            this.lblInputSenha.TabIndex = 10;
            this.lblInputSenha.Text = "Senha";
            // 
            // lblInputNome
            // 
            this.lblInputNome.AutoSize = true;
            this.lblInputNome.Location = new System.Drawing.Point(66, 91);
            this.lblInputNome.Name = "lblInputNome";
            this.lblInputNome.Size = new System.Drawing.Size(35, 13);
            this.lblInputNome.TabIndex = 9;
            this.lblInputNome.Text = "Nome";
            // 
            // FormEditar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 329);
            this.Controls.Add(this.btnEditarUsuario);
            this.Controls.Add(this.btnRetorna);
            this.Controls.Add(this.chkBoxStatusEditado);
            this.Controls.Add(this.txtBoxSenhaEditada);
            this.Controls.Add(this.txtBoxNomeEditado);
            this.Controls.Add(this.lblInputStatus);
            this.Controls.Add(this.lblInputSenha);
            this.Controls.Add(this.lblInputNome);
            this.Name = "FormEditar";
            this.Text = "FormEditar";
            this.Load += new System.EventHandler(this.FormEditar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEditarUsuario;
        private System.Windows.Forms.Button btnRetorna;
        private System.Windows.Forms.CheckBox chkBoxStatusEditado;
        private System.Windows.Forms.TextBox txtBoxSenhaEditada;
        private System.Windows.Forms.TextBox txtBoxNomeEditado;
        private System.Windows.Forms.Label lblInputStatus;
        private System.Windows.Forms.Label lblInputSenha;
        private System.Windows.Forms.Label lblInputNome;
    }
}