using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface.InterfaceCommand
{
    public interface IInteractionsCommand
    {
        public Task<Interactions> InsertInteraction(Interactions interaction);
    }
}
