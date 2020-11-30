using System;

namespace MakersOfDenmark.Api.Resources
{
    public class SaveEventRegistrationResource
    {
        public Guid UserId { get; set; }
        public int EventId { get; set; }
        public DateTime DateOfRegistration { get; set; }
    }
}