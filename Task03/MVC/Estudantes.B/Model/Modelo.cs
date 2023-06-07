// /*
// * 	<copyright file="Model.cs" company="bitminho.com">
// * 	Copyright (c) 2023 All Rights Reserved
// * 	</copyright>
// * 	<author>João Pinto</author>
// * 	<date>20230607H00:47</date>
// * 	<description>Estudantes.B/Modelo.cs</description>
// **/

namespace Estudantes.B.Model
{
    public class Estudante
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
    }

    public class EstudanteServico
    {
        public Estudante ObterEstudante(int id)
        {
            // Lógica para obter o estudante da base de dados ou de outra fonte de dados
            // Neste exemplo, apenas retornamos um objeto de estudante fixo
            return new Estudante { Nome = "João", Idade = 25 };
        }
    }
    
}