// <copyright file="CreateAppointmentRequest.cs" company="GroomerPlus">
// Copyright (c) GroomerPlus. All rights reserved.
// </copyright>

namespace GroomerPlus.API.Requests
{
    using System;

    /// <summary>
    /// A request for creating a new appointment.
    /// </summary>
    public class CreateAppointmentRequest
    {
        /// <summary>
        /// Gets or sets the date time.
        /// </summary>
        /// <value>
        /// The date time.
        /// </value>
        public DateTime DateTime { get; set; }

        /// <summary>
        /// Gets or sets the pet identifier.
        /// </summary>
        /// <value>
        /// The pet identifier.
        /// </value>
        public int PetId { get; set; }
    }
}