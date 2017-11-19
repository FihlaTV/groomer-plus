// <copyright file="PetController.cs" company="GroomerPlus">
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
    /// Handles all pet related requests.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Produces("application/json")]
    public class PetController : Controller
    {
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<PetController> logger;

        /// <summary>
        /// The pet repository
        /// </summary>
        private readonly IPetRepository petRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="PetController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="petRepository">The pet repository.</param>
        /// <exception cref="System.ArgumentNullException">
        /// logger
        /// or
        /// petRepository
        /// </exception>
        public PetController(ILogger<PetController> logger, IPetRepository petRepository)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.petRepository = petRepository ?? throw new ArgumentNullException(nameof(petRepository));
        }

        /// <summary>
        /// Gets the pet.
        /// </summary>
        /// <param name="petId">The pet identifier.</param>
        /// <returns>The result.</returns>
        [HttpGet]
        [Route("api/Pet/{petId}")]
        public async Task<IActionResult> GetPet(int petId)
        {
            Pet pet = await this.petRepository.GetPet(petId);

            if (pet == null)
            {
                return this.NotFound();
            }

            return this.Ok(pet);
        }

        /// <summary>
        /// Gets the pets.
        /// </summary>
        /// <returns>The result.</returns>
        [HttpGet]
        [Route("api/pet")]
        public async Task<IActionResult> GetPets()
        {
            IEnumerable<Pet> pets = await this.petRepository.GetAllPets();

            return this.Ok(pets);
        }

        /// <summary>
        /// Gets the pets by client.
        /// </summary>
        /// <param name="clientId">The client identifier.</param>
        /// <returns>The result.</returns>
        [HttpGet]
        [Route("api/Client/{clientId}/Pet")]
        public async Task<IActionResult> GetPetsByClient(int clientId)
        {
            IEnumerable<Pet> pets = await this.petRepository.GetPetsByClient(clientId);

            return this.Ok(pets);
        }

        /// <summary>
        /// Creates the pet.
        /// </summary>
        /// <param name="clientId">The client identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns>The result.</returns>
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