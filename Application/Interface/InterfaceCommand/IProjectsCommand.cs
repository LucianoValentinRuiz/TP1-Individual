using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface.InterfaceCommand
{
    public interface IProjectsCommand
    {
        public Task<Projects> InsertProject(Projects project);
    }
}
