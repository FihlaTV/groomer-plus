using System;

namespace GroomerPlus.Core.Entities
{
    public class Pet
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Breed { get; set; }

        public Gender Gender { get; set; }

        public string Comments { get; set; }

        public int ClientId { get; set; }
        
        public DateTime? DateOfBirth { get; set; }
    }
}