using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MakersOfDenmark.Core;
using MakersOfDenmark.Core.Models.Events;
using MakersOfDenmark.Core.Services;

namespace MakersOfDenmark.Services
{
    public class EventService : IEventService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EventService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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

        public Task<bool> SignUpForEvent(Guid userId, int eventId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CancelEventSignUp(Guid userId, int eventId)
        {
            throw new NotImplementedException();
        }

        public Task<Event> UpdateEvent(Event eventToBeUpdated, Event updatedEvent)
        {
            throw new NotImplementedException();
        }
    }
}
