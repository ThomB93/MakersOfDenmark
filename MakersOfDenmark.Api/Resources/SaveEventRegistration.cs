using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakersOfDenmark.Api.Resources
{
    public class SaveEventRegistrationResource
    {
        public Guid UserId { get; set; }
        public int EventId { get; set; }
        public DateTime DateOfRegistration { get; set; }
    }
}
