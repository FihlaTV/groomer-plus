using System.Threading.Tasks;
using GroomerPlus.API.Commands;
using GroomerPlus.Core.Entities;
using GroomerPlus.Core.Repositories;
using MediatR;

namespace GroomerPlus.API.CommandHandlers
{
    public class CreateClientCommandHandler : IAsyncRequestHandler<CreateClientCommand, Client>
    {
        private readonly IClientRepository repository;

        public CreateClientCommandHandler(IClientRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Client> Handle(CreateClientCommand message)
        {
            Client client = new Client
            {
                FirstName = message.FirstName,
                LastName = message.LastName,
                EmailAddress = message.Email,
                PhoneNumber = message.Phone
            };

            await this.repository.AddClient(client);

            return client;
        }
    }
}
