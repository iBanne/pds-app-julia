using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppContatoForm.Properties;
using MySql.Data.MySqlClient;

namespace AppContatoForm
{
    public partial class Listar : Form
    {
        private MySqlConnection conexao;

        private MySqlCommand comando;
        public Listar()
        {
            InitializeComponent();
            Conexao();
            ListarContatos();
        }
        private void Conexao()
        {
            string conexaoString = "server=localhost;database=bd_pds;user=root;password=root;port=3306";
            conexao = new MySqlConnection(conexaoString);
            comando = conexao.CreateCommand();

            conexao.Open();
        }

        private void ListarContatos()
        {
            var sql = "select * from contato_con;";
            var cmd = new MySqlCommand(sql, conexao);
            var da = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            DataTable dados = new DataTable();
            da.Fill(dados);
            dgvListar.DataSource = dados;
            dados.Columns["id_con"].ColumnName = "id";
            dados.Columns["nome_con"].ColumnName = "Nome";
            dados.Columns["telefone_con"].ColumnName = "Telefone";
            dados.Columns["email_con"].ColumnName = "Email";
            dados.Columns["data_con"].ColumnName = "Data";
            dados.Columns["sexo_con"].ColumnName = "Sexo";
        }

        private void btPesquisar_Click(object sender, EventArgs e)
        {

        }

        private void txtpesquisar_TextChanged(object sender, EventArgs e)
        {
            var nome = txtpesquisar.Text;
            var sql = $"select * from contato_con where nome_con like '{nome}%';";
            var cmd = new MySqlCommand(sql, conexao);
            var da = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            DataTable dados = new DataTable();
            da.Fill(dados);
            dgvListar.DataSource = dados;
            dados.Columns["id_con"].ColumnName = "id";
            dados.Columns["nome_con"].ColumnName = "Nome";
            dados.Columns["telefone_con"].ColumnName = "Telefone";
            dados.Columns["email_con"].ColumnName = "Email";
            dados.Columns["data_con"].ColumnName = "Data";
            dados.Columns["sexo_con"].ColumnName = "Sexo";
        }
    }
}
