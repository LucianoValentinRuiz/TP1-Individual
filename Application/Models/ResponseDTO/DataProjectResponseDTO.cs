using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.ResponseDTO
{
    public class DataProjectResponseDTO
    {
        public ProjectResponseDTO data {get; set;}
        public List<InteractionResponseDTO?> interaction { get; set;}
        public List<TasksResponseDTO?> tasks { get; set;}

    }
}
