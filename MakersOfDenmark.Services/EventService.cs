using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MakersOfDenmark.Core;
using MakersOfDenmark.Core.Models.Auth;
using MakersOfDenmark.Core.Models.Events;
using MakersOfDenmark.Core.Services;
using Microsoft.AspNetCore.Identity;

namespace MakersOfDenmark.Services
{
    public class EventService : IEventService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;

        public EventService(IUnitOfWork unitOfWork, UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task<Event> CreateEvent(Event newEvent)
        {
            await _unitOfWork.Events.AddAsync(newEvent);
            await _unitOfWork.CommitAsync();

            return newEvent;
        }

        public async Task<Event> DeleteEvent(Event eventToDelete)
        {
            _unitOfWork.Events.Remove(eventToDelete);
            await _unitOfWork.CommitAsync();

            return eventToDelete;
        }

        public async Task<bool> SignUpForEvent(Guid userId, int eventId)
        {
            var eventFound = await _unitOfWork.Events.GetByIdAsync(eventId);
            var user = _userManager.Users.FirstOrDefault(u => u.Id == userId);

            eventFound.RegisteredUsers.Add(new EventRegistration
            {
                UserId = userId,
                User = user,
                EventId = eventId,
                Event = eventFound,
                DateOfRegistration = DateTime.Now,
                HasAttended = false
            });

            await _unitOfWork.CommitAsync();

            return user != null;
        }

        public async Task<bool> CancelEventSignUp(Guid userId, int eventId)
        {
            var eventFound = await _unitOfWork.Events.GetByIdAsync(eventId);

            var eventRegistrationFound = eventFound.RegisteredUsers.FirstOrDefault(u => u.UserId == userId);

            eventFound.RegisteredUsers.Remove(eventRegistrationFound);

            await _unitOfWork.CommitAsync();

            return eventRegistrationFound != null;
        }

        public async Task<Event> UpdateEvent(Event currentEvent, Event updatedEvent)
        {
            currentEvent.Deadline = updatedEvent.Deadline;
            currentEvent.Description = updatedEvent.Description;
            currentEvent.Name = updatedEvent.Name;
            currentEvent.EventBadges = updatedEvent.EventBadges;
            currentEvent.MakerspaceHost = updatedEvent.MakerspaceHost;
            currentEvent.EndDateTime = updatedEvent.EndDateTime;
            currentEvent.StartDateTime = updatedEvent.StartDateTime;

            await _unitOfWork.CommitAsync();

            return currentEvent;
        }
        
        public IEnumerable<Event> UpcomingEvents()
        {
            var eventsFound = _unitOfWork.Events.Find(e => e.StartDateTime > DateTime.Now);
            return eventsFound;
        }

        public async Task<IEnumerable<Event>> UpcomingEventsForUser(Guid userId)
        {
            var eventsFound = await _unitOfWork.Events.GetAllAsync();

            // inspiration found here: https://stackoverflow.com/questions/8403232/linq-how-to-query-list-within-list
            var eventRegistrationsFound =
                eventsFound.SelectMany(er => er.RegisteredUsers).Where(x => x.UserId == userId);

            return eventRegistrationsFound.Select(eventRegistration => eventRegistration.Event).ToList();
        }
        
        public IEnumerable<Event> HistoricEvents()
        {
            var eventsFound = _unitOfWork.Events.Find(e => e.StartDateTime < DateTime.Now);
            return eventsFound;
        }
        
        public async Task<IEnumerable<Event>> HistoricEventsUserAttended(Guid userId)
        {
            var eventsFound = await _unitOfWork.Events.GetAllAsync();

            // inspiration found here: https://stackoverflow.com/questions/8403232/linq-how-to-query-list-within-list
            var eventRegistrationsFound =
                eventsFound.SelectMany(er => er.RegisteredUsers).Where(x => x.UserId == userId && x.HasAttended);

            return eventRegistrationsFound.Select(eventRegistration => eventRegistration.Event).ToList();
        }
    }
}