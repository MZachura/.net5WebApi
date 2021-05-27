using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using xkomZadanie.Entities;

namespace xkomZadanie.Repositories
{
    public class MongoDbEventsRepository : IEvents
    {
        private const string databaseName = "catalog";
        private const string collectionName = "events";

        private readonly IMongoCollection<Event> eventCollection;
        private readonly FilterDefinitionBuilder<Event> filterBuilder = Builders<Event>.Filter;

        public MongoDbEventsRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            eventCollection = database.GetCollection<Event>(collectionName);
        }

        public async Task CreateEventAsync(Event events)
        {
            await eventCollection.InsertOneAsync(events);
        }
        
        public async Task DeleteEventAsync(Guid id)
        {

            var filter = filterBuilder.Eq(events => events.Id, id);
            await eventCollection.DeleteOneAsync(filter);

        }

        public async Task<Event> GetEventAsync(Guid id)
        {
            var filter = filterBuilder.Eq(events => events.Id, id);
            return await eventCollection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Event>> GetEventsAsync()
        {
            //return await eventCollection.Find(new BsonDocument()).ToListAsync();
            return await eventCollection.Find(_ => true).Project(b => new Event
            {
                Id = b.Id,
                Name = b.Name,
                CreatedDate = b.CreatedDate
            }).ToListAsync();
        }

        public async Task UpdateEventAsync(Event events)
        {
            var filter = filterBuilder.Eq(existingEvent => existingEvent.Id, events.Id);
            await eventCollection.ReplaceOneAsync(filter, events);
        }

        public async Task InsertUserIntoEventAsync(Event events)
        {
            var filter = filterBuilder.Eq(existingEvent => existingEvent.Id, events.Id);
            
            await eventCollection.ReplaceOneAsync(filter, events);
        }

        
    }

    
}

    

