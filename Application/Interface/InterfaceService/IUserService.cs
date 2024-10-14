using Application.Models.ResponseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface.InterfaceService
{
    public interface IUserService
    {
        public Task<List<UsersResponseDTO>> ListAllUsers();
    }
}
