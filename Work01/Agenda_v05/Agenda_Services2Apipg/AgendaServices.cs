using Agenda_BLpg;

namespace Agenda_Services2Apipg
{
    public class AgendaServices
    {
        private readonly Lazy<Compromisso_BR> _compromissos =
            new Lazy<Compromisso_BR>(() => new Compromisso_BR());

        public Compromisso_BR Compromissos => _compromissos.Value;

    }
}