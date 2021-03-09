using System.ComponentModel.DataAnnotations;
using HRM.Core.Helpers;

namespace HRM.Core.DTO.Department
{
    public class CreateDepartmentDTO
    {
        [Required]
        [MaxLength(ConstantsHelper.SM_STRING_LENGTH)]
        public string Name { get; set; }
    }
}