using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface.InterfaceCommand
{
    public interface ITasksCommand
    {
        public Task<Tasks> InsertTask(Tasks task);
        public Task<Tasks> UpdateTask(Tasks task, Guid id);
    }
}
