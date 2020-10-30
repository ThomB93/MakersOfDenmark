using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using MakersOfDenmark.Core.Models.Makerspaces;
using MakersOfDenmark.Core.Models.UserRelations;
using Microsoft.AspNetCore.Identity;

namespace MakersOfDenmark.Core.Models.Auth
{
    public class User : IdentityUser<Guid>
    {
        public User()
        {
            MakerspacesJoined = new Collection<Makerspace>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        //TODO: Add configuration for address
        
        //public Address Address { get; set; }
        //[ForeignKey("Address")]
        //public int AddressId { get; set; }
        
        public ICollection<Makerspace> MakerspacesJoined { get; set; }
        
        public IList<UserBadge> UserBadges { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }
    }
}