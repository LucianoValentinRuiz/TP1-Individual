using Application.Models.RequestDTO;
using Application.Models.ResponseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface.InterfaceService
{
    public interface ITasksService
    {
        public Task<TasksResponseDTO> AddTask(TasksRequestDTO dTO, Guid ProjectID);
        public Task<TasksResponseDTO> RenewTask(TasksUpdateRequestDTO dto, Guid id);
    }
}
