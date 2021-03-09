using System;

namespace HRM.Core.DTO.Department
{
    public class DeleteDepartmentDTO : CreateDepartmentDTO
    {
        public Guid Id { get; set; }
    }
}