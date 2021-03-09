using HRM.Core.DTO.Department;
using AutoMapper;
using HRM.Core.DTO.HumanResource;
using HRM.Core.Entities;

namespace HRM.UI.MapperConfig
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            #region Department
            CreateMap<Department, CreateDepartmentDTO>().ReverseMap();
            CreateMap<Department, DeleteDepartmentDTO>().ReverseMap();
            CreateMap<Department, DetailsDepartmentDTO>().ReverseMap();
            CreateMap<Department, EditDepartmentDTO>().ReverseMap();
            CreateMap<Department, IndexDepartmentDTO>().ReverseMap();
            #endregion
            
            #region HumanResource
            CreateMap<HumanResource, CreateHumanResourceDTO>().ReverseMap();
            CreateMap<HumanResource, DeleteHumanResourceDTO>().ReverseMap();
            CreateMap<HumanResource, DetailsHumanResourceDTO>().ReverseMap();
            CreateMap<HumanResource, EditHumanResourceDTO>().ReverseMap();
            CreateMap<HumanResource, IndexHumanResourceDTO>().ReverseMap();
            #endregion
        }
    }
}
