using System;
using System.Threading.Tasks;
using GroomerPlus.API.Requests;
using Microsoft.AspNetCore.Mvc;
using GroomerPlus.Core.Entities;
using GroomerPlus.Core.Repositories;
using Microsoft.Extensions.Logging;

namespace GroomerPlus.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Client")]
    public class ClientController : Controller
    {
        private readonly ILogger<ClientController> logger;

        private readonly IClientRepository clientRepository;

        public ClientController(ILogger<ClientController> logger, IClientRepository clientRepository)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.clientRepository = clientRepository ?? throw new ArgumentNullException(nameof(clientRepository));
        }

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