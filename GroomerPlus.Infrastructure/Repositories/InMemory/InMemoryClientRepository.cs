using System.Collections.Generic;
using System.Threading.Tasks;
using GroomerPlus.Core.Entities;
using GroomerPlus.Core.Repositories;

namespace GroomerPlus.Infrastructure.Repositories.InMemory
{
    public class InMemoryClientRepository : IClientRepository
    {
        private int currentId;

        private readonly Dictionary<int, Client> clients;

        public InMemoryClientRepository()
        {
            this.currentId = 1;
            this.clients = new Dictionary<int, Client>();
        }

        public Task AddClient(Client client)
        {
            client.Id = currentId++;
            this.clients.Add(client.Id, client);
            return Task.CompletedTask;
        }
    }
}
