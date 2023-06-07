// /*
// * 	<copyright file="Visualizador.cs" company="bitminho.com">
// * 	Copyright (c) 2023 All Rights Reserved
// * 	</copyright>
// * 	<author>João Pinto</author>
// * 	<date>20230607H00:50</date>
// * 	<description>Estudantes.B/Visualizador.cs</description>
// **/

using System;

namespace Estudantes.B.View
{
    public class EstudanteView
    {
        public void MostrarDetalhesEstudante(string nome, int idade)
        {
            Console.WriteLine("Detalhes do Estudante:");
            Console.WriteLine("Nome: " + nome);
            Console.WriteLine("Idade: " + idade);
        }
    }

    
}