using Application.Exceptions;
using Application.Interface.Interface;
using Application.Interface.InterfaceCommand;
using Application.Interface.InterfaceQueries;
using Application.Interface.InterfaceService;
using Application.Models.RequestDTO;
using Application.Models.ResponseDTO;
using Application.Validation;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectsCommand _command;
        private readonly IProjectsQuery _query;
        private readonly IInteractionsQuery _queryInteraction;
        private readonly ITasksQuery _queryTask;
        private readonly ICampaignTypesQuery _campaignTypesQuery;
        private readonly IClientsQuery _clientsQuery;

        public ProjectService(IProjectsCommand command, IProjectsQuery query, IInteractionsQuery queryInteraction, ITasksQuery queryTask, ICampaignTypesQuery campaignTypesQuery, IClientsQuery clientsQuery)
        {
            _command = command;
            _query = query;
            _queryInteraction = queryInteraction;
            _queryTask = queryTask;
            _campaignTypesQuery = campaignTypesQuery;
            _clientsQuery = clientsQuery;
        }

        public async Task<List<ProjectResponseDTO>> GetProjects(string? name, int? capaignId, int? clientId, int? offset, int? size)
        {
            List<Projects> list = await _query.GetAllProjectsByFilters(name,capaignId,clientId,offset,size);
            List<ProjectResponseDTO> listDto = new List<ProjectResponseDTO>();
            if(list != null)
            {
                foreach(Projects obj in list)
                {
                    ProjectResponseDTO dto = new ProjectResponseDTO
                    {
                       id = obj.ProjectID, 
                       name = obj.ProjectName,
                       start = obj.CreateDate,
                       end = obj.EndDate,
                       client = new ClientResponseDTO 
                       {
                           id = obj.Clients.ClientID,
                           name = obj.Clients.Name,
                           email = obj.Clients.Email,
                           company = obj.Clients.Company,
                           phone = obj.Clients.Phone,
                           address = obj.Clients.Address,
                       },
                       campaignType = new CampaignTypesResponseDTO
                       {
                           id = obj.CampaignTypes.Id,
                           name = obj.CampaignTypes.Name,
                       },
                    };
                    listDto.Add(dto);
                }
                return listDto;
            }
            return listDto;
        }

        public async Task<DataProjectResponseDTO?> AddProject(ProjectsRequestDTO dto)
        {
            DateValidation dateValidation = new DateValidation();
            if (!dateValidation.IsValid(dto.start, dto.end))
                throw new InvalidDateRangeException($"The start date is greater than the end date.");
            bool exist = await _query.GetByName(dto.name);
            if (exist)
            {
                if (await _campaignTypesQuery.GetByID(dto.campaignType) == null)
                    throw new NotFoundException($"The campaign type entered was not found");

                if (await _clientsQuery.GetByID(dto.client) == null)
                    throw new NotFoundException($"The client entered was not found");

                Projects projModel = new Projects
                {
                    ProjectName = dto.name,
                    StartDate = dto.start,
                    EndDate = dto.end,
                    ClientID = dto.client,
                    CampaignType = dto.campaignType,
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.MinValue,
                };
                Projects? projCreated = await _command.InsertProject(projModel);
                return await this.GetProjectById(projCreated.ProjectID);
            }
            else
                throw new NotFoundException($"The project name '{dto.name}' already exists.");
        }

        public async Task<DataProjectResponseDTO> GetProjectById(Guid projectId)
        {
            Projects? projCreated = await _query.GetByID(projectId);
            if (projCreated == null)
                throw new NotFoundException($"The project with the ID {projectId} was not found.");
            else
                return await this.ProjectToDataDTO(projCreated);
        }

        private async Task<DataProjectResponseDTO> ProjectToDataDTO(Projects projCreated)
        {
            List<Interactions> RelatedInteraction = await _queryInteraction.GetAllByProjectID(projCreated.ProjectID);
            List<Tasks> RelatedTasks = await _queryTask.GetAllByProjectID(projCreated.ProjectID);

            List< InteractionResponseDTO> listInteractionDTO = new List<InteractionResponseDTO>();
            foreach (Interactions item in RelatedInteraction)
            {
                InteractionResponseDTO dto = new InteractionResponseDTO
                {
                    id = item.InteractionID,
                    notes = item.Notes,
                    date = item.Date,
                    projectId = item.ProjectID,
                    interactionType = new InteractionTypesResponseDTO
                    {
                        id = item.InteractionTypes.Id,
                        name = item.InteractionTypes.Name,
                    }
                };
                listInteractionDTO.Add(dto);
            }

            List<TasksResponseDTO> listTaskDTO = new List<TasksResponseDTO>();
            foreach (Tasks item in RelatedTasks)
            {
                TasksResponseDTO dto = new TasksResponseDTO
                {
                    id = item.TaskID,
                    name = item.Name,
                    dueDate = item.DueDate,
                    projectId = item.ProjectID,
                    status = new TaskStatusResponseDTO
                    {
                        id = item.TaskStatus.Id,
                        name = item.TaskStatus.Name,
                    },
                    userAssigned = new UsersResponseDTO
                    {
                        id = item.Users.UserID,
                        name = item.Users.Name,
                        email = item.Users.Email,
                    }
                };
                listTaskDTO.Add(dto);
            }

            return new DataProjectResponseDTO
            {
                data = new ProjectResponseDTO
                {
                    id = projCreated.ProjectID,
                    name = projCreated.ProjectName,
                    start = projCreated.CreateDate,
                    end = projCreated.EndDate,
                    client = new ClientResponseDTO
                    {
                        id = projCreated.Clients.ClientID,
                        name = projCreated.Clients.Name,
                        email = projCreated.Clients.Email,
                        company = projCreated.Clients.Company,
                        phone = projCreated.Clients.Phone,
                        address = projCreated.Clients.Address,
                    },
                    campaignType = new CampaignTypesResponseDTO
                    {
                        id = projCreated.CampaignTypes.Id,
                        name = projCreated.CampaignTypes.Name,
                    },
                },
                interaction = listInteractionDTO,
                tasks = listTaskDTO
            };
        }

    }
}
