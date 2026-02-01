using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace cadastroApp
{
    public partial class FormPrincipal : Form
    {
        string stringconexao = "host=localhost;port=5432;username=postgres;password=Pp91196744@;database=sistema";

        public FormPrincipal()
        {
            InitializeComponent();
            Load += FormPrincipal_Load;
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            btnListar.PerformClick();
        }

        private void btnTestarConexao_Click(object sender, EventArgs e)
        {
            try
            {
                using (var conexao = new NpgsqlConnection(stringconexao))
                {
                    conexao.Open();
                    MessageBox.Show("Conexão realizada com sucesso.", "Testar conexão", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao conectar: " + ex.Message, "Testar conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnListar_Click(object sender, EventArgs e)
        {

            txtId.Clear();

            try
            {
                using (var conexao = new NpgsqlConnection(stringconexao))
                {
                    conexao.Open();
                    string sql = "SELECT id, nome, numero FROM cadastro ORDER BY id";

                    using (var cmd = new NpgsqlCommand(sql, conexao))
                    using (var da = new NpgsqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvCadastro.DataSource = dt;
                        dgvCadastro.Refresh();
                    }
                }
            }
            catch (PostgresException ex)
            {
                MessageBox.Show(ex.MessageText, "Erro no banco");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string nome = txtnome.Text.Trim();
            int numero = (int)nudNumero.Value;

            if (string.IsNullOrWhiteSpace(nome))
            {
                MessageBox.Show("O nome não pode ficar vazio.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (numero <= 0)
            {
                MessageBox.Show("O número deve ser maior que zero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conexao = new NpgsqlConnection(stringconexao))
                {
                    conexao.Open();

                    string sql = "INSERT INTO cadastro (nome, numero) VALUES (@nome, @numero)";

                    using (var cmd = new NpgsqlCommand(sql, conexao))
                    {
                        cmd.Parameters.AddWithValue("@nome", nome);
                        cmd.Parameters.AddWithValue("@numero", numero);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Cadastro inserido com sucesso.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                nudNumero.Value = 1;
                txtnome.Clear();

                // Atualiza e exibe a lista de itens cadastrados
                btnListar.PerformClick();
            }
            catch (PostgresException ex)
            {
                if (ex.SqlState == "23505")
                {
                    MessageBox.Show("Este número já está cadastrado. Escolha outro.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Erro no banco: " + ex.MessageText, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dgvCadastro_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvCadastro.Rows[e.RowIndex];
            var idVal = row.Cells["id"].Value;
            var nomeVal = row.Cells["nome"].Value;
            var numeroVal = row.Cells["numero"].Value;

            if (idVal == null || nomeVal == null || numeroVal == null)
                return;

            txtId.Text = idVal.ToString();
            txtnome.Text = nomeVal.ToString();
            nudNumero.Value = Math.Clamp(Convert.ToInt32(numeroVal), nudNumero.Minimum, nudNumero.Maximum);
        }

        private void btnexcluir_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("Selecione um registro para excluir.");
                return;
            }

            var confirmar = MessageBox.Show(
                "Tem certeza que deseja excluir?",
                "Confirmação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirmar == DialogResult.No)
                return;

            if (!int.TryParse(txtId.Text, out int id))
            {
                MessageBox.Show("ID inválido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conexao = new NpgsqlConnection(stringconexao))
                {
                    conexao.Open();

                    string sql = "DELETE FROM cadastro WHERE id = @id";

                    using (var cmd = new NpgsqlCommand(sql, conexao))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Registro excluído com sucesso.");

                btnListar.PerformClick(); 
                txtId.Clear();
                txtnome.Clear();
                nudNumero.Value = 1;
            }
            catch (PostgresException ex)
            {
                MessageBox.Show(ex.MessageText, "Erro do banco");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado: " + ex.Message);
            }
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {
            txtId.Visible = false;
        }
    }

}


