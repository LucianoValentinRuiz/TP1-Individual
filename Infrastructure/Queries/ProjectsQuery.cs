using Application.Interface.Interface;
using Application.Interface.InterfaceQueries;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Querys
{
    public class ProjectsQuery : IProjectsQuery
    {
        private readonly CRMContext _context;

        public ProjectsQuery(CRMContext context)
        {
            _context = context;
        }
        public async Task<List<Projects>> GetAllProjectsByFilters(string? name, int? capaignId, int? clientId, int? offset, int? size)
        {
            IQueryable<Projects> query = _context.Projects.AsQueryable();
            if (!string.IsNullOrEmpty(name))
                query = query.Where(n => n.ProjectName.Contains(name));
            if (capaignId != null)
                query = query.Where(n => n.CampaignType == capaignId);
            if (clientId != null)
                query = query.Where(n => n.ClientID == clientId);
            if (offset != null)
            {
                int num = offset.Value;
                query = query.Skip(num);
            }
            if (size != null)
            {
                int num = size.Value;
                query = query.Take(num);
            }
            return await query
                .Include(t => t.Clients)
                .Include(t => t.CampaignTypes)
                .ToListAsync(); ;
        }
        public async Task<Projects?> GetByID(Guid id)
        {
            Projects? project = await _context.Projects
                .Include(t => t.Clients)
                .Include(t => t.CampaignTypes)
                .FirstOrDefaultAsync(s => s.ProjectID == id);
            return project;
        }
        public async Task<bool> GetByName(string name)
        {
            Projects? project = await _context.Projects.FirstOrDefaultAsync(s => s.ProjectName == name);
            return project == null;
        }

    }
}
