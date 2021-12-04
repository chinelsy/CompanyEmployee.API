using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CompanyEmployee.Entities.Models.DTOS
{
    public abstract class CompanyForManipulationDto
    {
        [Required(ErrorMessage = "Company name is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Company Address is a required field.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Company country is a required field.")]
        [MaxLength(20, ErrorMessage = "Maximum length for the country Name is 20 characters.")]
        public string Country { get; set; }

        public IEnumerable<EmployeeForCreationDto> Employees { get; set; }
    }
}
