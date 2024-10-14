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
    public class ProjectCommand : IProjectsCommand
    {
        private readonly CRMContext _context;

        public ProjectCommand(CRMContext context)
        {
            _context = context;
        }
        public async Task<Projects> InsertProject(Projects project)
        {
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
            return project;
        }

    }
}
