using System;

namespace HRM.Core.DTO.Department
{
    public class EditDepartmentDTO: CreateDepartmentDTO
    {
        public Guid Id { get; set; }
    }
}