// <copyright file="SqlServerAppointmentRepository.cs" company="GroomerPlus">
// Copyright (c) GroomerPlus. All rights reserved.
// </copyright>

namespace GroomerPlus.Infrastructure.Repositories.SqlServer
{
    using System.Threading.Tasks;
    using GroomerPlus.Core.Entities;
    using GroomerPlus.Core.Repositories;

    /// <summary>
    /// An implementation of the appointment repository that uses SQL server to store appointments.
    /// </summary>
    /// <seealso cref="GroomerPlus.Core.Repositories.IAppointmentRepository" />
    public class SqlServerAppointmentRepository : IAppointmentRepository
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly GroomingContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlServerAppointmentRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public SqlServerAppointmentRepository(GroomingContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Creates the appointment.
        /// </summary>
        /// <param name="appointment">The appointment.</param>
        /// <returns>
        /// A handle for the task of adding the appointment to the repository.
        /// </returns>
        public async Task AddAppointment(Appointment appointment)
        {
            await this.context.Appointments.AddAsync(appointment);
            await this.context.SaveChangesAsync();
        }

        /// <summary>
        /// Gets the appointment.
        /// </summary>
        /// <param name="appointmentId">The appointment identifier.</param>
        /// <returns>
        /// The appointment with the specified identifier.
        /// </returns>
        public async Task<Appointment> GetAppointment(int appointmentId)
        {
            return await this.context.Appointments.FindAsync(appointmentId);
        }
    }
}
