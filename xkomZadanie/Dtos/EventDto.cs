using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace xkomZadanie.Dtos
{
    public record EventDto
    {
        public Guid Id { get; init; }

        public string Name { get; init; }

        public Dictionary<string, string> Users { get; init; }

        public DateTimeOffset CreatedDate { get; init; }
    }
}