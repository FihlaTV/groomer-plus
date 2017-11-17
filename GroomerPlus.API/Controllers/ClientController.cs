using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GroomerPlus.API.Commands;
using MediatR;
using GroomerPlus.Core.Entities;
using Microsoft.Extensions.Logging;

namespace GroomerPlus.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Client")]
    public class ClientController : Controller
    {
        private readonly ILogger<ClientController> logger;

        private readonly IMediator mediator;

        public ClientController(ILogger<ClientController> logger, IMediator mediator)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        public async Task<IActionResult> CreateClient([FromBody] CreateClientCommand command)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            try
            {
                Client client = await this.mediator.Send(command);

                // Once we implement the get client functionality, we can update the link here.
                return this.Created(string.Empty, client);
            }
            catch (Exception e)
            {
                this.logger.LogError(e, "The client could not be created due to an unexpected error.");
                return this.StatusCode(500);
            }
        }
    }
}