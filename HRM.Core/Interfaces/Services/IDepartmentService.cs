using System;
using HRM.Core.DTO.Department;
using HRM.Core.Entities;

namespace HRM.Core.Interfaces.Services
{
    public interface IDepartmentService : IBaseService<Department, Guid, CreateDepartmentDTO, DeleteDepartmentDTO, DetailsDepartmentDTO, EditDepartmentDTO, IndexDepartmentDTO>
    {
    }
}