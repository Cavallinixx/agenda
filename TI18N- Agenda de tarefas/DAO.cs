using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
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
        public string[] titulo;
        public string[] descricao;
        public string[] diaMesAno;
        public string[] hora;

        public int i;
        public string resultado;
        public int contador;
        public string msg;
        public string usuario;
        public string senha;
        public double usuarioDigitado;
        public double senhaDigitada;


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








        public void InserirSegundoMenu(string titulo, string descricao, string diaMesAno, string hora)
        {
            try
            {
                dados = "('','" + titulo + "','" + descricao + "','" + diaMesAno + "','" + hora + "')";
                sql = " insert into CadastroLoginMenuEscolha(codigo,titulo,descricao,diaMesAno,hora)  values" + dados;

                MySqlCommand conn = new MySqlCommand(sql, conexao); // preparando a coneão no banco
                resultado = "" + conn.ExecuteNonQuery();//Ctrl + Enter -> Executando o comando no BD
                Console.WriteLine(resultado + "Linha afetada!");
            }
            catch (Exception erro)
            {
                Console.WriteLine("Erro!! Algo deu errado! \n\n\n " + erro);
            }
        }//fim do metodo inserir 
        public void PreencherVetorAgenda()
        {

            string query = " Select * from pessoa ";

            //Instanciando os vetores
            codigo = new int[100];
            titulo = new string[100];
            descricao = new string[100];
            diaMesAno = new string[100];
            hora = new string[10];


            //Preencher com vetores genéricos
            for (i = 0; i < 100; i++)
            {
                codigo[i] = 0;
                titulo[i] = "";
                descricao[i] = "";
                diaMesAno[i] = "";
                hora[i] = "";

            }//fim do for

            MySqlCommand coletar = new MySqlCommand(query, conexao);
            //leitura do banco
            MySqlDataReader leitura = coletar.ExecuteReader();

            i = 0;
            contador = 0;

            while (leitura.Read())
            {
                codigo[i] = Convert.ToInt32(leitura["codigo"]);
                titulo[i] = "" + leitura["titulo"];
                descricao[i] = "" + leitura["descricao"];
                diaMesAno[i] = "" + leitura["diaMesAno"];
                hora[i] = "" + leitura["hora"];
                i++;
                contador++;
            }//Preenchendo com o vetor com os dados do banco

            leitura.Close();//Encerrar o acesso ao Banco de Dados
        }//fim do preencher


        
        public string ConsultarTudo()
        {
            //Preencher o vetor
            PreencherVetorAgenda();
            msg = "";
            for (i = 0; i < contador; i++)
            {
                msg = "\n\nCódigo: " + codigo[i] +
                    ", Titulo: " + titulo[i] +
                    ", Descrição: " + descricao[i] +
                    ", DiaMesAno: " + diaMesAno[i] +
                    ", Hora:" + hora[i];
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

        public Boolean ValidarCadastro(string usuarioDigitado, string senhaDigitada, string usuario, string senha)
        {
            if ((usuarioDigitado == usuario) || (senhaDigitada == senha))
            {
                
                return true;
                
            }
            
            return false;
               
           
        }//fim método


        public string Consultar(int cod)
        {
            for (i = 0; i < contador; i++)
            {

                if (codigo[i] == cod)
                {
                    msg = "\n\nCódigo: " + codigo[i] +
                           ", titulo: " + titulo[i] +
                           ", descricao: " + descricao[i] +
                           ", diaMesAno: " + diaMesAno[i] +
                           ", hora: " + hora[i];


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
