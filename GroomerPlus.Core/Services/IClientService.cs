using System;
using System.Threading.Tasks;
using GroomerPlus.Core.Entities;
using GroomerPlus.Core.Repositories;

namespace GroomerPlus.Core.Services
{
    public interface IClientService
    {
        Task<Client> GetClientById(int id);
    }

    public class ClientService : IClientService
    {
        private readonly IClientRepository repository;

        public ClientService(IClientRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<Client> GetClientById(int id)
        {
            return await this.repository.GetClientById(id);
        }
    }
}
