using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MakersOfDenmark.Api.Resources;
using MakersOfDenmark.Core;
using MakersOfDenmark.Core.Models.Events;
using MakersOfDenmark.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace MakersOfDenmark.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public EventController(IEventService eventService, IMapper mapper)
        {
            _eventService = eventService;
            _mapper = mapper;
        }

        //TODO: Create event
        
        //TODO: Get event
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<EventResource>>> GetEvents()
        {
            var events = await _unitOfWork.Events.GetAllAsync();
            var eventResources = _mapper.Map<IEnumerable<Event>, IEnumerable<EventResource>>(events);

            return Ok(eventResources);
        }
        
        //TODO: Get specific event
        
        //TODO: Delete event
        
        //TODO: Sign Up For Event
        
        //TODO: Cancel Event Sign Up
        
        //TODO: Update Event

        //TODO: Add get upcoming Events
        
        //TODO: Add get signedUp upcoming Events

        //TODO: Get previous events

        //TODO: Get previously attended events
    }
}
