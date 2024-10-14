using Application.Interface.InterfaceQueries;
using Application.Interface.InterfaceService;
using Application.Models.ResponseDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation_CRM.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CampaignTypeController : ControllerBase
    {
        private readonly ICampaignTypesService _service;

        public CampaignTypeController(ICampaignTypesService service)
        {
            _service = service;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll() 
        {
            var result = await _service.ListAllCampaignTypes();
            return Ok(result);
        }
    }
}
