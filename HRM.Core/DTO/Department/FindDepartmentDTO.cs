using System;

namespace HRM.Core.DTO.Department
{
    public class FindDepartmentDTO: CreateDepartmentDTO
    {
        public Guid Id { get; set; }
    }
}