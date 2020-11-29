using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MakersOfDenmark.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace MakersOfDenmark.Api.Controllers
{
    /// <summary>Contains REST endpoints for interacting with the Events domain.</summary>
    [ApiController]
    [Route("[controller]")]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;
        private readonly IMapper _mapper;

        public EventController(IEventService eventService, IMapper mapper)
        {
            _eventService = eventService;
            _mapper = mapper;
        }

        //TODO: Add get upcoming Events

        //TODO: Add get signedUp upcoming Events

        //TODO: Get previous events

        //TODO: Get previously attended events
    }
}
