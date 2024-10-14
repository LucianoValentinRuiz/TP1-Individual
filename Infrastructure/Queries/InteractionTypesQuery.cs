using Application.Interface.InterfaceQueries;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Querys
{
    public class InteractionTypesQuery : IInteractionTypesQuery
    {
        private readonly CRMContext _context;

        public InteractionTypesQuery(CRMContext context)
        {
            _context = context;
        }

        public async Task<List<InteractionTypes>> GetAllInteractionTypes()
        {
            List<InteractionTypes> list = await _context.InteractionTypes.ToListAsync();
            return list;
        }
        public async Task<InteractionTypes?> GetByID(int id)
        {
            InteractionTypes? interactionTypes = await _context.InteractionTypes.FirstOrDefaultAsync(i => i.Id == id);
            return interactionTypes;
        }
    }
}
