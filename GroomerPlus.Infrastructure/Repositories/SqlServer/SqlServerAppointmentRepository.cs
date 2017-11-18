using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GroomerPlus.Core.Entities;
using GroomerPlus.Core.Repositories;

namespace GroomerPlus.Infrastructure.Repositories.SqlServer
{
    public class SqlServerAppointmentRepository : IAppointmentRepository
    {
        private readonly GroomingContext context;

        public SqlServerAppointmentRepository(GroomingContext context)
        {
            this.context = context;
        }

        public async Task CreateAppointment(Appointment appointment)
        {
            await this.context.Appointments.AddAsync(appointment);
            await this.context.SaveChangesAsync();
        }

        public async Task<Appointment> GetAppointment(int appointmentId)
        {
            return await this.context.Appointments.FindAsync(appointmentId);
        }
    }
}
