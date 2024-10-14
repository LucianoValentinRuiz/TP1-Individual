using Application.Exceptions;
using Application.Interface.Interface;
using Application.Interface.InterfaceCommand;
using Application.Interface.InterfaceQueries;
using Application.Interface.InterfaceService;
using Application.Models.RequestDTO;
using Application.Models.ResponseDTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class InteractionsService : IInteractionsService
    {
        private readonly IInteractionsCommand _command;
        private readonly IInteractionsQuery _query;
        private readonly IProjectsQuery _projectQuery;
        private readonly IInteractionTypesQuery _interactionTypesQuery;

        public InteractionsService(IInteractionsCommand command, IInteractionsQuery query, IProjectsQuery projectQuery, IInteractionTypesQuery interactionTypesQuery)
        {
            _command = command;
            _query = query;
            _projectQuery = projectQuery;
            _interactionTypesQuery = interactionTypesQuery;
        }

        public async Task<InteractionResponseDTO> AddInteraction(InteractionsRequestDTO dto, Guid ProjectID)
        {
            bool existProject = await _projectQuery.GetByID(ProjectID) != null;
            if (existProject)
            {
                if (await _interactionTypesQuery.GetByID(dto.interactionType) == null)
                    throw new NotFoundException($"Interaction type with ID {dto.interactionType} not found.");

                Interactions objModel = new Interactions
                {
                    ProjectID = ProjectID,
                    Notes = dto.notes,
                    Date = dto.date,
                    InteractionType = dto.interactionType,
                };
                Interactions objCreate = await _command.InsertInteraction(objModel);
                return new InteractionResponseDTO
                {
                    id = objCreate.InteractionID,
                    notes = objCreate.Notes,
                    date = objCreate.Date,
                    projectId = objCreate.ProjectID,
                    interactionType = new InteractionTypesResponseDTO
                    {
                        id = objCreate.InteractionTypes.Id,
                        name = objCreate.InteractionTypes.Name,
                    },
                }; ;
            }
            else throw new NotFoundException($"The project with the ID {ProjectID} was not found.");
        }
    }
}
