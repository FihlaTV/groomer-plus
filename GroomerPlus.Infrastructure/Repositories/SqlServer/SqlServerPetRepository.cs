// <copyright file="SqlServerPetRepository.cs" company="GroomerPlus">
// Copyright (c) GroomerPlus. All rights reserved.
// </copyright>

namespace GroomerPlus.Infrastructure.Repositories.SqlServer
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using GroomerPlus.Core.Entities;
    using GroomerPlus.Core.Repositories;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// An implementation of the pet repository that uses SQL server to store pets.
    /// </summary>
    /// <seealso cref="GroomerPlus.Core.Repositories.IPetRepository" />
    public class SqlServerPetRepository : IPetRepository
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly GroomingContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlServerPetRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public SqlServerPetRepository(GroomingContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Adds the pet.
        /// </summary>
        /// <param name="pet">The pet.</param>
        /// <returns>
        /// A handle for the task of adding the pet to the repository
        /// </returns>
        public async Task AddPet(Pet pet)
        {
            await this.context.Pets.AddAsync(pet);
            await this.context.SaveChangesAsync();
        }

        /// <summary>
        /// Gets the pet.
        /// </summary>
        /// <param name="petId">The pet identifier.</param>
        /// <returns>
        /// The pet with the specified identifier.
        /// </returns>
        public async Task<Pet> GetPet(int petId)
        {
            return await this.context.Pets
                .AsNoTracking()
                .SingleOrDefaultAsync(p => p.Id == petId);
        }

        /// <summary>
        /// Gets the pets by client.
        /// </summary>
        /// <param name="clientId">The client identifier.</param>
        /// <returns>
        /// The collection of pets owned by the client with the specified identifier.
        /// </returns>
        public async Task<IEnumerable<Pet>> GetPetsByClient(int clientId)
        {
            return await this.context.Pets
                .AsNoTracking()
                .Where(p => p.ClientId == clientId)
                .ToListAsync();
        }

        /// <summary>
        /// Gets all pets.
        /// </summary>
        /// <returns>
        /// The collection of all pets.
        /// </returns>
        public async Task<IEnumerable<Pet>> GetAllPets()
        {
            return await this.context.Pets.AsNoTracking().ToListAsync();
        }
    }
}
