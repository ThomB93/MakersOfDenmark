using System;
using System.Collections.Generic;
using MakersOfDenmark.Core.Models.Events;
using MakersOfDenmark.Core.Models.Makerspaces;
using MakersOfDenmark.Core.Models.UserRelations;
using Microsoft.AspNetCore.Identity;

namespace MakersOfDenmark.Core.Models.Auth
{
    public class User : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public IList<UserBadge> UserBadges { get; set; }
        public IList<MakerspaceUser> MakerspacesJoined { get; set; }
        public IList<EventRegistration> EventsRegisteredFor { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }
    }
}