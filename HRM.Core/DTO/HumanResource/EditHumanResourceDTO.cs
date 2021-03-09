using System;

namespace HRM.Core.DTO.HumanResource
{
    public class EditHumanResourceDTO: CreateHumanResourceDTO
    {
        public Guid Id { get; set; }
    }
}