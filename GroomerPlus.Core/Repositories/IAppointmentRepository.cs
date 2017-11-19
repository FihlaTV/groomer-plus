// <copyright file="IAppointmentRepository.cs" company="GroomerPlus">
// Copyright (c) GroomerPlus. All rights reserved.
// </copyright>

namespace GroomerPlus.Core.Repositories
{
    using System.Threading.Tasks;
    using GroomerPlus.Core.Entities;

    /// <summary>
    /// Stores and allows retrieval of grooming appointments.
    /// </summary>
    public interface IAppointmentRepository
    {
        /// <summary>
        /// Creates the appointment.
        /// </summary>
        /// <param name="appointment">The appointment.</param>
        /// <returns>A handle for the task of adding the appointment to the repository.</returns>
        Task AddAppointment(Appointment appointment);

        /// <summary>
        /// Gets the appointment.
        /// </summary>
        /// <param name="appointmentId">The appointment identifier.</param>
        /// <returns>The appointment with the specified identifier.</returns>
        Task<Appointment> GetAppointment(int appointmentId);
    }
}
