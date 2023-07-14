using Agenda_BOpg;
using Agenda_BLpg;

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

        Console.WriteLine("... a verificar os dados na BD ...");
        VerificarAdiciona(gestaoCompromissos, novo1);
        VerificarAdiciona(gestaoCompromissos, gestaoCompromissos.NovoCompromisso(16, 1, "Orlando", "Trabalho de grupo"));
        VerificarAdiciona(gestaoCompromissos, gestaoCompromissos.NovoCompromisso(17, 3, "Joaquim", "Mini+Amendoins"));
        VerificarAdiciona(gestaoCompromissos, gestaoCompromissos.NovoCompromisso(17, 4, "Alberto", "Mini+Amendoins"));
        VerificarAdiciona(gestaoCompromissos, gestaoCompromissos.NovoCompromisso(18, 0, "Alexandra", "Mini+Amendoins"));
        VerificarAdiciona(gestaoCompromissos, gestaoCompromissos.NovoCompromisso(18, 2, "Matilde", "Mini+Amendoins"));
        VerificarAdiciona(gestaoCompromissos, gestaoCompromissos.NovoCompromisso(18, 3, "Vieira", "Mini+Amendoins"));

        Console.WriteLine("Listar os objetos");
        MostrarLista(gestaoCompromissos.GetCompromissoList());

        Console.WriteLine("Apagar o objeto com o nome \"Orlando\"");
        if (gestaoCompromissos.ApagarCompromisso("Orlando"))
            MostrarLista(gestaoCompromissos.GetCompromissoList());

        Console.WriteLine($"Verificar o objeto com o nome \"{novo1.Nome}\"");
        if (gestaoCompromissos.ExisteCompromisso(novo1.Nome))
        {
            Console.WriteLine($"Modificar a data do objeto com o nome \"{novo1.Nome}\"");
            gestaoCompromissos.ModificarCompromisso(novo1, 15, 3);
        }

        Console.WriteLine("Adicionar o objeto com o nome \"Armando\"");
        gestaoCompromissos.AdicionarCompromisso(gestaoCompromissos.NovoCompromisso(19, 2, "Armando", "Mini+Amendoins"));

        Console.WriteLine("Listar os objetos");
        MostrarLista(gestaoCompromissos.GetCompromissoList());

    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="br"></param>
    /// <param name="novo"></param>
    private static void VerificarAdiciona(Compromisso_BR br, Compromisso novo)
    {
        if (novo != null)
        {
            Compromisso? obj = null;
            if (!br.ExisteCompromisso(novo.Nome, out obj))
            {
                br.AdicionarCompromisso(novo);
                Console.WriteLine($"Compromisso para {novo.Nome} foi adicionado na BD!");
            }
            else
            {
                Console.WriteLine($"Compromisso para {novo.Nome} já existe na BD!");
            }
        }
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
