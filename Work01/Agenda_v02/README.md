# CESAE ISI 5421 
 
## Work01
 
Projeto que evolui com a matéria da aula.

**Enunciado versão 01**:

Recebemos uma encomenda do Sr António Ocupado, um consultor que dedica apenas 15min do seu tempo para cada cliente. 

Este método de trabalho está a criar-lhe constrangimentos na gestão do agendamento de compromissos.

Para evitar colisões de agendamento pediu um sistema que permita registar este conjunto de dados ordenados por Data/Hora:
  - Data/Hora (ajustar para blocos de 15min);
  - Nº bloco (1-4);
  - Prioridade (1-alta, 2-média, 3-baixa);
  - Nome do cliente;
  - Assunto;
  - Tipo de agendamento (Profissional, Pessoal);
  - Concluído (S/N)
  - Data/Hora da conclusão;

**Enunciado versão 02**:

Estrutura alterada:
  - Id;

*Detalhe da solução*:

[Agenda_BO](Agenda_BO/) Business Object
[Agenda_BL](Agenda_BL/) Business Logic
[Agenda_DAL](Agenda_DAL/) Data Access Layer
[Agenda_Consts](Agenda_Consts/) Constantes
[SerializeTools](SerializeTools/) SerializeToXml, DeserializeXmlToObject
[ToolBox](ToolBox/) ToolBox (ex: GetNewId)
[Agenda_console](Agenda_console/) 1ª Abordagem (serializar XmlElement)
[teste1xml](teste1xml/) 2ª Abordagem (serializar XmlAttribute)

