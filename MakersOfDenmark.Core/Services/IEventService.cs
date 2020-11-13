using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MakersOfDenmark.Core.Models.Events;

namespace MakersOfDenmark.Core.Services
{
    public interface IEventService
    {
        Task<Event> CreateEvent(Event newEvent);
        Task<Event> DeleteEvent(Event eventToDelete);
        Task<bool> SignUpForEvent(Guid userId, int eventId);
        Task<bool> CancelEventSignUp(Guid userId, int eventId);
        Task<Event> UpdateEvent(Event eventToBeUpdated, Event updatedEvent);
    }
}
