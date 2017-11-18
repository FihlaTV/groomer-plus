using System.Collections.Generic;
using System.Threading.Tasks;
using GroomerPlus.Core.Entities;

namespace GroomerPlus.Core.Repositories
{
    public interface IPetRepository
    {
        Task AddPet(Pet pet);

        Task<Pet> GetPet(int petId);

        Task<IEnumerable<Pet>> GetPetsByClient(int clientId);
        Task<IEnumerable<Pet>> GetAllPets();
    }
}
