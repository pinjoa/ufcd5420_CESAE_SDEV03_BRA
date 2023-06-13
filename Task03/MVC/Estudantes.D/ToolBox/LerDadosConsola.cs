// /*
// * 	<copyright file="LerDados.cs" company="bitminho.com">
// * 	Copyright (c) 2023 All Rights Reserved
// * 	</copyright>
// * 	<author>João Pinto</author>
// * 	<date>20230607H21:06</date>
// * 	<description>Estudantes.C/LerDados.cs</description>
// **/

using System;

namespace Estudantes.D.ToolBox
{
    public class LerDadosConsola: ILer
    {
        public string LerTexto()
        {
            return Console.ReadLine();
        }
    }
    
}