using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using xkomZadanie.Dtos;
using xkomZadanie.Entities;
using xkomZadanie.Repositories;



namespace xkomZadanie.Controllers
{
    [ApiController]
    [Route("events")]
    public class EventController : ControllerBase
    {
        private readonly IEvents repository;
       
        

        public EventController(IEvents repository)
        {
            this.repository = repository;

        }
        //GET /events

        [HttpGet]
        public async Task<IEnumerable<EventDto>> GetEventsAsync()
        {
            var meeting = (await repository.GetEventsAsync())
                                         .Select(events => events.AsDto());
            return meeting;
        }
        //GET /events/{name}

        [HttpGet("{id}")]

        public async Task<ActionResult<EventDto>> GetEventAsync(Guid id)
        {
            var events = await repository.GetEventAsync(id);
            if (events is null)
            {
                return NotFound();
            }
            return events.AsDto();
        }

        //POST /events
        [HttpPost]
        public async Task<ActionResult<EventDto>> CreateEventAsync(CreateEventDto eventDto)
        {
            Event events = new()
            {
                Id = Guid.NewGuid(),
                Name = eventDto.Name,
                CreatedDate = DateTimeOffset.UtcNow,
                Users = new Dictionary<string, string>()

            };
            await repository.CreateEventAsync(events);

            return CreatedAtAction(nameof(GetEventAsync), new { id = events.Id }, events.AsDto());
        }

        //PUT /events/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEventAsync(Guid id, UpdateEventDto eventDto)
        {
            var existingEvent = await repository.GetEventAsync(id);

            if (existingEvent is null)
            {
                return NotFound();
            }
            Event updatedEvent = existingEvent with
            {
                Name = eventDto.Name
            };

            await repository.UpdateEventAsync(updatedEvent);
            return NoContent();
        }

        //PUT /events/{id}
        [HttpPut("user/{id}")]
        public async Task<ActionResult> InsertUserIntoEventAsync(Guid id, InsertUserIntoEventDto userDto)
        {
            var existingEvent = await repository.GetEventAsync(id);

            if (existingEvent is null)
            {
                return NotFound();
            }
            string key = userDto.Name.ToString();
            string val = userDto.Email.ToString();
            Dictionary<string, string> dict = existingEvent.Users;
                if (existingEvent.Users.Count < 25)
                {
                    dict.Add(key, val);
                    Event userInserted = existingEvent with
                    {
                        Users = dict
                    };
                    await repository.InsertUserIntoEventAsync(userInserted);
                    return NoContent();
                }
            return StatusCode(405);
            
        }



        //DELETE /events/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEventAsync(Guid id)
        {
            var existingEvent =  await repository.GetEventAsync(id);
            if (existingEvent is null)
            {
               return NotFound();
            }
             await repository.DeleteEventAsync(id);
            return NoContent();
        }

    }
}