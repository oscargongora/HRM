using AutoMapper;
using System;
using ASI.Core.Services;
using HRM.Core.DTO.Department;
using HRM.Core.Entities;
using HRM.Core.Interfaces.Repositories;
using HRM.Core.Interfaces.Services;

namespace HRG.Core.Services
{
    public class DepartmentService :
        BaseService<Department, Guid, CreateDepartmentDTO, DeleteDepartmentDTO, DetailsDepartmentDTO, EditDepartmentDTO, IndexDepartmentDTO>
        , IDepartmentService
    {

        public DepartmentService(IMapper mapper, IUnitOfWork unitOfWork)
            : base(mapper, unitOfWork)
        {
        }
    }
}