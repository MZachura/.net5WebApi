using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using xkomZadanie.Entities;

namespace xkomZadanie.Repositories
{
    public interface IEvents
    {
        Task<Event> GetEventAsync(Guid id);

        Task<IEnumerable<Event>> GetEventsAsync();

        Task CreateEventAsync(Event events);

        Task UpdateEventAsync(Event events);

        Task DeleteEventAsync(Guid id);

        Task InsertUserIntoEventAsync(Event events);
        
    }
}