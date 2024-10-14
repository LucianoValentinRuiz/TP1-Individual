using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.RequestDTO
{
    public class ClientsRequestDTO
    {
        public string name { get; set; }
        public string email { get; set; }
        public string company { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
    }
}
