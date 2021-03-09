using System;
using HRM.Core.DTO.HumanResource;
using HRM.Core.Entities;

namespace HRM.Core.Interfaces.Services
{
    public interface IHumanResourceService: IBaseService<HumanResource, Guid, CreateHumanResourceDTO, DeleteHumanResourceDTO, DetailsHumanResourceDTO, EditHumanResourceDTO, IndexHumanResourceDTO>
    {
    }
}