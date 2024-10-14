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
    public class CampaignTypesService : ICampaignTypesService
    {
        private readonly ICampaignTypesQuery _query;

        public CampaignTypesService(ICampaignTypesQuery query)
        {
            _query = query;
        }

        public async Task<List<CampaignTypesResponseDTO>> ListAllCampaignTypes()
        {
            List<CampaignTypes> list = await _query.GetAllCampaignTypes();
            List<CampaignTypesResponseDTO> listDTO = new List<CampaignTypesResponseDTO>();
            if (list != null)
            {
                foreach(CampaignTypes obj in list)
                {
                    CampaignTypesResponseDTO dto = new CampaignTypesResponseDTO 
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
