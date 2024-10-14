using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.RequestDTO
{
    public class TasksRequestDTO
    {
        public string name { get; set; }
        public DateTime dueDate { get; set; }
        public int user { get; set; }
        public int status { get; set; }
    }
}
