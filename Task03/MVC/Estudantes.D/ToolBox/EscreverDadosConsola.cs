// /*
// * 	<copyright file="EscreverDados.cs" company="bitminho.com">
// * 	Copyright (c) 2023 All Rights Reserved
// * 	</copyright>
// * 	<author>João Pinto</author>
// * 	<date>20230607H21:06</date>
// * 	<description>Estudantes.C/EscreverDados.cs</description>
// **/

using System;

namespace Estudantes.D.ToolBox
{
    public class EscreverDadosConsola : IEscrever
    {
        public void EscreveTexto(string texto)
        {
            Console.WriteLine(texto);
        }
    }
    
}