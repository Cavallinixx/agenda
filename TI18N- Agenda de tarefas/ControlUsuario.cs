using Org.BouncyCastle.Cms;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using TI18N__Agenda_de_tarefas;

namespace Agenda_de_Tarefas
{
    class ControlUsuario
    {
        private int opcao;
        DAO conectar;
        public int codigo;
        string usuarioCadastro;
        string admUsuario;
        string admSenha;
        string senhaCadastro;
        string endereco;
        string usuario;
        string senha;


        public ControlUsuario()
        {
            //Instanciando a variavel
            ConsultarOpcao = 0;
            conectar = new DAO();//Conectando ao banco
            usuario = usuarioCadastro;
            senha = senhaCadastro;
            admUsuario = "vitao";
            admSenha = "123";
            usuario = "vitor";
            senha = "321";



        }//fim do construtor  
        public int ConsultarOpcao
        {
            get { return this.opcao; }
            set { this.opcao = value; }

        }// fim do get set

        public void Menu()
        {
            Console.WriteLine("Escolha Uma das opções abaixo:\n" +
                               "1.Entrar: \n" +
                               "2.Cadastrar: \n" +
                               "3.Sair : \n");
            ConsultarOpcao = Convert.ToInt32(Console.ReadLine());

        }//fim do menu

        public void Operacao()
        {
            do
            {
                Menu();//Mostrar as opções para o usuário
                Console.Clear();
                switch (ConsultarOpcao)
                {
                    case 1:
                        EntrarUsuario();
                        do
                        {
                            if (usuario == admUsuario && senha == admSenha)
                            {
                                Console.WriteLine("Bem-vindo, administrador!");
                            }
                            if (usuario == usuario && senha == senha)
                            {
                                Console.WriteLine("Bem vindo, escolha uma das opções: ");

                            }
                            else
                            {
                                Console.WriteLine("ERRO! o usuário ou a senha estão incorretos!! ");
                            }
                        } while ((usuario == usuario) || (senha == senha));
                        break;
                    case 2:
                        CadastrarUsuario();
                        break;
                    case 3:
                        Console.WriteLine("Obrigado!");

                        Console.ReadLine();
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Informe o código de acordo com o menu");
                        break;
                }//fim do escolha 

            } while (ConsultarOpcao != 1);
        }//fim da método

        public void MenuEscolha()
        {
            Console.WriteLine("Escolha uma das opções abaixo: \n" +
                              "1. Cadastrar\n" +
                              "2. Consultar\n" +
                              "3. Consultar Individual\n" +
                              "4. Atualizar\n" +
                              "5. Excluir\n" +
                              "6. Sair");
            ConsultarOpcao = Convert.ToInt32(Console.ReadLine());
        }//fim do menu            

        public void OperacaoEscolha()
        {
            do
            {
                MenuEscolha();
                Console.Clear();
                switch (ConsultarOpcao)
                {
                    case 1:
                        CadastrarTarefa();
                        break;
                    case 2:
                        Consultar();
                        break;
                    case 3:
                        ConsultarIndividual();
                        break;
                    case 4:
                        MenuAtualizar();
                        break;
                    case 5:
                        Deletar();
                        break;
                    case 6:
                        Console.WriteLine("Obrigado!!");

                        Console.ReadLine();

                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Informe um código de acordo com o menu");
                        break;
                }//fim do escolha caso
            } while (ConsultarOpcao != 4);

        }//fim do método

        public void EntrarUsuario()
        {
            Console.WriteLine("Insira seu usuário: ");
            usuario = Console.ReadLine();
            Console.WriteLine("Insira sua senha: ");
            senha = Console.ReadLine();


        }//fim do metodo login

        public void CadastrarUsuario()
        {
            Console.WriteLine("Informe seu nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Informe seu telefone: ");
            string telefone = Console.ReadLine();
            Console.WriteLine("Informe sua cidade: ");
            string cidade = Console.ReadLine();
            Console.WriteLine(" Informe um nome de usuário: ");
            string usuarioCadastro = Console.ReadLine();
            Console.WriteLine("Informe uma senha: ");
            string senhaCadastro = Console.ReadLine();
            Console.WriteLine("Cadastro Realizado!!");
            conectar.Inserir(nome, telefone, cidade, endereco: endereco, usuarioCadastro, senhaCadastro); // Inserindo ao banco de dados


        }//fim do método Cadastrar Usuario

        public void CadastrarTarefa()
        {
            Console.WriteLine(" Escreva o titulo da tarefa: ");
            string titulo = Console.ReadLine();
            Console.WriteLine(" Escreve a descrição da tarefa: ");
            string descricao = Console.ReadLine();
            Console.WriteLine(" Escreva a data de hoje: ");
            string diaMesAno = Console.ReadLine();
            Console.WriteLine(" Escreva o horario de agora: ");
            string hora = Console.ReadLine();
        }//fim do metodo Cadastrar Tarefa

        public void Consultar()
        {
            Console.WriteLine(conectar.ConsultarTudo());
        }//fim do consultar

        public void ConsultarIndividual()
        {
            Console.WriteLine("Informe o código que deseja consultar: ");
            int codigo = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(" A tarefa do código consultado foi: ");
            Console.WriteLine(conectar.Consultar(codigo));//Mostrando na tela            
        }//fim do consultar
        public void MostrarMenuAtualizar()
        {
            Console.WriteLine("\n\nEscolha uma das opções abaixo: " +
                "\n1. Nome " +
                "\n2. Telefone " +
                "\n3. Cidade " +
                "\n4. Endereço ");
            opcao = Convert.ToInt32(Console.ReadLine());
        }//fim do método


        public void MenuAtualizar()
        {
            MostrarMenuAtualizar();
            switch (opcao)
            {
                case 1:
                    Console.WriteLine("Informe o código do dado que deseja atualizar: ");
                    codigo = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Informe o novo nome: ");
                    string nome = Console.ReadLine();
                    //Método que deseja atualizar
                    Console.WriteLine("\n\n" + conectar.Atualizar(codigo, "nome", nome));
                    break;
                case 2:
                    Console.WriteLine("Informe o código do dado que deseja atualizar: ");
                    codigo = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Informe o novo telefone: ");
                    string telefone = Console.ReadLine();
                    //Método que deseja atualizar
                    Console.WriteLine("\n\n" + conectar.Atualizar(codigo, "telefone", telefone));
                    break;
                case 3:
                    Console.WriteLine("Informe o código do dado que deseja atualizar: ");
                    codigo = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Informe a nova cidade: ");
                    string cidade = Console.ReadLine();
                    //Método que deseja atualizar
                    Console.WriteLine("\n\n" + conectar.Atualizar(codigo, "cidade", cidade));
                    break;
                case 4:
                    Console.WriteLine("Informe o código do dado que deseja atualizar: ");
                    codigo = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Informe o novo endereço: ");
                    string endereco = Console.ReadLine();
                    //Método que deseja atualizar
                    Console.WriteLine("\n\n" + conectar.Atualizar(codigo, "endereco", endereco));
                    break;
                default:
                    Console.WriteLine("Opção escolhida não é válida!");
                    break;



            }//fim do escolha
        }//fim do método



        public void Deletar()
        {
            Console.WriteLine("Informe um código: ");
            codigo = Convert.ToInt32(Console.ReadLine());
            //Utilizar o método excluir
            Console.WriteLine("\n\n" + conectar.Excluir(codigo));
        }//fim do método

    }//fim da classe 
}//fim do projeto 