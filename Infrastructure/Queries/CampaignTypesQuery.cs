using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interface.InterfaceQueries;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Querys
{
    public class CampaignTypesQuery : ICampaignTypesQuery
    {
        private readonly CRMContext _context;

        public CampaignTypesQuery(CRMContext context)
        {
            _context = context;
        }

        public async Task<List<CampaignTypes>> GetAllCampaignTypes()
        {
            List<CampaignTypes> list = await _context.CampaignTypes.ToListAsync();
            return list;
        }
        public async Task<CampaignTypes?> GetByID(int id)
        {
            CampaignTypes? campaignTypes = await _context.CampaignTypes.FirstOrDefaultAsync(i => i.Id == id);
            return campaignTypes;
        }
    }
}
