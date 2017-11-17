using System.Collections.Generic;
using System.Threading.Tasks;
using GroomerPlus.Core.Entities;

namespace GroomerPlus.Core.Repositories
{
    public interface IClientRepository
    {
        Task AddClient(Client client);
        Task<Client> GetClientById(int id);
        Task<IEnumerable<Client>> GetAllClients();
    }
}
