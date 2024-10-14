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
    public class InteractionsQuery : IInteractionsQuery
    {
        private readonly CRMContext _context;

        public InteractionsQuery(CRMContext context)
        {
            _context = context;
        }

        public async Task<Interactions> GetByID(Guid id)
        {
            Interactions? interaction = await _context.Interactions
                .Include(t => t.InteractionTypes)
                .FirstOrDefaultAsync(s => s.InteractionID == id);
            return interaction;
        }
        public async Task<List<Interactions>> GetAllByProjectID(Guid id)
        {
            List<Interactions> interaction = await _context.Interactions
                .Include(t => t.InteractionTypes)
                .Where(i => i.ProjectID == id)
                .ToListAsync();
            return interaction;
        }
    }
}
