using System;

namespace HRM.Core.DTO.HumanResource
{
    public class DeleteHumanResourceDTO : CreateHumanResourceDTO
    {
        public Guid Id { get; set; }
    }
}