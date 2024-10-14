using Application.Interface.Interface;
using Application.Interface.InterfaceService;
using Application.Models.ResponseDTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class UserService : IUserService
    {
        private readonly IUsersQuery _query;
        public UserService(IUsersQuery query)
        {
            _query = query;
        }

        public async Task<List<UsersResponseDTO>> ListAllUsers()
        {
            List<Users> list = await _query.GetAllUsers();
            List<UsersResponseDTO> listDTO = new List<UsersResponseDTO>();
            if (list != null)
            {
                foreach (Users obj in list)
                {
                    UsersResponseDTO dto = new UsersResponseDTO
                    {
                        id = obj.UserID,
                        name = obj.Name,
                        email = obj.Email,
                    };
                    listDTO.Add(dto);
                }
                return listDTO;
            }
            return listDTO;
        }
    }
}
