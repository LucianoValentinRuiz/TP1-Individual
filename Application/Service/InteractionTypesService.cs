using Application.Interface.InterfaceQueries;
using Application.Interface.InterfaceService;
using Application.Models.ResponseDTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class InteractionTypesService : IInteractionTypesService
    {
        private readonly IInteractionTypesQuery _query;
        public InteractionTypesService(IInteractionTypesQuery query)
        {
            _query = query;
        }

        public async Task<List<InteractionTypesResponseDTO>> ListAllInteractionTypes()
        {
            List<InteractionTypes> list = await _query.GetAllInteractionTypes();
            List<InteractionTypesResponseDTO> listDTO = new List<InteractionTypesResponseDTO>();
            if (list != null)
            {
                foreach (InteractionTypes obj in list)
                {
                    InteractionTypesResponseDTO dto = new InteractionTypesResponseDTO
                    {
                        id = obj.Id,
                        name = obj.Name,
                    };
                    listDTO.Add(dto);
                }
                return listDTO;
            }
            return listDTO;
        }
    }
}
