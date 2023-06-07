// /*
// * 	<copyright file="EstudanteView.cs" company="bitminho.com">
// * 	Copyright (c) 2023 All Rights Reserved
// * 	</copyright>
// * 	<author>João Pinto</author>
// * 	<date>20230607H21:07</date>
// * 	<description>Estudantes.C/EstudanteView.cs</description>
// **/

using System.Collections.Generic;
using Estudantes.C.Model;
using Estudantes.C.ToolBox;

namespace Estudantes.C.View
{
    public class EstudanteView
    {
        private IEscrever iEscrever;
        private ILer iLer;
        private EstudanteService eService;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iLer"></param>
        /// <param name="iEscrever"></param>
        /// <param name="eService"></param>
        public EstudanteView(ILer iLer, IEscrever iEscrever, EstudanteService eService)
        {
            this.iLer = iLer;
            this.iEscrever = iEscrever;
            this.eService = eService;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="estudante"></param>
        /// <param name="mostraErro"></param>
        public void ExibirDetalhesEstudante(Estudante estudante, bool mostraErro = true)
        {
            if (ReferenceEquals(estudante, null))
            {
                if (mostraErro)
                {
                    iEscrever.EscreveTexto("ERRO: Objeto inválido!");
                }
            }
            else
            {
                iEscrever.EscreveTexto($"Detalhe do estudante:\n{estudante.ToString()}");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nome"></param>
        /// <param name="mostraErro"></param>
        public void ExibirDetalhesEstudante(string nome, bool mostraErro = true)
        {
            ExibirDetalhesEstudante(eService.ObterEstudante(nome), mostraErro);
        }
        /// <summary>
        /// 
        /// </summary>
        public void ExibirListaEstudantes(List<string> lista)
        {
            iEscrever.EscreveTexto("Lista de estudantes:");
            if (lista.Count>0)
            {
                foreach (var txt in lista)
                {
                    iEscrever.EscreveTexto(txt);
                }
            }
            else
            {
                iEscrever.EscreveTexto("<lista vazia>");
            }
        }

        public Estudante LerDadosEstudante()
        {
            // loop para ler o nome do estudante
            iEscrever.EscreveTexto("Introduzir o nome do estudante:");
            string nome = "";
            while (nome.Length<1)
            {
                nome = iLer.LerTexto().Trim();
                if (nome.Length < 1)
                {
                    iEscrever.EscreveTexto("p.f. introduzir um nome válido!");
                }
            }
            // loop para ler a idade do estudante
            iEscrever.EscreveTexto("Introduzir a idade do estudante:");
            int idade = 0;
            while (idade<1)
            {
                string textIdade = iLer.LerTexto().Trim();
                if (!int.TryParse(textIdade, out idade))
                {
                    iEscrever.EscreveTexto("p.f. introduzir uma idade válida!");
                }
            }

            return new Estudante { Nome = nome, Idade = idade };
        }
        
    }
    
}