﻿using Agenda_de_Tarefas;
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
            ControlUsuario usuario= new ControlUsuario(); //Conectando a control na model
            usuario.Operacao();
            usuario.OperacaoEscolha();
            Console.ReadLine();//Manter prompt aberto 

        }//fim do metodo
    }//fim da classe
}//fim do projeto
