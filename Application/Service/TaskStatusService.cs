using Application.Interface.InterfaceQueries;
using Application.Interface.InterfaceService;
using Application.Models.ResponseDTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class TaskStatusService : ITaskStatusService
    {
        private readonly ITaskStatusQuery _query;
        public TaskStatusService(ITaskStatusQuery query)
        {
            _query = query;
        }

        public async Task<List<TaskStatusResponseDTO>> ListAllTaskStatus()
        {
            List<Domain.Entities.TaskStatus> list = await _query.GetAllTasksStatus();
            List<TaskStatusResponseDTO> listDTO = new List<TaskStatusResponseDTO>();
            if (list != null)
            {
                foreach (Domain.Entities.TaskStatus obj in list)
                {
                    TaskStatusResponseDTO dto = new TaskStatusResponseDTO
                    {
                        id = obj.Id,
                        name = obj.Name,
                    };
                    listDTO.Add(dto);
                }
                return listDTO;
            }
            return listDTO;
        }
    }
}
