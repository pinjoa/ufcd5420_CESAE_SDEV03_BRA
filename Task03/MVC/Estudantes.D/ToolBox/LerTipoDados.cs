// /*
// * 	<copyright file="LerTipoDados.cs" company="bitminho.com">
// * 	Copyright (c) 2023 All Rights Reserved
// * 	</copyright>
// * 	<author>João Pinto</author>
// * 	<date>20230613H17:51</date>
// * 	<description>Estudantes.D/LerTipoDados.cs</description>
// **/

namespace Estudantes.D.ToolBox
{
    public class LerTipoDados
    {
        private IEscrever iEscrever;
        private ILer iLer;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iLer"></param>
        /// <param name="iEscrever"></param>
        public LerTipoDados(ILer iLer, IEscrever iEscrever)
        {
            this.iLer = iLer;
            this.iEscrever = iEscrever;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="permitirVazio"></param>
        /// <returns></returns>
        public string LerTexto(string msg, bool permitirVazio = false)
        {
            iEscrever.EscreveTexto(msg);
            string valor = iLer.LerTexto().Trim();
            if (!permitirVazio)
            {
                while (valor.Length < 1)
                {
                    valor = iLer.LerTexto().Trim();
                    if (valor.Length < 1)
                    {
                        iEscrever.EscreveTexto($"[repetir] {msg}");
                    }
                }
            }

            return valor;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="permitirQualquerValor"></param>
        /// <param name="minValor"></param>
        /// <param name="maxValor"></param>
        /// <returns></returns>
        public int LerInteiro(string msg, bool permitirQualquerValor = false, int minValor = 0, int? maxValor = null)
        {
            int valor = 0;
            iEscrever.EscreveTexto(msg);
            string txtValor = iLer.LerTexto().Trim();
            if (int.TryParse(txtValor, out valor) && permitirQualquerValor) return valor;

            while (valor < minValor)
            {
                iEscrever.EscreveTexto($"[repetir] {msg}");
                txtValor = iLer.LerTexto().Trim();
                if (int.TryParse(txtValor, out valor))
                {
                    if (maxValor != null && maxValor >= minValor && valor > maxValor)
                    {
                        valor = minValor - 1;
                    }
                }
            }

            return valor;
        }
    }
}