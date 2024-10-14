using Application.Models.RequestDTO;
using Application.Models.ResponseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface.InterfaceService
{
    public interface IClientService
    {
        public Task<List<ClientResponseDTO>> ListAllClient();
        public Task<ClientResponseDTO> AddClient(ClientsRequestDTO dto);
    }
}
