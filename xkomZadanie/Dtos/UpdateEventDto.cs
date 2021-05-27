using System.ComponentModel.DataAnnotations;

namespace xkomZadanie.Dtos
{
    public class UpdateEventDto
    {
        [Required]
        public string Name { get; init; }
        
    }
}