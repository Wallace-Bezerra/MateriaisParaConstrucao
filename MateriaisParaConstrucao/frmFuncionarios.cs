using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MateriaisParaConstrucao
{
    public partial class frmFuncionarios : Form
    {
        public frmFuncionarios()
        {
            InitializeComponent();
        }

        Funcionarios novoFuncionario;

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            //evento do botão Salvar o qual grava as informações através do método Salvar, criado na classe Funcionarios
            try
            {
                novoFuncionario = new Funcionarios();
                novoFuncionario.Salvar(txtNome.Text, txtEndereco.Text, txtBairro.Text, txtCep.Text, txtCidade.Text, txtEmail.Text, 
                                       dtpNascimento.Value.Date, txtTelefone1.Text, txtTelefone2.Text, txtRg.Text, txtCpf.Text, 
                                       txtObservacao.Text, dtpDataCadastro.Value.Date);
                MessageBox.Show("Funcionário salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListarFuncionarios();
                Limpar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ListarFuncionarios()
        {
            Funcionarios novoFuncionario = new Funcionarios();
            dtgFuncionarios.DataSource = novoFuncionario.Listar();
            Estilo();
        }
        
        //método responsável por limpar os componentes do formulário
        private void Limpar()
        {
            txtRegistro.Text = "0";
            txtNome.Clear();
            txtEndereco.Clear();
            txtBairro.Clear();
            txtCep.Clear();
            txtCidade.Clear();
            txtEmail.Clear();
            dtpNascimento.Value = DateTime.Today;
            txtObservacao.Clear();
            txtRg.Clear();
            txtCpf.Clear();
            txtTelefone1.Clear();
            txtTelefone2.Clear();
        }

        //método que realiza o intervalo de cores dentro do DataGriView
        private void Estilo()
        {
            for (int i = 0; i < dtgFuncionarios.Rows.Count; i += 2)
            {
                dtgFuncionarios.Rows[i].DefaultCellStyle.BackColor = Color.Honeydew;
            }
        }

        private void frmFuncionarios_Load(object sender, EventArgs e)
        {
            ListarFuncionarios();
        }
    }
}
