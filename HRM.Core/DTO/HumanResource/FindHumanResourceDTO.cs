using System;

namespace HRM.Core.DTO.HumanResource
{
    public class FindHumanResourceDTO: CreateHumanResourceDTO
    {
        public Guid Id { get; set; }
    }
}