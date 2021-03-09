using System;
using ASI.Core.Services;
using AutoMapper;
using HRM.Core.DTO.HumanResource;
using HRM.Core.Entities;
using HRM.Core.Interfaces.Repositories;
using HRM.Core.Interfaces.Services;

namespace HRM.Core.Services
{
    public class HumanResourceService:
        BaseService<HumanResource, Guid, CreateHumanResourceDTO, DeleteHumanResourceDTO, DetailsHumanResourceDTO, EditHumanResourceDTO, IndexHumanResourceDTO>
        , IHumanResourceService
    {

        public HumanResourceService(IMapper mapper, IUnitOfWork unitOfWork)
            : base(mapper, unitOfWork)
        {
        }
    }
}