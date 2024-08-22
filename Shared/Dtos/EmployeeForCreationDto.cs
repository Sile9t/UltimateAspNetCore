using System.ComponentModel.DataAnnotations;

namespace Shared.Dtos
{
    public record EmployeeForCreationDto
    {
        [Required(ErrorMessage = "Employee name is required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
        public string Name { get; init; }
        [Required(ErrorMessage = "Age is required field.")]
        public int Age { get; init; }
        [Required(ErrorMessage = "Position is required field.")]
        [MaxLength(20, ErrorMessage = "Maximum lenght for the Positio is 20 characters.")]
        public string Position { get; init; }
    }
}
