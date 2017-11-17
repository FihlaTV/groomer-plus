using System;
using System.ComponentModel.DataAnnotations;
using GroomerPlus.Core.Entities;

namespace GroomerPlus.API.Requests
{
    public class CreatePetRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Breed { get; set; }

        [EnumDataType(typeof(Gender))]
        public Gender Gender { get; set; }

        public string Comments { get; set; }

        public DateTime? DateOfBirth { get; set; }
    }
}