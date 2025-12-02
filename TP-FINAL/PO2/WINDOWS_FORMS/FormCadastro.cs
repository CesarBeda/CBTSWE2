using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WINDOWS_FORMS.Repositories;

//Desenvolvido por Laysa Bernardes e Lucas Lopes

namespace WINDOWS_FORMS
{
    public partial class FormCadastro : Form
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public FormCadastro(IUsuarioRepository usuarioRepository)
        {
            InitializeComponent();
            _usuarioRepository = usuarioRepository;
        }

        private void FormCadastro_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnRetorna_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnCadastrarUsuario_Click(object sender, EventArgs e)
        {
            string nome = txtBoxNome.Text;
            string senha = txtBoxSenha.Text;
            bool status = chkBoxStatus.Checked;

            if(nome == "" || senha == "")
            {
                MessageBox.Show("Nome e Senha são obrigatórios!");
                return;
            }

            Usuario usuario = new Usuario
            {
                Nome = nome,
                Senha = senha,
                Status = status
            };

            try
            {
                await _usuarioRepository.AddAsync(usuario);
                MessageBox.Show("Usuário cadastrado com sucesso!");
                
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao cadastrar usuário: {ex.Message}");
            }   
        }
    }
}
