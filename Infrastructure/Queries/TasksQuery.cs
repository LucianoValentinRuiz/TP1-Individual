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
    public class TasksQuery : ITasksQuery
    {
        private readonly CRMContext _context;

        public TasksQuery(CRMContext context)
        {
            _context = context;
        }

        public async Task<Tasks> GetByID(Guid id)
        {
            Tasks? tasks = await _context.Tasks
               .Include(t => t.TaskStatus)
               .Include(t => t.Users)
               .FirstOrDefaultAsync(s => s.TaskID == id);
            return tasks;
        }

        public async Task<List<Tasks>> GetAllByProjectID(Guid id)
        {
            List<Tasks> tasks = await _context.Tasks
               .Include(t => t.TaskStatus)
               .Include(t => t.Users)
               .Where(s => s.ProjectID == id)
               .ToListAsync();

            return tasks;
        }

        public async Task<bool> ExistReferenceUser(int userId)
        {
            Users? user = await _context.Users.FirstOrDefaultAsync(i => i.UserID == userId);
            if (user == null) 
                return false;   //Existe
            else return true;   //No existe
        }

        public async Task<bool> ExistReferenceStatus(int statusId)
        {
            Domain.Entities.TaskStatus? status = await _context.TaskStatus.FirstOrDefaultAsync(i => i.Id == statusId);
            if (status == null)
                return false;   //Existe
            else return true;   //No existe
        }
    }
}
