using System;
using MakersOfDenmark.Core.Models.Auth;

namespace MakersOfDenmark.Core.Models.Makerspaces
{
    public class MakerspaceUser
    {
        public Guid UserId { get; set; }
        public User User { get; set; }

        public int MakerspaceId { get; set; }
        public Makerspace Makerspaces { get; set; }
    }
}