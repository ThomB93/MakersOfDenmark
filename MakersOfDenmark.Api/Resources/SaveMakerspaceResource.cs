﻿using System;
using MakersOfDenmark.Core.Models;

namespace MakersOfDenmark.Api.Resources
{
    public class SaveMakerspaceResource
    {
        public string Name { get; set; }
        public string Space_Type { get; set; }
        public string Access_Type { get; set; }
        public string CVR { get; set; }
        public string Logo_Url { get; set; }
        public string Description { get; set; }
        public string X_Coords { get; set; }
        public string Y_Coords { get; set; }
        public Guid OwnerId { get; set; }
        public AddressResource Address { get; set; }
    }
}