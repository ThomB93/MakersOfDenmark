using System;
using System.Collections;
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

        public EventController(IEventService eventService, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _eventService = eventService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        
        [HttpPost("")]
        public async Task<ActionResult<Event>> CreateEvent([FromBody] SaveEventResource saveEventResource)
        {
            var eventToCreate = _mapper.Map<SaveEventResource, Event>(saveEventResource);
            var newEvent = await _eventService.CreateEvent(eventToCreate);
            var eventCreated = await _eventService.GetEvent(newEvent.Id);
            var eventResource = _mapper.Map<Event, EventResource>(eventCreated);

            return Ok(eventResource);
        }
        
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<EventResource>>> GetEvents()
        {
            var events = await _eventService.GetEvents();
            var eventResources = _mapper.Map<IEnumerable<Event>, IEnumerable<EventResource>>(events);
            return Ok(eventResources);
        }
        
        [HttpGet("getHistoricEvents")]
        public ActionResult<IEnumerable<EventResource>> GetHistoricEvents()
        {
            var events = _eventService.HistoricEvents();
            var eventResources = _mapper.Map<IEnumerable<Event>, IEnumerable<EventResource>>(events);
            return Ok(eventResources);
        }
        
        [HttpGet("{eventId}")]
        public async Task<ActionResult<EventResource>> GetEvent(int eventId)
        {
            var eventFound = await _eventService.GetEvent(eventId);
            var eventResource = _mapper.Map<Event, EventResource>(eventFound);
            return Ok(eventResource);
        }
        
        //TODO: Delete event
        
        //TODO: Sign Up For Event
        
        //TODO: Cancel Event Sign Up
        
        [HttpPut("{id}")]
        public async Task<ActionResult<Event>> UpdateEvent(int id,
            [FromBody] SaveEventResource saveEventResource)
        {

            var eventToBeUpdated = await _eventService.GetEvent(id);

            if (eventToBeUpdated == null)
            {
                return NotFound();
            }
            
            var eventFound = _mapper.Map<SaveEventResource, Event>(saveEventResource);

            await _eventService.UpdateEvent(eventToBeUpdated, eventFound);

            var updatedEvent = await _eventService.GetEvent(id);
            var updatedEventResource = _mapper.Map<Event, SaveEventResource>(updatedEvent);
            
            return Ok(updatedEventResource);
        }

        //TODO: Add get upcoming Events
        
        //TODO: Add get signedUp upcoming Events
        
        
        
        //TODO: Get previously attended events
    }
}
