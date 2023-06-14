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
        Compromisso novo2 = gestaoCompromissos.NovoCompromisso(16, 1, "Orlando", "Trabalho de grupo");
        Compromisso novo3 = gestaoCompromissos.NovoCompromisso(17, 3, "Joaquim", "Mini+Amendoins");

        gestaoCompromissos.AdicionarCompromisso(novo1);
        gestaoCompromissos.AdicionarCompromisso(novo2);
        gestaoCompromissos.AdicionarCompromisso(novo3);

        MostrarLista(gestaoCompromissos.GetCompromissoList());

        if (gestaoCompromissos.ApagarCompromisso("Orlando"))
            MostrarLista(gestaoCompromissos.GetCompromissoList());
        

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