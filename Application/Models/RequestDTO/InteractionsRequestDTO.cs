using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.RequestDTO
{
    public class InteractionsRequestDTO
    {
        public string notes { get; set; }
        public DateTime date { get; set; }
        public int interactionType { get; set; }
    }
}
