using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GroomerPlus.Core.Entities;

namespace GroomerPlus.Core.Repositories
{
    public interface IAppointmentRepository
    {
        Task CreateAppointment(Appointment appointment);
        Task<Appointment> GetAppointment(int appointmentId);
    }
}
