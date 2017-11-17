using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GroomerPlus.Core.Entities;
using GroomerPlus.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GroomerPlus.Infrastructure.Repositories.SqlServer
{
    public class SqlServerClientRepository : IClientRepository
    {
        private readonly GroomingContext context;

        public SqlServerClientRepository(GroomingContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddClient(Client client)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));    
            }

            this.context.Clients.Add(client);
            await this.context.SaveChangesAsync();
        }

        public async Task<Client> GetClientById(int id)
        {
            return await this.context.Clients.SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Client>> GetAllClients()
        {
            return await this.context.Clients.AsNoTracking().ToListAsync();
        }
    }
}
