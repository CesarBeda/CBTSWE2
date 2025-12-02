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

//Cesar Beda CB302704X

namespace WINDOWS_FORMS
{
    public partial class FormUsuarios : Form
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public FormUsuarios(IUsuarioRepository usuarioRepository)
        {
            InitializeComponent();
            _usuarioRepository = usuarioRepository;
        }
        private async Task CarregarUsuarios()
        {
            try
            {
                List<Usuario> usuarios = await _usuarioRepository.GetAllAsync();

                dataGridViewUsuarios.DataSource = usuarios;

                dataGridViewUsuarios.Columns["Status"].HeaderText = "Status (Ativo)";
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show("Erro ao conectar com a API (verifique se a API está iniciada e a porta correta em Program.cs).\nDetalhes: " + ex.Message,
                                "Erro de Conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao carregar os usuários: " + ex.Message,
                                "Erro Geral", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AdicionarBotoesAcao()
        {
            DataGridViewButtonColumn btnAtualizar = new DataGridViewButtonColumn();
            btnAtualizar.Name = "BtnAtualizar";
            btnAtualizar.HeaderText = "Atualizar";
            btnAtualizar.Text = "Editar"; 
            btnAtualizar.UseColumnTextForButtonValue = true; 

            DataGridViewButtonColumn btnExcluir = new DataGridViewButtonColumn();
            btnExcluir.Name = "BtnExcluir";
            btnExcluir.HeaderText = "Excluir";
            btnExcluir.Text = "Excluir";
            btnExcluir.UseColumnTextForButtonValue = true;

            if (dataGridViewUsuarios.Columns.Contains("BtnAtualizar") == false)
                dataGridViewUsuarios.Columns.Add(btnAtualizar);
            
            if (dataGridViewUsuarios.Columns.Contains("BtnExcluir") == false)
                dataGridViewUsuarios.Columns.Add(btnExcluir);

            if (dataGridViewUsuarios.Columns.Contains("Id"))
                dataGridViewUsuarios.Columns["Id"].Visible = false;
        }

        private async Task ExcluirUsuarioAsync(int usuarioId)
        {
            DialogResult confirm = MessageBox.Show(
                $"Tem certeza que deseja excluir permanentemente o usuário com ID: {usuarioId}?",
                "Confirmação de Exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    await _usuarioRepository.DeleteAsync(usuarioId);

                    MessageBox.Show("Usuário excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    await CarregarUsuarios();
                }
                catch (HttpRequestException ex)
                {
                    MessageBox.Show($"Erro de conexão ao excluir. Verifique a API. Detalhes: {ex.Message}",
                                    "Erro de API", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocorreu um erro ao excluir o usuário: {ex.Message}",
                                    "Erro Geral", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private async void FormUsuarios_Load(object sender, EventArgs e)
        {
            await CarregarUsuarios();
            AdicionarBotoesAcao();
        }

        private async void btnCadastrarUsuario_Click(object sender, EventArgs e)
        {
            FormCadastro formCadastro = new FormCadastro(_usuarioRepository);
            DialogResult resultado = formCadastro.ShowDialog();

            if (resultado == DialogResult.OK)
                await CarregarUsuarios();
        }

        private async void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var senderGrid = (DataGridView)sender;

            int usuarioId = (int)senderGrid.Rows[e.RowIndex].Cells["Id"].Value;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && senderGrid.Columns[e.ColumnIndex].Name == "BtnAtualizar")
            {

                FormEditar formEditar = new FormEditar(_usuarioRepository, usuarioId);

                if (formEditar.ShowDialog() == DialogResult.OK)
                
                    await CarregarUsuarios();
                
            }
            else if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && senderGrid.Columns[e.ColumnIndex].Name == "BtnExcluir")
                await ExcluirUsuarioAsync(usuarioId);   
        }
    }
}