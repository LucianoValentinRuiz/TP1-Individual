using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface.Interface

{
    public interface IUsersQuery
    {
        public Task<List<Users>> GetAllUsers();
        public Task<Users?> GetByID(int id);

    }
}
