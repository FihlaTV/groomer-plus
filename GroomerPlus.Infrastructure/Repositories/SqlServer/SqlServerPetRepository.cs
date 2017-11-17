using System.Threading.Tasks;
using GroomerPlus.Core.Entities;
using GroomerPlus.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GroomerPlus.Infrastructure.Repositories.SqlServer
{
    public class SqlServerPetRepository : IPetRepository
    {
        private readonly GroomingContext context;

        public SqlServerPetRepository(GroomingContext context)
        {
            this.context = context;
        }

        public async Task AddPet(Pet pet)
        {
            await this.context.Pets.AddAsync(pet);
            await this.context.SaveChangesAsync();
        }

        public async Task<Pet> GetPet(int petId)
        {
            return await this.context.Pets.SingleOrDefaultAsync(p => p.Id == petId);
        }
    }
}
