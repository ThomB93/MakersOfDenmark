﻿using System;

namespace MakersOfDenmark.Api.Resources
{
    public class MakerspaceResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Space_Type { get; set; }
        public string Access_Type { get; set; }
        public string CVR { get; set; }
        public string Logo_Url { get; set; }
        public UserResource User { get; set; }
    }
}