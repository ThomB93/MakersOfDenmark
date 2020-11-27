using System.Collections.Generic;
using MakersOfDenmark.Core.Models.Auth;
using MakersOfDenmark.Core.Models.Makerspaces;

namespace MakersOfDenmark.Core.Models
{
    public class Address
    {
        public int Id { get; set; }

        public string StreetName { get; set; }

        public string StreetNumber { get; set; }

        public string City { get; set; }

        public string Zipcode { get; set; }

        public string CountryCode { get; set; }

        public IList<User> Users { get; set; }

        public IList<Makerspace> Makerspaces { get; set; }
        //TODO: Add properties  for user collection
    }
}