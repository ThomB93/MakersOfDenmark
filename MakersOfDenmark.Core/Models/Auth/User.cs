using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace MakersOfDenmark.Core.Models.Auth
{
    public class User : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        public Address Address { get; set; }
        [ForeignKey("Address")]
        public int AddressId { get; set; }
    }
}