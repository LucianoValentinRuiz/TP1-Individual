using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface.InterfaceQueries
{
    public interface ITaskStatusQuery
    {
        public Task<List<Domain.Entities.TaskStatus>> GetAllTasksStatus();
        public Task<Domain.Entities.TaskStatus?> GetByID(int id);
    }
}
