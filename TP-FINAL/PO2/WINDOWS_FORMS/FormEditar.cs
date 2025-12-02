using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WINDOWS_FORMS.Repositories;

//Desenvolvido por Laysa Bernardes e Lucas Lopes

namespace WINDOWS_FORMS
{
    public partial class FormEditar : Form
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly int _usuarioId;
        public FormEditar(IUsuarioRepository usuarioRepository, int usuarioId)
        {
            InitializeComponent();
            _usuarioRepository = usuarioRepository;
            _usuarioId = usuarioId;
            this.Text = $"Editar Usuário ID: {_usuarioId}";
        }

        private async Task CarregarDadosUsuario()
        {
            try
            {
                Usuario usuario = await _usuarioRepository.GetByIdAsync(_usuarioId);

                if (usuario != null)
                {
                    txtBoxNomeEditado.Text = usuario.Nome;
                    txtBoxSenhaEditada.Text = usuario.Senha;
                    chkBoxStatusEditado.Checked = usuario.Status;
                }
                else
                {
                    MessageBox.Show("Usuário não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Erro de conexão ao buscar usuário: {ex.Message}", "Erro de API", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar dados do usuário: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private async void FormEditar_Load(object sender, EventArgs e)
        {
            await CarregarDadosUsuario();
        }

        private async void btnEditarUsuario_Click(object sender, EventArgs e)
        {
            string nome = txtBoxNomeEditado.Text;
            string senha = txtBoxSenhaEditada.Text;

            if(nome == "" || senha == "")
            {
                MessageBox.Show("Nome e Senha não podem ser vazios.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Usuario usuarioEditado = new Usuario
            {
                Id = _usuarioId,
                Nome = txtBoxNomeEditado.Text,
                Senha = txtBoxSenhaEditada.Text,
                Status = chkBoxStatusEditado.Checked
            };

            try
            {
                await _usuarioRepository.UpdateAsync(usuarioEditado);
                MessageBox.Show("Usuário atualizado com sucesso!");

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
