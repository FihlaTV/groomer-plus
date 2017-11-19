// <copyright file="IPetRepository.cs" company="GroomerPlus">
// Copyright (c) GroomerPlus. All rights reserved.
// </copyright>

namespace GroomerPlus.Core.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using GroomerPlus.Core.Entities;

    /// <summary>
    /// Stores and provides retrieval of pets that require grooming.
    /// </summary>
    public interface IPetRepository
    {
        /// <summary>
        /// Adds the pet.
        /// </summary>
        /// <param name="pet">The pet.</param>
        /// <returns>A handle for the task of adding the pet to the repository</returns>
        Task AddPet(Pet pet);

        /// <summary>
        /// Gets the pet.
        /// </summary>
        /// <param name="petId">The pet identifier.</param>
        /// <returns>The pet with the specified identifier.</returns>
        Task<Pet> GetPet(int petId);

        /// <summary>
        /// Gets the pets by client.
        /// </summary>
        /// <param name="clientId">The client identifier.</param>
        /// <returns>The collection of pets owned by the client with the specified identifier.</returns>
        Task<IEnumerable<Pet>> GetPetsByClient(int clientId);

        /// <summary>
        /// Gets all pets.
        /// </summary>
        /// <returns>The collection of all pets.</returns>
        Task<IEnumerable<Pet>> GetAllPets();
    }
}
