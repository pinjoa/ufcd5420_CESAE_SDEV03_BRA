using Agenda_Models2Api;
using Agenda_Services2Api;
using Microsoft.AspNetCore.Mvc;

namespace Agenda_WebAPI.Controllers
{
    /// <summary>
    /// agendamento de compromissos
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AgendaController : ControllerBase
    {
        /// <summary>
        /// devolve a lista de compromissos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<AgendaRegistoResponse>), StatusCodes.Status200OK)]
        public IActionResult Index()
        {
            AgendaServices _servicos = new AgendaServices();
            _servicos.Compromissos.ImportarDados();
            return new ObjectResult(_servicos.Compromissos.GetCompromissoListResponse());
        }

        /// <summary>
        /// obter compromisso
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(AgendaRegistoResponse), StatusCodes.Status200OK)]
        public IActionResult GetId(int id)
        {
            AgendaServices _servicos = new AgendaServices();
            _servicos.Compromissos.ImportarDados();
            AgendaRegistoResponse? agendaRegistoResponse =
                _servicos.Compromissos.ObterCompromissoResponse(id);
            if (agendaRegistoResponse != null)
            {
                return new ObjectResult(agendaRegistoResponse);
            }
            return new NotFoundResult();
        }

        /// <summary>
        /// inserir compromisso
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] AgendaRegistoRequest value)
        {
            AgendaServices _servicos = new AgendaServices();
            _servicos.Compromissos.ImportarDados();
            if (_servicos.Compromissos.AdicionarCompromissoRequest(value))
            {
                _servicos.Compromissos.ExportarDados();
                return new OkResult();
            }
            return new BadRequestResult();
        }

        /// <summary>
        /// modificar compromisso
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] AgendaRegistoRequest value)
        {
            AgendaServices _servicos = new AgendaServices();
            _servicos.Compromissos.ImportarDados();
            if (_servicos.Compromissos.ModificarCompromissoRequest(id, value))
            {
                _servicos.Compromissos.ExportarDados();
                return new OkResult();
            }
            return new BadRequestResult();
        }

        /// <summary>
        /// apagar compromisso
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            AgendaServices _servicos = new AgendaServices();
            _servicos.Compromissos.ImportarDados();
            if (_servicos.Compromissos.ApagarCompromisso(id))
            {
                _servicos.Compromissos.ExportarDados();
                return new OkResult();
            }
            return new BadRequestResult();
        }


    }
}
