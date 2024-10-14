using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.RequestDTO
{
    public class ProjectsRequestDTO
    {
        public string name { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public int client { get; set; }
        public int campaignType { get; set; }
    }
}
