using Application.Models.RequestDTO;
using Application.Models.ResponseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface.InterfaceService
{
    public interface IProjectService
    {
        public Task<List<ProjectResponseDTO>> GetProjects(string? name, int? capaignId, int? clientId, int? offset, int? size);
        public Task<DataProjectResponseDTO> AddProject(ProjectsRequestDTO dto);
        public Task<DataProjectResponseDTO> GetProjectById(Guid projectId);
    }
}
