// <copyright file="ClientController.cs" company="GroomerPlus">
// Copyright (c) GroomerPlus. All rights reserved.
// </copyright>

namespace GroomerPlus.API.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using GroomerPlus.API.Requests;
    using GroomerPlus.Core.Entities;
    using GroomerPlus.Core.Repositories;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Handles all client related requests.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Produces("application/json")]
    [Route("api/Client")]
    public class ClientController : Controller
    {
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<ClientController> logger;

        /// <summary>
        /// The client repository
        /// </summary>
        private readonly IClientRepository clientRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="clientRepository">The client repository.</param>
        /// <exception cref="System.ArgumentNullException">
        /// logger
        /// or
        /// clientRepository
        /// </exception>
        public ClientController(ILogger<ClientController> logger, IClientRepository clientRepository)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.clientRepository = clientRepository ?? throw new ArgumentNullException(nameof(clientRepository));
        }

        /// <summary>
        /// Gets all clients.
        /// </summary>
        /// <returns>The result.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllClients()
        {
            IEnumerable<Client> clients = await this.clientRepository.GetAllClients();

            return this.Ok(clients);
        }

        /// <summary>
        /// Gets the client.
        /// </summary>
        /// <param name="clientId">The client identifier.</param>
        /// <returns>The result.</returns>
        [HttpGet("{clientId}")]
        public async Task<IActionResult> GetClient(int clientId)
        {
            if (clientId <= 0)
            {
                return this.BadRequest();
            }

            Client client = await this.clientRepository.GetClientById(clientId);

            if (client == null)
            {
                return this.NotFound();
            }

            return this.Ok(client);
        }

        /// <summary>
        /// Creates the client.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The result.</returns>
        [HttpPost]
        public async Task<IActionResult> CreateClient([FromBody] CreateClientRequest request)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            try
            {
                Client client = new Client
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    EmailAddress = request.Email,
                    PhoneNumber = request.Phone
                };

                await this.clientRepository.AddClient(client);

                return this.CreatedAtAction("GetClient", new { clientId = client.Id }, client);
            }
            catch (Exception e)
            {
                this.logger.LogError(e, "The client could not be created due to an unexpected error.");
                return this.StatusCode(500);
            }
        }
    }
}