using Application.Interface.InterfaceQueries;
using Application.Interface.InterfaceService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation_CRM.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class InteractionTypesController : ControllerBase
    {
        private readonly IInteractionTypesService _service;
        public InteractionTypesController(IInteractionTypesService service)
        {
            _service = service;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.ListAllInteractionTypes();
            return Ok(result);
        }
    }
}
