using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Agenda_de_Tarefas
{
    class DAO
    {
        public MySqlConnection conexao; //Conectando ao banco 
        public string dados;
        public string sql;
        public int[] codigo;
        public string[] nome;
        public string[] telefone;
        public string[] cidade;
        public string[] endereco;
        public int i;
        public string resultado;
        public int contador;
        public string msg;
        public string usuario;
        public string senha;
        public string titulo;
        public string descricao;
        public string diaMesAno;
        public string hora;
        public string usuarioCadastro;
        public string senhaCadastro;


        public DAO()
        {
            conexao = new MySqlConnection("server=localhost;DataBase=Agendati18n;Uid=root;Password=");
            try
            {
                conexao.Open();//Abrindo a conexão com BD
                Console.WriteLine("Conectado com sucesso!");
            }
            catch (Exception erro)
            {
                Console.WriteLine("Algo deu errado!! Verifique os dados de conexão! \n\n " + erro);
                conexao.Close();//fechar a conexão com BD
            }//fim do try catch


        }//fim do método

        public void Inserir(string nome, string telefone, string cidade, string endereco, string usuarioCadastro, string senhaCadastro)
        {
            try
            {
                dados = "('','" + nome + "','" + telefone + "','" + cidade + "','" + endereco + "' ,'" + usuarioCadastro + "','" + senhaCadastro + "')";
                sql = " insert into CadastroLoginMenu(codigo,nome,telefone,cidade,endereco,usuario,senha)  values" + dados;

                MySqlCommand conn = new MySqlCommand(sql, conexao); // preparando a coneão no banco
                resultado = "" + conn.ExecuteNonQuery();//Ctrl + Enter -> Executando o comando no BD
                Console.WriteLine(resultado + "Linha afetada!");
            }
            catch (Exception erro)
            {
                Console.WriteLine("Erro!! Algo deu errado! \n\n\n " + erro);
            }
        }//fim do metodo inserir 





        public void PreencherVetor()
        {

            string query = " Select * from pessoa ";

            //Instanciando os vetores
            codigo = new int[100];
            nome = new string[100];
            telefone = new string[13];
            cidade = new string[100];
            endereco = new string[100];


            //Preencher com vetores genéricos
            for (i = 0; i < 100; i++)
            {
                codigo[i] = 0;
                nome[i] = "";
                telefone[i] = "";
                cidade[i] = "";
                endereco[i] = "";

            }//fim do for
            MySqlCommand coletar = new MySqlCommand(query, conexao);
            //leitura do banco
            MySqlDataReader leitura = coletar.ExecuteReader();

            i = 0;
            contador = 0;

            while (leitura.Read())
            {
                codigo[i] = Convert.ToInt32(leitura["codigo"]);
                nome[i] = "" + leitura["nome"];
                telefone[i] = "" + leitura["telefone"];
                cidade[i] = "" + leitura["cidade"];
                endereco[i] = "" + leitura["endereço"];
                i++;
                contador++;
            }//Preenchendo com o vetor com os dados do banco

            leitura.Close();//Encerrar o acesso ao Banco de Dados
        }//fim do preencher

        static bool ValidarCadastro(string usuario, string senha)
        {
            if ((usuario == usuario) || (senha == senha))
            {
                return true;
            }
            else
            {
                return false;
            }
        }//fim método
        public string ConsultarTudo()
        {
            //Preencher o vetor
            PreencherVetor();
            msg = "";
            for (i = 0; i < contador; i++)
            {
                msg = "\n\nCódigo: " + codigo[i] +
                    ", Nome: " + nome[i] +
                    ", Telefone: " + telefone[i] +
                    ", Cidade: " + cidade[i] +
                    ", Endereço:" + endereco[i];
            }// fim do for

            return msg;//Mostrar na tela o resultado da consulta
        }//fim do metodo 

        public string Atualizar(int cod, string campo, string dado)
        {
            try
            {
                string query = "update pessoa set " + campo + " = '" + dado + "' where codigo = '" + cod + "'";
                //Preparar o comando do BD
                MySqlCommand sql = new MySqlCommand(query, conexao);
                string resultado = "" + sql.ExecuteNonQuery();
                return resultado + " linha afetada!";
            }
            catch (Exception erro)
            {
                return "Algo deu errado!\n\n" + erro;
            }
        }//fim do método


        public string Consultar(int cod)
        {
            for (i = 0; i < contador; i++)
            {

                if (codigo[i] == cod)
                {
                    msg = "\n\nCódigo: " + codigo[i] +
                           ", Nome: " + nome[i] +
                           ", Telefone: " + telefone[i] +
                           ", Cidade: " + cidade[i] +
                           ", Endereço: " + endereco;


                    return msg;
                }//fim do if
            }//fim do for
            return " Codigo informado não encontrado!!";
        }//fim metodo

        public string Excluir(int cod)
        {
            string query = "delete from pessoa where codigo = '" + cod + "'";
            //Preparar o comando
            MySqlCommand sql = new MySqlCommand(query, conexao);
            string resultado = "" + sql.ExecuteNonQuery();
            //Mostrar o resultado
            return resultado + " Linha Afetada";
        }//fim do método

    }//fim do método


}//fim do projeto
