using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface.InterfaceQueries
{
    public interface IInteractionsQuery
    {
        public Task<Interactions> GetByID(Guid id);
        public Task<List<Interactions>> GetAllByProjectID(Guid id);
    }
}
