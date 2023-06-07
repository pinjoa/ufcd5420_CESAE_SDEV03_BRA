// /*
// * 	<copyright file="GetNewId.cs" company="bitminho.com">
// * 	Copyright (c) 2023 All Rights Reserved
// * 	</copyright>
// * 	<author>João Pinto</author>
// * 	<date>20230607H21:02</date>
// * 	<description>Estudantes.C/GetNewId.cs</description>
// **/

namespace Estudantes.C.ToolBox
{
    /// <summary>
    /// implementa singleton
    /// </summary>
    public class GetNewId
    {
        private static GetNewId instancia;
        private static int contador = 0;

        private GetNewId() { }

        public int Proximo => ++contador;
    
        public static GetNewId Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new GetNewId();
                }
                return instancia;
            }
        }

    }
    
}