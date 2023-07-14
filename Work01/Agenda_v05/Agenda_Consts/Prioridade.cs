namespace Agenda_Consts
{

    [Serializable]
    public enum Prioridade: byte
    {
        Alta = 1, 
        Media = 2, 
        Baixa = 3
    }

    [Serializable]
    public enum TipoAgendamento: byte
    {
        Profissional = 1,
        Pessoal = 2
    }

}