using Application.Exceptions;
using Application.Interface.Interface;
using Application.Interface.InterfaceCommand;
using Application.Interface.InterfaceService;
using Application.Models.RequestDTO;
using Application.Models.ResponseDTO;
using Application.Validation;
using Domain.Entities;
using System.Net.Mail;

namespace Application.Service
{
    public class ClientsService : IClientService
    {
        private readonly IClientsCommand _command;
        private readonly IClientsQuery _query;

        public ClientsService(IClientsCommand command, IClientsQuery query)
        {
            _command = command;
            _query = query;
        }

        public async Task<List<ClientResponseDTO>> ListAllClient()
        {
            List<Clients> list = await _query.GetAllClients();
            List<ClientResponseDTO> listDTO = new List<ClientResponseDTO>();
            if (list != null)
            {
                foreach (Clients obj in list)
                {
                    ClientResponseDTO dto = new ClientResponseDTO
                    {
                        id = obj.ClientID,
                        name = obj.Name,
                        email = obj.Email,
                        company = obj.Company,
                        phone = obj.Phone,
                        address = obj.Address,
                    };
                    listDTO.Add(dto);
                }
                return listDTO;
            }
            return listDTO;
        }


        public async Task<ClientResponseDTO> AddClient(ClientsRequestDTO dto)
        {
            ClientsValidation Validator = new ClientsValidation();
            if (!Validator.IsValidEmail(dto.email))
            {
                throw new Exceptions.InvalidDataException($"The email '{dto.email}' has no valid format.");
            }
            if (!Validator.IsValidPhone(dto.phone))
            {
                throw new Exceptions.InvalidDataException($"The phone '{dto.phone}' has no valid format.");
            }
            if (await _query.EmailExist(dto.email))
                throw new EmailAlreadyExistsException($"The email ¨{dto.email}¨ already exists");
            Clients objModel = new Clients
            {
                Name = dto.name,
                Email = dto.email,
                Phone = dto.phone,
                Company = dto.company,
                Address = dto.address,
                CreateDate = DateTime.Now,
            };
            Clients objCreated = await _command.InsertClients(objModel);
            return new ClientResponseDTO
            {
                id = objCreated.ClientID,
                name = objCreated.Name,
                email = objCreated.Email,
                company = objCreated.Company,
                phone = objCreated.Phone,
                address = objCreated.Address,
            };
        }
    }
}
