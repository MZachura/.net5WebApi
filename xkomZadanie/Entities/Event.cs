using System;
using System.Collections.Generic;

namespace xkomZadanie.Entities
{
    public record Event
    {
        public Guid Id { get; init; }

        public string Name { get; init; }

        public DateTimeOffset CreatedDate { get; init; }

        public Dictionary<string, string> Users{get;init;}

    }
}