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
    public class TaskStatusQuery : ITaskStatusQuery
    {
        private readonly CRMContext _context;

        public TaskStatusQuery(CRMContext context)
        {
            _context = context;
        }

        public async Task<List<Domain.Entities.TaskStatus>> GetAllTasksStatus()
        {
            List<Domain.Entities.TaskStatus> list = await _context.TaskStatus.ToListAsync();
            return list;
        }
        public async Task<Domain.Entities.TaskStatus?> GetByID (int id)
        {
            Domain.Entities.TaskStatus? taskStatus = await _context.TaskStatus.FirstOrDefaultAsync(i => i.Id == id);
            return taskStatus;
        }
    }
}
