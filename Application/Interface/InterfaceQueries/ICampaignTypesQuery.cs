using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface.InterfaceQueries
{
    public interface ICampaignTypesQuery
    {
        public Task<List<CampaignTypes>> GetAllCampaignTypes();
        public Task<CampaignTypes?> GetByID(int id);

    }
}
