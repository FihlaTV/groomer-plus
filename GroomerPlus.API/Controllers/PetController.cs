using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GroomerPlus.API.Requests;
using GroomerPlus.Core.Entities;
using GroomerPlus.Core.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GroomerPlus.API.Controllers
{
    [Produces("application/json")]
    public class PetController : Controller
    {
        private readonly ILogger<PetController> logger;

        private readonly IPetRepository petRepository;

        public PetController(ILogger<PetController> logger, IPetRepository petRepository)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.petRepository = petRepository ?? throw new ArgumentNullException(nameof(petRepository));
        }

        [HttpGet]
        [Route("api/Pet/{petId}")]
        public async Task<IActionResult> GetPet(int petId)
        {
            Pet pet = await this.petRepository.GetPet(petId);

            if (pet == null)
            {
                return this.NotFound();
            }

            return Ok(pet);
        }

        [HttpGet]
        [Route("api/pet")]
        public async Task<IActionResult> GetPets()
        {
            IEnumerable<Pet> pets = await this.petRepository.GetAllPets();

            return this.Ok(pets);
        }

        [HttpGet]
        [Route("api/Client/{clientId}/Pet")]
        public async Task<IActionResult> GetPetsByClient(int clientId)
        {
            IEnumerable<Pet> pets = await this.petRepository.GetPetsByClient(clientId);

            return this.Ok(pets);
        }

        [HttpPost]
        [Route("api/Client/{clientId}/Pet")]
        public async Task<IActionResult> CreatePet(int clientId, [FromBody] CreatePetRequest request)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            try
            {
                Pet pet = new Pet
                {
                    Name = request.Name,
                    Breed = request.Breed,
                    Gender = request.Gender,
                    Comments = request.Comments,
                    ClientId = clientId,
                    DateOfBirth = request.DateOfBirth
                };

                await this.petRepository.AddPet(pet);

                return this.CreatedAtAction("GetPet", new { petId = pet.Id }, pet);
            }
            catch (Exception e)
            {
                this.logger.LogError(e, "Unable to create pet due to an unexpected error.");
                return this.StatusCode(500);
            }
        }
    }
}