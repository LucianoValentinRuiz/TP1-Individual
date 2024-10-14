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
    public class UsersQuery : IUsersQuery
    {
        private readonly CRMContext _context;

        public UsersQuery(CRMContext context)
        {
            _context = context;
        }
        public async Task<List<Users>> GetAllUsers()
        {
            List<Users> users = await _context.Users.ToListAsync();
            return users;
        }
        public async Task<Users?> GetByID(int id)
        {
            Users? user = await _context.Users.FirstOrDefaultAsync(i => i.UserID == id);
            return user;
        }
    }
}
