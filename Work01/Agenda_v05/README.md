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
  
  - [Agenda_BO](Agenda_BO/): Business Object  
  - [Agenda_BL](Agenda_BL/): Business Logic  
  - [Agenda_DAL](Agenda_DAL/): Data Access Layer  
  - [Agenda_Consts](Agenda_Consts/): Constantes  
  - [SerializeTools](SerializeTools/): SerializeToXml, DeserializeXmlToObject (estrutura genérica preparada para qualquer classe serializável)  
  - [ToolBox](ToolBox/): ToolBox (ex: GetNewId)  
  - [Agenda_Console](Agenda_Console/): 1ª Abordagem, (serializar) XmlElement  
  - [teste1xml](teste1xml/): 2ª Abordagem, (serializar) XmlAttribute  
  
-------------------
  - [Agenda_Console2Api](Agenda_Console2Api/): Programa teste do API  
  - [Agenda_Models2Api](Agenda_Models2Api/): Modelos do API  
  - [Agenda_Services2Api](Agenda_Services2Api/): Serviços (BL) do API  
  - [Agenda_WebAPI](Agenda_WebAPI/): WebAPI  
  
-------------------
  - [Agenda_BOpg](Agenda_BOpg/): Business Object (com alterações para PostgreSQL)  
  - [Agenda_BLpg](Agenda_BLpg/): Business Logic (com alterações para PostgreSQL)  
  - [Agenda_DALpg](Agenda_DALpg/): Data Access Layer (com alterações para PostgreSQL)  
  - [Agenda_Consolepg](Agenda_Consolepg/): Programa teste (com alterações para PostgreSQL)  
  - [Agenda_Configuration](Agenda_Configuration/): Configuração global  
  - [Agenda_Services2Apipg](Agenda_Services2Apipg/): Serviços (BL) do API (com alterações para PostgreSQL)  
  - [Agenda_WebAPIpg](Agenda_WebAPIpg/): WebAPI (com alterações para PostgreSQL)  
  
  
   