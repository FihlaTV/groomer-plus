// <copyright file="AppointmentController.cs" company="GroomerPlus">
// Copyright (c) GroomerPlus. All rights reserved.
// </copyright>

namespace GroomerPlus.API.Controllers
{
    using System;
    using System.Threading.Tasks;
    using GroomerPlus.API.Requests;
    using GroomerPlus.Core.Entities;
    using GroomerPlus.Core.Repositories;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Handles all appointment related requests.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Produces("application/json")]
    [Route("api/Appointment")]
    public class AppointmentController : Controller
    {
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<AppointmentController> logger;

        /// <summary>
        /// The repository
        /// </summary>
        private readonly IAppointmentRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="AppointmentController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="repository">The repository.</param>
        public AppointmentController(ILogger<AppointmentController> logger, IAppointmentRepository repository)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        /// <summary>
        /// Gets the appointment.
        /// </summary>
        /// <param name="appointmentId">The appointment identifier.</param>
        /// <returns>The result.</returns>
        [HttpGet]
        [Route("{appointmentId}")]
        public async Task<IActionResult> GetAppointment(int appointmentId)
        {
            Appointment appointment = await this.repository.GetAppointment(appointmentId);

            if (appointment == null)
            {
                return this.NotFound();
            }

            return this.Ok(appointment);
        }

        /// <summary>
        /// Creates the appointment.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The result.</returns>
        [HttpPost]
        public async Task<IActionResult> CreateAppointment([FromBody]CreateAppointmentRequest request)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            try
            {
                Appointment appointment = new Appointment
                {
                    DateTime = request.DateTime,
                    PetId = request.PetId
                };

                await this.repository.AddAppointment(appointment);

                return this.CreatedAtAction("GetAppointment", new { appointmentId = appointment.Id }, appointment);
            }
            catch (Exception e)
            {
                this.logger.LogError(e, "The appointment could not be created due to an unexpected error.");
                return this.StatusCode(500);
            }
        }
    }
}