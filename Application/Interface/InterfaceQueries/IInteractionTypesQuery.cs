using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface.InterfaceQueries
{
    public interface IInteractionTypesQuery
    {
        public Task<List<InteractionTypes>> GetAllInteractionTypes();
        public Task<InteractionTypes?> GetByID(int id);
    }
}
