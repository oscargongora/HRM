using System;
using System.ComponentModel.DataAnnotations;
using HRM.Core.DTO.Department;
using HRM.Core.Enums;
using HRM.Core.Helpers;

namespace HRM.Core.DTO.HumanResource
{
    public class CreateHumanResourceDTO
    {
        [Required]
        [MaxLength(ConstantsHelper.SM_STRING_LENGTH)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        
        [Required]
        [MaxLength(ConstantsHelper.SM_STRING_LENGTH)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        
        [Required]
        [MaxLength(ConstantsHelper.LG_STRING_LENGTH)]
        public string Email { get; set; }
        
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime? DateOfBirth { get; set; }
        
        [Required]
        [Display(Name = "Department")]
        public Guid DepartmentId { get; set; }

        public IndexDepartmentDTO Department { get; set; }
        
        [Required]
        public HumanResourceStatus Status { get; set; }
        
        [Required]
        [MaxLength(ConstantsHelper.SM_STRING_LENGTH)]
        [Display(Name = "Employee Number")]
        public string EmployeeNumber { get; set; }
    }
}