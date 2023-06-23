

using SerializeTools;
using System.Xml.Serialization;
using ToolBox;

[Serializable]
public enum Prioridade : byte
{
    Alta = 1,
    Media = 2,
    Baixa = 3
};


[Serializable]
public enum TipoAgendamento : byte
{
    Profissional = 1,
    Pessoal = 2
}


/// <summary>
/// estrutura para serialização
/// </summary>
[Serializable]
public struct RegistoCompromisso
{
    [XmlAttribute]
    public int Id { get; set; }
    [XmlAttribute]
    public DateTime Data { get; set; }
    [XmlAttribute]
    public int Bloco { get; set; }
    [XmlAttribute]
    public Prioridade Prioridade { get; set; }
    [XmlAttribute]
    public string Nome { get; set; }
    [XmlAttribute]
    public string Assunto { get; set; }
    [XmlAttribute]
    public TipoAgendamento TipoAgendamento { get; set; }
    [XmlAttribute]
    public bool Concluido { get; set; }
    [XmlAttribute]
    public DateTime Conclusao { get; set; }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public override string? ToString()
    {
        return $"{Id}, {Data}\t{Nome}, {Assunto}";
    }
}


[XmlRoot(ElementName = "Compromissos")]
public class CompromissosBD
{
    public CompromissosBD()
    {
        Items = new List<RegistoCompromisso>();
    }

    [XmlElement(ElementName = "Compromisso")]
    public List<RegistoCompromisso> Items { get; set; }
}


public class Constantes
{
    public const string NomeXmlCompromissos = "ListaCompromissos.xml";
}


internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        CompromissosBD lista = new CompromissosBD();
        lista.Items.Add(NovoCompromisso(9, 1, "João", "Atendimento"));
        lista.Items.Add(NovoCompromisso(9, 2, "Alberto", "Atendimento"));
        lista.Items.Add(NovoCompromisso(9, 3, "Mariana", "Atendimento"));
        lista.Items.Add(NovoCompromisso(9, 4, "Joaquim", "Atendimento"));
        lista.Items.Add(NovoCompromisso(10, 1, "Alexandre", "Atendimento"));
        lista.Items.Add(NovoCompromisso(10, 2, "Joaquina", "Atendimento"));
        lista.Items.Add(NovoCompromisso(10, 3, "Alexandrina", "Atendimento"));
        lista.Items.Add(NovoCompromisso(10, 4, "Vieira", "Atendimento"));
        lista.Items.Add(NovoCompromisso(11, 1, "Pereira", "Atendimento"));
        lista.Items.Add(NovoCompromisso(11, 2, "Agostinho", "Atendimento"));

        MostrarLista(lista);

        XmlMethods.SerializeToXml(lista, Constantes.NomeXmlCompromissos);

    }

    private static void MostrarLista(CompromissosBD lista)
    {
        foreach (var item in lista.Items)
        {
            Console.WriteLine(item.ToString());
        }
    }

    private static RegistoCompromisso NovoCompromisso(int hora, int bloco, string nome, string assunto,
            Prioridade prioridade = Prioridade.Media,
            TipoAgendamento tipoAgendamento = TipoAgendamento.Profissional)
    {
        int tBloco = bloco < 1 ? 1 : (bloco > 4 ? 4 : bloco);
        int tHora = hora < 0 ? 0 : (hora > 23 ? 23 : hora);
        DateTime data = DateTime.Now;
        DateTime tData = new DateTime(data.Year, data.Month, data.Day, tHora, (tBloco - 1) * 15, 0);
        Prioridade tPrioridade = prioridade;
        string tNome = nome.Trim();
        if (tNome.Length == 0) throw new ArgumentNullException(nameof(tNome));
        string tAssunto = assunto ?? throw new ArgumentNullException(nameof(assunto));
        TipoAgendamento tTipoAgendamento = tipoAgendamento;

        return new RegistoCompromisso {
            Id = GetNewId.Instancia.Proximo,
            Data = tData,
            Bloco = tBloco,
            Nome = tNome,
            Assunto = tAssunto,
            Prioridade = tPrioridade,
            TipoAgendamento = tTipoAgendamento,
            Concluido = false
        };
    }
}
