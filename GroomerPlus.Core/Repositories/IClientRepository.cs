// <copyright file="IClientRepository.cs" company="GroomerPlus">
// Copyright (c) GroomerPlus. All rights reserved.
// </copyright>

namespace GroomerPlus.Core.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using GroomerPlus.Core.Entities;

    /// <summary>
    /// Stores and provides retrieval for grooming clients.
    /// </summary>
    public interface IClientRepository
    {
        /// <summary>
        /// Adds the client.
        /// </summary>
        /// <param name="client">The client.</param>
        /// <returns>A handle for the task of adding the client to the repository</returns>
        Task AddClient(Client client);

        /// <summary>
        /// Gets the client by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The client with the specified identifier.</returns>
        Task<Client> GetClientById(int id);

        /// <summary>
        /// Gets all clients.
        /// </summary>
        /// <returns>A collection of all clients.</returns>
        Task<IEnumerable<Client>> GetAllClients();
    }
}
