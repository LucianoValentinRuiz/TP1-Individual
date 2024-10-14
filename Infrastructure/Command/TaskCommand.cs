using Application.Interface.InterfaceCommand;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Command
{
    public class TaskCommand : ITasksCommand
    {
        private readonly CRMContext _context;

        public TaskCommand(CRMContext context)
        {
            _context = context;
        }

        public async Task<Tasks> InsertTask(Tasks task)
        {
            await _context.AddAsync(task);

            Projects projecto = await _context.Projects.FirstOrDefaultAsync(s => s.ProjectID == task.ProjectID);
            projecto.UpdateDate = DateTime.Now;

            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<Tasks> UpdateTask(Tasks task, Guid id)
        {
            Tasks? TaskUpdate = await _context.Tasks.FirstOrDefaultAsync(s => s.TaskID == id);
            if (TaskUpdate != null )
            {
                {
                    if (task.Name != null)
                        TaskUpdate.Name = task.Name;

                    if (task.DueDate != null && task.DueDate != DateTime.MinValue)
                        TaskUpdate.DueDate = task.DueDate;

                    if (task.AssignedTo != 0)
                        TaskUpdate.AssignedTo = task.AssignedTo;

                    if (task.Status != 0)
                        TaskUpdate.Status = task.Status;

                    task.UpdateDate = DateTime.Now;

                    await _context.SaveChangesAsync();
                }
                return TaskUpdate;
            }
            else
                return null;
        }
    }
}
