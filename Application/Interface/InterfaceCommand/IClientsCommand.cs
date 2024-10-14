using Application.Models.RequestDTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface.InterfaceCommand
{
    public interface IClientsCommand
    {
        public Task<Clients> InsertClients(Clients client);
    }
}
