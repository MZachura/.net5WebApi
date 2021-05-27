using System.ComponentModel.DataAnnotations;

namespace xkomZadanie.Dtos
{
    public class CreateEventDto
    {
        [Required]
        public string Name { get; init; }

    }
}