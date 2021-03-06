﻿namespace MakersOfDenmark.Api.Resources
{
    public class AddressResource
    {
        public int? Id { get; set; }
        public string? StreetName { get; set; }

        public string? StreetNumber { get; set; }

        public string? City { get; set; }

        public string? Zipcode { get; set; }

        public string? CountryCode { get; set; }
    }
}