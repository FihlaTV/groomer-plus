using System.ComponentModel.DataAnnotations;

namespace GroomerPlus.API.Requests
{
    public class CreateClientRequest
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