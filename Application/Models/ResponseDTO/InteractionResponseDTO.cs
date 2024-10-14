using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.ResponseDTO
{
    public class InteractionResponseDTO
    {
        public Guid id { get; set; }
        public string notes { get; set; }
        public DateTime date { get; set; }
        public Guid projectId { get; set; }
        public InteractionTypesResponseDTO interactionType { get; set; }
    }
}
