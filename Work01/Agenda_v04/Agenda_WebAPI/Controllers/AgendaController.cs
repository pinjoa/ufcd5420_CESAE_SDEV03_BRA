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
    }
}
