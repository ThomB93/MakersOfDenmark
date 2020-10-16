using System;
using Microsoft.AspNetCore.Identity;

namespace MakersOfDenmark.Core.Models.Auth
{
    public class User : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }

    }
}