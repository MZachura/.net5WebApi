using System;
using xkomZadanie.Dtos;
using xkomZadanie.Entities;

namespace xkomZadanie
{
    public static class Extensions
    {
        public static EventDto AsDto(this Event events)
        {
            return new EventDto
            {
                Id= events.Id,
                Name = events.Name,
                Users = events.Users,
                CreatedDate = events.CreatedDate
            };
        }
    }
}
