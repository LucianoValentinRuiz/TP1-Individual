using Application.Exceptions;
using Application.Interface.InterfaceService;
using Application.Models.RequestDTO;
using Application.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Presentation_CRM.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly IInteractionsService _interactionService;
        private readonly ITasksService _tasksService;

        public ProjectController(IProjectService projectService, IInteractionsService interactionService, ITasksService tasksService)
        {
            _projectService = projectService;
            _interactionService = interactionService;
            _tasksService = tasksService;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(string? name, int? campaign, int? client, int? offset, int? size)
        {
            var result = await _projectService.GetProjects(name, campaign, client, offset, size);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(ProjectsRequestDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new { message = "The data provided is not valid."});
                }
                var newProject = await _projectService.AddProject(dto);
                return Created(string.Empty, newProject);
            }
            catch(InvalidDateRangeException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch(NotFoundException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest( new {message = "A mistake has occurred." });
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task <IActionResult> GetProjectById(Guid id)
        {
            try
            {
                var project = await _projectService.GetProjectById(id);
                return Ok(project);
            }
            catch(NotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpPatch("{id}/interactions")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddInteraction(Guid id, InteractionsRequestDTO interaction)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new { message = "The data provided is not valid." });
                }
                var result = await _interactionService.AddInteraction(interaction, id);
                return Created(string.Empty, result);
            }
            catch(NotFoundException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch(Exception ex)
            {
                return BadRequest(new {message = "A mistake has occurred." });
            }
        }

        [HttpPatch("{id}/tasks")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddTaskToProject(Guid id, TasksRequestDTO task)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new { message = "The data provided is not valid."});
                }
                var result = await _tasksService.AddTask(task, id);
                return Created(string.Empty, result);
            }
            catch (NotFoundException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "A mistake has occurred." });
            }
        }
        [HttpPut("~/api/v1/Tasks/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateTaskById(TasksUpdateRequestDTO dto,Guid id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new { message = "The data provided is not valid."});
                }
                var task = await _tasksService.RenewTask(dto, id);
                return Ok(task);
            }
            catch (ModelNullException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (NotFoundException ex)
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
