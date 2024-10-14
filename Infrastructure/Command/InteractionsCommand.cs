using Application.Interface.InterfaceCommand;
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
    public class InteractionsCommand : IInteractionsCommand
    {
        private readonly CRMContext _context;

        public InteractionsCommand(CRMContext context)
        {
            _context = context;
        }

        public async Task<Interactions> InsertInteraction(Interactions interaction)
        {
            _context.Add(interaction);
            Projects projecto = await _context.Projects.FirstOrDefaultAsync(s => s.ProjectID == interaction.ProjectID);
            projecto.UpdateDate = DateTime.Now;
            await _context.SaveChangesAsync();
            return interaction;
        }
    }
}
