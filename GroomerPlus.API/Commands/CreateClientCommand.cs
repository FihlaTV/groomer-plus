using System.ComponentModel.DataAnnotations;
using GroomerPlus.Core;
using GroomerPlus.Core.Entities;
using MediatR;

namespace GroomerPlus.API.Commands
{
    public class CreateClientCommand : IRequest<Client>
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Phone { get; set; }
    }
}