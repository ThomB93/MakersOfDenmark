﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakersOfDenmark.Api.Resources
{
    public class EventRegistrationResource
    {
        public UserResource User { get; set; }
        public EventResource Event { get; set; }
    }
}
