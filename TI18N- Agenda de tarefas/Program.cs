using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TI18N__Agenda_de_tarefas
{
     class Program
    {
        static void Main(string[] args)
        {
            ControlUsuario pessoa= new ControlUsuario(); //Conectando a control na model
            pessoa.Operacao();
            pessoa.OperacaoLogin();
            Console.ReadLine();//Manter prompt aberto 

        }//fim do metodo
    }//fim da classe
}//fim do projeto
