using System;
using HRM.Core.Enums;

namespace HRM.Core.Entities
{
    public class HumanResource : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public Guid DepartmentId { get; set; }

        public Department Department { get; set; }

        public HumanResourceStatus Status { get; set; }

        public string EmployeeNumber { get; set; }
    }
}