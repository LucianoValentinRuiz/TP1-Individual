using Application.Models.ResponseDTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface.InterfaceService
{
    public interface IInteractionTypesService
    {
        public Task<List<InteractionTypesResponseDTO>> ListAllInteractionTypes();
    }
}
