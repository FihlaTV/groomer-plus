using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroomerPlus.API.Requests;
using GroomerPlus.Core.Entities;
using GroomerPlus.Core.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GroomerPlus.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Appointment")]
    public class AppointmentController : Controller
    {
        private readonly ILogger<AppointmentController> logger;

        private readonly IAppointmentRepository repository;

        public AppointmentController(ILogger<AppointmentController> logger, IAppointmentRepository repository)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

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

                await this.repository.CreateAppointment(appointment);

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