// /*
// * 	<copyright file="EstudanteController.cs" company="bitminho.com">
// * 	Copyright (c) 2023 All Rights Reserved
// * 	</copyright>
// * 	<author>João Pinto</author>
// * 	<date>20230607H21:08</date>
// * 	<description>Estudantes.C/EstudanteController.cs</description>
// **/

using Estudantes.D.Model;
using Estudantes.D.View;

namespace Estudantes.D.Controller
{
    public class EstudanteController
    {
        private EstudanteView _view;
        private EstudanteService _eService;

        public EstudanteController(EstudanteView view, EstudanteService eService)
        {
            _view = view;
            _eService = eService;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nome"></param>
        /// <param name="idade"></param>
        /// <returns></returns>
        public bool AtualizarDetalhesEstudante(string nome, int idade)
        {
            return _eService.AtualizaDetalhesEstudante(nome, idade);
        }
        /// <summary>
        /// 
        /// </summary>
        public void ExibirListaEstudantes()
        {
            _view.ExibirListaEstudantes(_eService.ObterEstudantes());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nome"></param>
        public void ExibirDetalhesEstudante(string nome)
        {
            _view.ExibirDetalhesEstudante(_eService.ObterEstudante(nome));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void ExibirDetalhesEstudante(int id)
        {
            _view.ExibirDetalhesEstudante(_eService.ObterEstudante(id));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int LerDadosEstudante()
        {
            Estudante novo = _view.LerDadosEstudante();
            return _eService.AdicionarEstudante(novo);
        }
    }
    
}