using Application.Interface.Interface;
using Application.Interface.InterfaceQueries;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Querys
{
    public class ClientsQuery : IClientsQuery
    {
        private readonly CRMContext _context;

        public ClientsQuery(CRMContext context)
        {
            _context = context;
        }

        public async Task<List<Clients>> GetAllClients()
        {
            List<Clients> list = await _context.Clients.ToListAsync();
            return list;
        }
        public async Task<Clients?> GetByID(int id)
        {
            Clients? client = await _context.Clients.FirstOrDefaultAsync(i => i.ClientID == id);
            return client;
        }

        public async Task<bool> EmailExist(string email)
        {
            return  await _context.Clients.AnyAsync(c => c.Email == email);
        }
    }
}
