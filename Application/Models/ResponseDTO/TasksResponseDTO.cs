using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.ResponseDTO
{
    public class TasksResponseDTO
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public DateTime dueDate { get; set; }
        public Guid projectId { get; set; }
        public TaskStatusResponseDTO status { get; set; }
        public UsersResponseDTO userAssigned { get; set; }
    }
}
