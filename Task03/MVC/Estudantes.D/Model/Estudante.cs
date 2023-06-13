// /*
// * 	<copyright file="Estudante.cs" company="bitminho.com">
// * 	Copyright (c) 2023 All Rights Reserved
// * 	</copyright>
// * 	<author>João Pinto</author>
// * 	<date>20230607H21:03</date>
// * 	<description>Estudantes.C/Estudante.cs</description>
// **/

using System;
using System.Collections.Generic;
using Estudantes.D.ToolBox;

namespace Estudantes.D.Model
{
    public class Estudante: IComparable
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Id: {Id}\tNome: {Nome}\tIdade: {Idade}";
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            Estudante objTemp = obj as Estudante;
            if (ReferenceEquals(objTemp, null)) return 1;
            if (ReferenceEquals(this, objTemp)) return 0;
            return Id.CompareTo(objTemp.Id);
        }
    }
    
    public class EstudanteService
    {
        private List<Estudante> lista = new List<Estudante>();
        /// <summary>
        /// constructor: cria a lista de estudantes, enquanto não se utiliza a base de dados 
        /// </summary>
        public EstudanteService()
        {
            // inicialização da lista de dados

            AdicionarEstudante("João", 25);
            AdicionarEstudante("Maria", 35);
            AdicionarEstudante("Alexandre", 23);
            AdicionarEstudante("Olivia", 42);
            AdicionarEstudante("Afonso", 28);
            AdicionarEstudante("Helga", 29);
            AdicionarEstudante("Joana", 32);
            AdicionarEstudante("Victor", 27);
            // ordenar a lista de dados
            //lista.Sort(); // não é necessário porque o contador é sequêncial
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nome"></param>
        /// <param name="idade"></param>
        /// <param name="permitirRepetido"></param>
        /// <returns>id do estudante adicionado na lista, retorna -1 caso contrário</returns>
        public int AdicionarEstudante(string nome, int idade, bool permitirRepetido = false)
        {
            try
            {
                if (!permitirRepetido)
                {
                    Estudante temp = lista.Find(e => String.Compare(e.Nome, nome, StringComparison.Ordinal) == 0);
                    if (!ReferenceEquals(temp, null)) return -1;
                }

                Estudante novo = new Estudante
                {
                    Id = GetNewId.Instancia.Proximo, 
                    Nome = nome, 
                    Idade = idade
                };
                lista.Add(novo);
                return novo.Id;
            }
            catch (Exception e)
            {
                // ignored
            }
            return -1;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="estudante"></param>
        /// <param name="permitirRepetido"></param>
        /// <returns>id do estudante adicionado na lista, retorna -1 caso contrário</returns>
        public int AdicionarEstudante(Estudante estudante, bool permitirRepetido = false)
        {
            if (ReferenceEquals(estudante, null)) return -1;
            try
            {
                if (!permitirRepetido)
                {
                    Estudante temp = lista.Find(e => String.Compare(e.Nome, estudante.Nome, StringComparison.Ordinal) == 0);
                    if (!ReferenceEquals(temp, null)) return -1;
                }

                Estudante novo = new Estudante
                {
                    Id = GetNewId.Instancia.Proximo,
                    Nome = estudante.Nome,
                    Idade = estudante.Idade
                };
                
                lista.Add(novo);
                return novo.Id;
            }
            catch (Exception e)
            {
                // ignored
            }
            return -1;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nome"></param>
        /// <param name="idade"></param>
        /// <returns></returns>
        public bool AtualizaDetalhesEstudante(string nome, int idade)
        {
            int ePos = lista.FindIndex(e => e.Nome == nome);
            if (ePos < 0) return false;
            lista[ePos].Idade = idade;
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Estudante ObterEstudante(int id)
        {
            // Lógica para obter o estudante da base de dados ou de outra fonte de dados
            // Neste exemplo, apenas retornamos um objeto da lista interna de estudantes
            return lista.Find(e => e.Id == id);
            // se o id não existe retorna "null"
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        public Estudante ObterEstudante(string nome)
        {
            // Lógica para obter o estudante da base de dados ou de outra fonte de dados
            // Neste exemplo, apenas retornamos um objeto da lista interna de estudantes
            return lista.Find(e => e.Nome == nome);
            // NOTA: retorna o primeiro encontrado caso hajam nomes repetidos na lista
            // se o id não existe retorna "null"
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<string> ObterEstudantes()
        {
            List<string> resultado = new List<string>();
            foreach (var e in lista)
            {
                resultado.Add(e.ToString());
            }
            return resultado;
        }

    }
    
}