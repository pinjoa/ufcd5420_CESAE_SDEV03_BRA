// /*
// * 	<copyright file="EstudanteView.cs" company="bitminho.com">
// * 	Copyright (c) 2023 All Rights Reserved
// * 	</copyright>
// * 	<author>João Pinto</author>
// * 	<date>20230607H21:07</date>
// * 	<description>Estudantes.C/EstudanteView.cs</description>
// **/

using System.Collections.Generic;
using Estudantes.D.Model;
using Estudantes.D.ToolBox;

namespace Estudantes.D.View
{
    public class EstudanteView
    {
        private IEscrever iEscrever;
        private ILer iLer;
        private EstudanteService eService;
        private LerTipoDados lerTipoDados;
        
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
            lerTipoDados = new LerTipoDados(iLer, iEscrever);
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
            return new Estudante
            {
                Nome = lerTipoDados.LerTexto("Introduzir o nome do estudante:"), 
                Idade = lerTipoDados.LerInteiro("Introduzir a idade do estudante:", false, 1)
            };
        }
        
    }
    
}