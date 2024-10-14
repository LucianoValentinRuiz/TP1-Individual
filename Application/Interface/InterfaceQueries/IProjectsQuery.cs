using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface.Interface

{
    public interface IProjectsQuery
    {
        public Task<Projects> GetByID(Guid id);
        public Task<List<Projects>> GetAllProjectsByFilters(string? name, int? capaignId, int? clientId, int? offset, int? size);
        public Task<bool> GetByName(string name);
    }
}
