using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.ResponseDTO
{
    public class ProjectResponseDTO
    {
        public Guid id {  get; set; }
        public string name { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public ClientResponseDTO client {  get; set; }
        public CampaignTypesResponseDTO campaignType { get; set; }
    }
}
