using System;
using System.Collections.Generic;
using System.Text;

namespace GroomerPlus.Core.Entities
{
    public class Appointment
    {
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        public int PetId { get; set; }
    }
}
