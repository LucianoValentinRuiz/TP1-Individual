using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface.Interface

{
    public interface IClientsQuery
    {
        public Task<List<Clients>> GetAllClients();
        public Task<Clients?> GetByID(int id);
        public Task<bool> EmailExist(string email);
    }
}
