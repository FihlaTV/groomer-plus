// <copyright file="Appointment.cs" company="GroomerPlus">
// Copyright (c) GroomerPlus. All rights reserved.
// </copyright>

namespace GroomerPlus.Core.Entities
{
    using System;

    /// <summary>
    /// Represents a grooming appointment.
    /// </summary>
    public class Appointment
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

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
