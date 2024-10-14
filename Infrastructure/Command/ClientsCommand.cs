using Application.Exceptions;
using Application.Interface.InterfaceCommand;
using Application.Models.RequestDTO;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Command
{
    public class ClientsCommand : IClientsCommand
    {
        private readonly CRMContext _context;

        public ClientsCommand(CRMContext context)
        {
            _context = context;
        }
        public async Task<Clients> InsertClients(Clients client)
        {
            _context.Add(client);
            await _context.SaveChangesAsync();
            return client;
        }
    }
}
