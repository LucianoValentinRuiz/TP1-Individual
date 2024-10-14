using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface.InterfaceQueries
{
    public interface ITasksQuery
    {
        public Task<Tasks> GetByID(Guid id);
        public Task<List<Tasks>> GetAllByProjectID(Guid id);
        public Task<bool> ExistReferenceUser(int userId);
        public Task<bool> ExistReferenceStatus(int userId);
    }
}
