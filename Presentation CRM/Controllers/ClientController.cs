using Application.Exceptions;
using Application.Interface.Interface;
using Application.Interface.InterfaceCommand;
using Application.Interface.InterfaceService;
using Application.Models.RequestDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation_CRM.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _service;

        public ClientController(IClientService service)
        {
            _service = service;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.ListAllClient();
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(ClientsRequestDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new { message = "The data provided is not valid." });
                }
                var newClient = await _service.AddClient(dto);
                return Created(string.Empty, newClient);
            }
            catch (Application.Exceptions.InvalidDataException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (EmailAlreadyExistsException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "A mistake has occurred." });
            }
        }
    }
}
