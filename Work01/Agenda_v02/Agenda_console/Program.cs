using Agenda_BO;
using Agenda_BL;

internal class Program
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="args"></param>
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Compromisso_BR gestaoCompromissos = new Compromisso_BR();
        Compromisso novo1 = gestaoCompromissos.NovoCompromisso(15, 2, "João", "Atividade");

        if (!gestaoCompromissos.ImportarDados())
        {
            Console.WriteLine("Os dados não foram carregados.");
            Console.WriteLine("Adicionar os dois objetos");
            gestaoCompromissos.AdicionarCompromisso(novo1);
            gestaoCompromissos.AdicionarCompromisso(gestaoCompromissos.NovoCompromisso(16, 1, "Orlando", "Trabalho de grupo"));
            gestaoCompromissos.AdicionarCompromisso(gestaoCompromissos.NovoCompromisso(17, 3, "Joaquim", "Mini+Amendoins"));
            gestaoCompromissos.AdicionarCompromisso(gestaoCompromissos.NovoCompromisso(17, 4, "Alberto", "Mini+Amendoins"));
            gestaoCompromissos.AdicionarCompromisso(gestaoCompromissos.NovoCompromisso(18, 0, "Alexandra", "Mini+Amendoins"));
            gestaoCompromissos.AdicionarCompromisso(gestaoCompromissos.NovoCompromisso(18, 2, "Matilde", "Mini+Amendoins"));
            gestaoCompromissos.AdicionarCompromisso(gestaoCompromissos.NovoCompromisso(18, 3, "Vieira", "Mini+Amendoins"));
        } 
        else
        {
            Console.WriteLine("Dados carregados!");
        }

        Console.WriteLine("Listar os objetos");
        MostrarLista(gestaoCompromissos.GetCompromissoList());

        Console.WriteLine("Apagar o objeto com o nome \"Orlando\"");
        if (gestaoCompromissos.ApagarCompromisso("Orlando"))
            MostrarLista(gestaoCompromissos.GetCompromissoList());

        Console.WriteLine($"Verificar o objeto com o nome \"{novo1.Nome}\"");
        if (gestaoCompromissos.ExisteCliente(novo1.Nome))
        {
            Console.WriteLine($"Modificar a data do objeto com o nome \"{novo1.Nome}\"");
            gestaoCompromissos.ModificarCompromisso(novo1, 15, 3);
        }

        Console.WriteLine("Adicionar o objeto com o nome \"Armando\"");
        gestaoCompromissos.AdicionarCompromisso(gestaoCompromissos.NovoCompromisso(19, 2, "Armando", "Mini+Amendoins"));

        Console.WriteLine("Listar os objetos");
        MostrarLista(gestaoCompromissos.GetCompromissoList());

        Console.WriteLine("Serializar a lista");
        gestaoCompromissos.ExportarDados();
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="lista"></param>
    private static void MostrarLista(List<string> lista)
    {
        foreach (var item in lista)
        {
            Console.WriteLine(item.ToString());
        }
    }
}