using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models.ResponseDTO;

namespace Application.Interface.InterfaceService
{
    public interface ICampaignTypesService
    {
        public Task<List<CampaignTypesResponseDTO>> ListAllCampaignTypes();
    }
}
