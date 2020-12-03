using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MakersOfDenmark.Api.Resources;
using MakersOfDenmark.Core;
using MakersOfDenmark.Core.Models.Auth;
using MakersOfDenmark.Core.Models.Events;
using MakersOfDenmark.Core.Services;
using Microsoft.AspNetCore.Identity;
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
        private readonly IUnitOfWork _unitOfWork;
        private UserManager<User> _userManager;

        public EventController(IEventService eventService, IMapper mapper, IUnitOfWork unitOfWork,
            UserManager<User> userManager)
        {
            _eventService = eventService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
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

        [HttpGet("historic")]
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

        [HttpDelete("{eventId}")]
        public async Task<ActionResult> DeleteEvent(int eventId)
        {
            if (eventId == 0)
                return BadRequest();

            var eventToDelete = await _eventService.GetEvent(eventId);
            if (eventToDelete == null)
                return NotFound();

            await _eventService.DeleteEvent(eventToDelete);

            return NoContent();
        }


        [HttpPost("/SignUp/{eventId}/")]
        public async Task<ActionResult> SignUpToEvent(int eventId, [FromBody] Guid userId)
        {
            var eventSignUp = await _eventService.SignUpForEvent(userId, eventId);

            if (!eventSignUp) return BadRequest();

            return Ok();
        }


        [HttpPost("/cancel/signUp/{eventId}/")]
        public async Task<ActionResult> CancelSignUp(int eventId, [FromBody] Guid userId)
        {
            var eventCancelSignUp = await _eventService.CancelEventSignUp(userId, eventId);

            if (!eventCancelSignUp) return BadRequest();

            return Ok();
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<Event>> UpdateEvent(int id,
            [FromBody] SaveEventResource saveEventResource)
        {
            var eventToBeUpdated = await _eventService.GetEvent(id);

            if (eventToBeUpdated == null)
                return NotFound();


            var eventFound = _mapper.Map<SaveEventResource, Event>(saveEventResource);

            await _eventService.UpdateEvent(eventToBeUpdated, eventFound);

            var updatedEvent = await _eventService.GetEvent(id);
            var updatedEventResource = _mapper.Map<Event, SaveEventResource>(updatedEvent);

            return Ok(updatedEventResource);
        }


        [HttpGet("/upcoming")]
        public ActionResult<IEnumerable<Event>> UpcomingEvents()
        {
            var eventFound = _eventService.UpcomingEvents();
            var eventResource = _mapper.Map<IEnumerable<Event>, IEnumerable<EventResource>>(eventFound);
            return Ok(eventResource);
        }



        [HttpGet("/upcoming/{userId}")]
        public async Task<ActionResult<Event>> UpcomingEventsForuser(Guid userId)
        {
            var eventsFound = await _eventService.UpcomingEventsForUser(userId);
            var eventsFoundResources = _mapper.Map<IEnumerable<Event>, IEnumerable<EventResource>>(eventsFound);

            return Ok(eventsFoundResources);
        }



        [HttpGet("/historic/{userId}")]
        public async Task<ActionResult<Event>> HistoricEventsUserAttended(Guid userId)
        {
            var eventsFound = await _eventService.HistoricEventsUserAttended(userId);
            var eventsFoundResources = _mapper.Map<IEnumerable<Event>, IEnumerable<EventResource>>(eventsFound);

            return Ok(eventsFoundResources);
        }
    }
}