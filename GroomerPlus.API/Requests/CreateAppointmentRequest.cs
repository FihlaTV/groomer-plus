using System;

namespace GroomerPlus.API.Requests
{
    public class CreateAppointmentRequest
    {
        public DateTime DateTime { get; set; }
        public int PetId { get; set; }
    }
}