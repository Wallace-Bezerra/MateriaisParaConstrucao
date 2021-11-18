using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MateriaisParaConstrucao
{
    public class Funcionarios
    {
        SqlCommand comandoSql = new SqlCommand();
        StringBuilder sql = new StringBuilder();
        DataTable dadosTabela = new DataTable();

        //método que irá Salvar as informações conforme os parâmetros que possui entre parênteses
        public void Salvar(string nome, string endereco, string bairro, string cep, string cidade, string email, 
                           DateTime nascimento, string telefone1, string telefone2, string rg, string cpf, 
                           string observacoes, DateTime dataCadastro)
        {
            try //estrutura try, a qual tenta realizar o que está dentro das chaves da mesma
            {
                //estabelece a conexão com o banco através da string de conexão
                using (SqlConnection conexao = new SqlConnection(Conexao.stringConexao))
                {
                    conexao.Open(); //abre a conexão com o banco de dados

                    //comando SQL para a inserção de valores nos respectivos campos da tabela Funcionario
                    sql.Append("INSERT INTO Funcionario (NOME_FUNCIONARIO, ENDERECO_FUNCIONARIO, BAIRRO_FUNCIONARIO, ");
                    sql.Append("CEP_FUNCIONARIO, CIDADE_FUNCIONARIO, EMAIL_FUNCIONARIO, NASCIMENTO_FUNCIONARIO, ");
                    sql.Append("TELEFONE1_FUNCIONARIO, TELEFONE2_FUNCIONARIO, RG_FUNCIONARIO, CPF_FUNCIONARIO, ");
                    sql.Append("OBSERVACOES_FUNCIONARIO, DATA_CADASTRO_FUNCIONARIO)");

                    sql.Append(" VALUES (@nome, @endereco, @bairro, @cep, @cidade, @email, @nascimento, @telefone1, ");
                    sql.Append("@telefone2, @rg, @cpf, @observacoes, @dataCadastro)");

                    //relaciona cada valor com seu respectivo parâmetro
                    comandoSql.Parameters.Add(new SqlParameter("@nome", nome));
                    comandoSql.Parameters.Add(new SqlParameter("@endereco", endereco));
                    comandoSql.Parameters.Add(new SqlParameter("@bairro", bairro));
                    comandoSql.Parameters.Add(new SqlParameter("@cep", cep));
                    comandoSql.Parameters.Add(new SqlParameter("@cidade", cidade));
                    comandoSql.Parameters.Add(new SqlParameter("@email", email));
                    comandoSql.Parameters.Add(new SqlParameter("@nascimento", nascimento));
                    comandoSql.Parameters.Add(new SqlParameter("@telefone1", telefone1));
                    comandoSql.Parameters.Add(new SqlParameter("@telefone2", telefone2));
                    comandoSql.Parameters.Add(new SqlParameter("@rg", rg));
                    comandoSql.Parameters.Add(new SqlParameter("@cpf", cpf));
                    comandoSql.Parameters.Add(new SqlParameter("@observacoes", observacoes));
                    comandoSql.Parameters.Add(new SqlParameter("@dataCadastro", dataCadastro));


                    comandoSql.CommandText = sql.ToString(); //indica que o código SQL é o que deverá ser executado
                    comandoSql.Connection = conexao; //indica que a conexão dos comandos SQL é a string de conexão
                    comandoSql.ExecuteNonQuery(); //executa todo o comando para a inserção dos valores
                }
            }
            catch (Exception)
            {
                //caso ocorra um erro no bloco try, entrará no catch, onde irá detectá-lo.
                throw new Exception("Ocorreu um erro no método Salvar. Caso o problema persista, entre em contato com o Administrador do Sistema.");
            }
        }

        public DataTable Listar()
        {
            try
            {
                using(SqlConnection conexao = new SqlConnection(Conexao.stringConexao))
                {
                    conexao.Open();

                    sql.Append("SELECT * FROM Funcionario ");
                    sql.Append("ORDER BY ID_FUNCIONARIO DESC");

                    comandoSql.CommandText = sql.ToString();
                    comandoSql.Connection = conexao;
                    dadosTabela.Load(comandoSql.ExecuteReader());
                    return dadosTabela;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erro!");

                throw;
            }

            
        }
    }
}
