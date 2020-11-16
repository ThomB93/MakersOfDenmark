using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakersOfDenmark.Api.Resources
{
    public class SaveAddressResource
    {
        public string StreetName { get; set; }

        public string StreetNumber { get; set; }

        public string City { get; set; }

        public string Zipcode { get; set; }

        public string CountryCode { get; set; }
    }
}
