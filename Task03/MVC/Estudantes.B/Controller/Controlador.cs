// /*
// * 	<copyright file="Controlador.cs" company="bitminho.com">
// * 	Copyright (c) 2023 All Rights Reserved
// * 	</copyright>
// * 	<author>João Pinto</author>
// * 	<date>20230607H00:49</date>
// * 	<description>Estudantes.B/Controlador.cs</description>
// **/

using Estudantes.B.Model;
using Estudantes.B.View;

namespace Estudantes.B.Controller
{
    public class EstudanteController
    {
        private EstudanteServico _servico;
        private EstudanteView _view;

        public EstudanteController(EstudanteServico servico, EstudanteView view)
        {
            _servico = servico;
            _view = view;
        }

        public void ExibirDetalhesEstudante(int id)
        {
            Estudante estudante = _servico.ObterEstudante(id);
            _view.MostrarDetalhesEstudante(estudante.Nome, estudante.Idade);
        }
    }

    
}