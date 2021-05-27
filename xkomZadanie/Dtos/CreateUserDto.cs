using System;
using System.ComponentModel.DataAnnotations;

namespace xkomZadanie.Dtos
{
    public class CreateUserDto
    {
   
        [Required]
        public string Name{ get; init; }
        [Required]   
        public string Email { get; init; }
    }
}
